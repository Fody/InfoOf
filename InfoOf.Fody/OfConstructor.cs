using System;
using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{
    void HandleOfConstructor(Instruction instruction, ILProcessor ilProcessor,
        MethodReference ofConstructorReference)
    {
        //Info.OfConstructor("AssemblyToProcess","MethodClass");

        Instruction typeNameInstruction;
        List<string> parameters;
        Instruction parametersInstruction = null;

        if (ofConstructorReference.Parameters.Count == 1 || ofConstructorReference.Parameters.Count == 3)
        {
            parametersInstruction = instruction.Previous;
            parameters = GetLdString(parametersInstruction)
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            typeNameInstruction = parametersInstruction.Previous;
        }
        else
        {
            typeNameInstruction = instruction.Previous;
            parameters = new List<string>();
        }

        const string methodName = ".ctor";

        var typeReference = LoadTypeReference(ofConstructorReference, ilProcessor, typeNameInstruction);
        var typeDefinition = typeReference.Resolve();

        var methodDefinitions = typeDefinition.FindMethodDefinitions(methodName, parameters);

        if (methodDefinitions.Count == 0)
        {
            throw new WeavingException($"Could not find method named '{methodName}'.");
        }
        if (methodDefinitions.Count > 1)
        {
            throw new WeavingException($"More than one method named '{methodName}' found.");
        }

        var methodReference = ModuleDefinition.ImportReference(methodDefinitions[0]);

        if (parametersInstruction != null)
        {
            ilProcessor.Remove(parametersInstruction);
        }

        var tokenInstruction = Instruction.Create(OpCodes.Ldtoken, methodReference);
        ilProcessor.InsertBefore(instruction, tokenInstruction);

        if (typeDefinition.HasGenericParameters)
        {
            ilProcessor.InsertBefore(instruction, Instruction.Create(OpCodes.Ldtoken, typeReference));
            instruction.Operand = getMethodFromHandleGeneric;
        }
        else
        {
            instruction.Operand = getMethodFromHandle;
        }

        ilProcessor.InsertAfter(instruction, Instruction.Create(OpCodes.Castclass, constructorInfoType));
    }
}