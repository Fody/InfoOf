public partial class ModuleWeaver
{
    void HandleOfMethod(Instruction instruction, ILProcessor ilProcessor, MethodReference ofMethodReference)
    {
        //Info.OfMethod("AssemblyToProcess","MethodClass","InstanceMethod");

        Instruction methodNameInstruction;
        List<string> parameters;
        Instruction parametersInstruction = null;
        if (ofMethodReference.Parameters.Count is 2 or 4)
        {
            parametersInstruction = instruction.Previous;
            parameters = GetLdString(parametersInstruction).GetParameters();
            methodNameInstruction = parametersInstruction.Previous;
        }
        else
        {
            methodNameInstruction = instruction.Previous;
            parameters = new();
        }

        var methodName = GetLdString(methodNameInstruction);

        var typeReferenceData = LoadTypeReference(ofMethodReference, ilProcessor, methodNameInstruction.Previous);
        var typeDefinition = typeReferenceData.TypeReference.Resolve();

        var method = typeDefinition.FindMethodDefinitions(methodName, parameters);

        var methodReference = ModuleDefinition.ImportReference(method);

        if (parametersInstruction != null)
        {
            ilProcessor.Remove(parametersInstruction);
        }

        methodNameInstruction.OpCode = OpCodes.Ldtoken;
        methodNameInstruction.Operand = methodReference;

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