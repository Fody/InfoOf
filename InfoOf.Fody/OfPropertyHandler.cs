using Fody;

public partial class ModuleWeaver
{
    void HandleOfPropertyGet(Instruction instruction, ILProcessor ilProcessor, MethodReference ofPropertyGetReference)
    {
        HandleOfProperty(instruction, ilProcessor, ofPropertyGetReference, _ => _.GetMethod);
    }

    void HandleOfPropertySet(Instruction instruction, ILProcessor ilProcessor, MethodReference ofPropertySetReference)
    {
        HandleOfProperty(instruction, ilProcessor, ofPropertySetReference, _ => _.SetMethod);
    }

    void HandleOfProperty(Instruction instruction, ILProcessor ilProcessor, MethodReference propertyReference, Func<PropertyDefinition, MethodDefinition> func)
    {
        var propertyNameInstruction = instruction.Previous;
        var propertyName = GetLdString(propertyNameInstruction);

        var typeReferenceData = LoadTypeReference(propertyReference, ilProcessor, propertyNameInstruction.Previous);
        var typeDefinition = typeReferenceData.TypeReference.Resolve();

        var property = typeDefinition.Properties.FirstOrDefault(_ => _.Name == propertyName);

        if (property == null)
        {
            throw new WeavingException($"Could not find property named '{propertyName}'.");
        }
        var methodDefinition = func(property);
        if (methodDefinition == null)
        {
            throw new WeavingException($"Could not find property named '{propertyName}'.");
        }

        var methodReference = ModuleDefinition.ImportReference(methodDefinition);

        propertyNameInstruction.OpCode = OpCodes.Ldtoken;
        propertyNameInstruction.Operand = methodReference;

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