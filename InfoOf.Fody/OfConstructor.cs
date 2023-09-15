public partial class ModuleWeaver
{
    void HandleOfConstructor(Instruction instruction, ILProcessor ilProcessor,
        MethodReference ofConstructorReference)
    {
        //Info.OfConstructor("AssemblyToProcess","MethodClass");

        Instruction typeNameInstruction;
        List<string> parameters;
        Instruction parametersInstruction = null;

        switch (ofConstructorReference.Parameters.Count)
        {
            case 0:
                typeNameInstruction = instruction;
                parameters = new();
                break;
            case 1:
            case 3:
                parametersInstruction = instruction.Previous;
                parameters = GetLdString(parametersInstruction)
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(_ => _.Trim())
                    .ToList();
                typeNameInstruction = parametersInstruction.Previous;
                break;
            default:
                typeNameInstruction = instruction.Previous;
                parameters = new();
                break;
        }

        const string methodName = ".ctor";

        var typeReferenceData = LoadTypeReference(ofConstructorReference, ilProcessor, typeNameInstruction);
        var typeDefinition = typeReferenceData.TypeReference.Resolve();

        var method = typeDefinition.FindMethodDefinitions(methodName, parameters);

        var methodReference = ModuleDefinition.ImportReference(method);

        if (parametersInstruction != null)
        {
            ilProcessor.Remove(parametersInstruction);
        }

        var tokenInstruction = Instruction.Create(OpCodes.Ldtoken, methodReference);
        ilProcessor.InsertBefore(instruction, tokenInstruction);

        if (typeDefinition.HasGenericParameters)
        {
            ilProcessor.InsertBefore(instruction, Instruction.Create(OpCodes.Ldtoken, typeReferenceData.TypeReference));
            instruction.Operand = getMethodFromHandleGeneric;
        }
        else
        {
            instruction.Operand = getMethodFromHandle;
        }

        ilProcessor.InsertAfter(instruction, Instruction.Create(OpCodes.Castclass, constructorInfoType));
    }
}