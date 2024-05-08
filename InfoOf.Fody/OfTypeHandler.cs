public partial class ModuleWeaver
{
    //Info.OfType("AssemblyToProcess","TypeClass");
    void HandleOfType(Instruction instruction, ILProcessor ilProcessor)
    {
        var typeNameInstruction = instruction.Previous;
        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        var typeReference = GetTypeReference(assemblyName, typeName);

        ilProcessor.Remove(typeNameInstruction);

        assemblyNameInstruction.OpCode = OpCodes.Ldtoken;
        assemblyNameInstruction.Operand = typeReference;

        instruction.Operand = getTypeFromHandle;
    }
}
