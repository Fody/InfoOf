using Mono.Cecil.Cil;

public partial class ModuleWeaver
{
    void HandleOfType(Instruction instruction, ILProcessor ilProcessor)
    {
        //Info.OfType("AssemblyToProcess","TypeClass");

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
