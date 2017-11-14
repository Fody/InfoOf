using System;
using System.Collections.Generic;
using System.Linq;
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
        if (ofConstructorReference.Parameters.Count == 3)
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

        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        var typeDefinition = GetTypeDefinition(assemblyName, typeName);

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

        ilProcessor.Remove(typeNameInstruction);
        if (parametersInstruction != null)
        {
            ilProcessor.Remove(parametersInstruction);
        }

        assemblyNameInstruction.OpCode = OpCodes.Ldtoken;
        assemblyNameInstruction.Operand = methodReference;

        if (typeDefinition.HasGenericParameters)
        {
            var typeReference = ModuleDefinition.ImportReference(typeDefinition);
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
