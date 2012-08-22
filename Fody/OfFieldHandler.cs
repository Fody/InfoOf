using System.Linq;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{

    void HandleOfField(Instruction instruction, ILProcessor ilProcessor)
    {
        //Info.OfField("AssemblyToProcess","MethodClass","Field");
        var fieldNameInstruction = instruction.Previous;
        var fieldName = GetLdString(fieldNameInstruction);

        var typeNameInstruction = fieldNameInstruction.Previous;
        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        var typeDefinition = GetTypeDefinition(assemblyName, typeName);

        var fieldDefinition = typeDefinition.Fields.FirstOrDefault(x => x.Name == fieldName);
        if (fieldDefinition == null)
        {
            throw new WeavingException(string.Format("Could not find field named '{0}'.", fieldName));
        }

        var fieldReference = ModuleDefinition.Import(fieldDefinition);

        ilProcessor.Remove(typeNameInstruction);
        ilProcessor.Remove(fieldNameInstruction);
        ilProcessor.Replace(assemblyNameInstruction, Instruction.Create(OpCodes.Ldtoken, fieldReference));

        instruction.Operand = getFieldFromHandle;
    }

}

