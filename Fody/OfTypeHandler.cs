using Mono.Cecil.Cil;

public partial class ModuleWeaver
{

    void HandleOfType(Instruction instruction, ILProcessor ilProcessor)
    {
        //Info.OfType("AssemblyToProcess","TypeClass");

        var typeNameInstruction= instruction.Previous;
        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        var typeDefinition = GetTypeDefinition(assemblyName, typeName);
        var typeReference = ModuleDefinition.Import(typeDefinition);
        ilProcessor.Remove(typeNameInstruction);
        ilProcessor.Replace(assemblyNameInstruction, Instruction.Create(OpCodes.Ldtoken, typeReference));
        instruction.Operand = getTypeFromHandle;
    }

}

