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
            throw new WeavingException(string.Format("Could not find field named '{0}'.", fieldName))
                {
                    SequencePoint = instruction.SequencePoint
                };
        }

        var fieldReference = ModuleDefinition.ImportReference(fieldDefinition);

        ilProcessor.Remove(typeNameInstruction);
        ilProcessor.Remove(fieldNameInstruction);

        assemblyNameInstruction.OpCode = OpCodes.Ldtoken;
        assemblyNameInstruction.Operand = fieldReference;

        if (typeDefinition.HasGenericParameters)
        {
            var typeReference = ModuleDefinition.ImportReference(typeDefinition);
            ilProcessor.InsertBefore(instruction, Instruction.Create(OpCodes.Ldtoken,typeReference));
            instruction.Operand = getFieldFromHandleGeneric;
        }
        else
        {
            instruction.Operand = getFieldFromHandle;   
        }
    }

}

