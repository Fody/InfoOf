using System.Linq;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{
    void HandleOfField(Instruction instruction, ILProcessor ilProcessor, MethodReference ofFieldReference)
    {
        //Info.OfField("AssemblyToProcess","MethodClass","Field");
        var fieldNameInstruction = instruction.Previous;
        var fieldName = GetLdString(fieldNameInstruction);

        var typeReference = LoadTypeReference(ofFieldReference, ilProcessor, fieldNameInstruction.Previous);
        var typeDefinition = typeReference.Resolve();

        var fieldDefinition = typeDefinition.Fields.FirstOrDefault(x => x.Name == fieldName);
        if (fieldDefinition == null)
        {
            throw new WeavingException($"Could not find field named '{fieldName}'.");
        }

        FieldReference fieldReference;
        if (fieldDefinition.DeclaringType.HasGenericParameters &&
            !typeReference.HasGenericParameters)
        {
            var declaringType = new GenericInstanceType(fieldDefinition.DeclaringType);
            foreach (var parameter in fieldDefinition.DeclaringType.GenericParameters)
            {
                declaringType.GenericArguments.Add(parameter);
            }
            fieldReference = new FieldReference(fieldDefinition.Name, fieldDefinition.FieldType, declaringType);
        }
        else
        {
            fieldReference = ModuleDefinition.ImportReference(fieldDefinition);
        }

        fieldNameInstruction.OpCode = OpCodes.Ldtoken;
        fieldNameInstruction.Operand = fieldReference;

        if (typeDefinition.HasGenericParameters)
        {
            ilProcessor.InsertBefore(instruction, Instruction.Create(OpCodes.Ldtoken, typeReference));
            instruction.Operand = getFieldFromHandleGeneric;
        }
        else
        {
            instruction.Operand = getFieldFromHandle;
        }
    }

}
