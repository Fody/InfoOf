using System;
using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{
    void HandleOfIndexerGet(Instruction instruction, ILProcessor ilProcessor, MethodReference ofIndexerGetReference)
    {
        HandleOfIndexer(instruction, ilProcessor, ofIndexerGetReference, x => x.GetMethod, (_, p) => p);
    }

    void HandleOfIndexerSet(Instruction instruction, ILProcessor ilProcessor, MethodReference ofIndexerSetReference)
    {
        HandleOfIndexer(instruction, ilProcessor, ofIndexerSetReference, x => x.SetMethod, (d, p) => p.Append(d.PropertyType.Name).ToList());
    }

    void HandleOfIndexer(Instruction instruction, ILProcessor ilProcessor, MethodReference propertyReference,
        Func<PropertyDefinition, MethodDefinition> func, Func<PropertyDefinition, List<string>, List<string>> getParameters)
    {
        var parametersInstruction = instruction.Previous;
        var parameters = GetLdString(parametersInstruction)
            .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToList();

        const string propertyName = "Item";

        var typeReferenceData = LoadTypeReference(propertyReference, ilProcessor, parametersInstruction.Previous);
        var typeDefinition = typeReferenceData.TypeReference.Resolve();

        var property = typeDefinition.Properties.FirstOrDefault(x => x.Name == propertyName &&
            (func(x)?.HasSameParams(getParameters(x, parameters)) ?? false));

        if (property == null)
        {
            throw new WeavingException("Could not find indexer.");
        }
        var methodDefinition = func(property);
        if (methodDefinition == null)
        {
            throw new WeavingException("Could not find indexer.");
        }

        var methodReference = ModuleDefinition.ImportReference(methodDefinition);

        parametersInstruction.OpCode = OpCodes.Ldtoken;
        parametersInstruction.Operand = methodReference;

        if (typeDefinition.HasGenericParameters)
        {
            ilProcessor.InsertBefore(instruction, Instruction.Create(OpCodes.Ldtoken, typeReferenceData.TypeReference));
            instruction.Operand = getMethodFromHandleGeneric;
        }
        else
        {
            instruction.Operand = getMethodFromHandle;
        }

        ilProcessor.InsertAfter(instruction, Instruction.Create(OpCodes.Castclass, methodInfoType));
    }
}