using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{

    void HandleOfPropertyGet(Instruction instruction, ILProcessor ilProcessor)
    {
        HandleOfProperty(instruction, ilProcessor, x => x.GetMethod);
    }

    void HandleOfPropertySet(Instruction instruction, ILProcessor ilProcessor)
    {
        HandleOfProperty(instruction, ilProcessor, x => x.SetMethod);
    }

    void HandleOfProperty(Instruction instruction, ILProcessor ilProcessor, Func<PropertyDefinition, MethodDefinition> func)
    {
        var propertyNameInstruction = instruction.Previous;
        var propertyName = GetLdString(propertyNameInstruction);

        var typeNameInstruction = propertyNameInstruction.Previous;
        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        var typeDefinition = GetTypeDefinition(assemblyName, typeName);

        var property = typeDefinition.Properties.FirstOrDefault(x => x.Name == propertyName);

        if (property == null)
        {
            throw new WeavingException($"Could not find property named '{propertyName}'.")
            {
                SequencePoint = instruction.SequencePoint
            };
        }
        var methodDefinition = func(property);
        if (methodDefinition == null)
        {
            throw new WeavingException($"Could not find property named '{propertyName}'.")
            {
                SequencePoint = instruction.SequencePoint
            };
        }
        ilProcessor.Remove(typeNameInstruction);
        ilProcessor.Remove(propertyNameInstruction);


        assemblyNameInstruction.OpCode = OpCodes.Ldtoken;
        assemblyNameInstruction.Operand = methodDefinition;

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

        ilProcessor.InsertAfter(instruction, Instruction.Create(OpCodes.Castclass, methodInfoType));
    }


}