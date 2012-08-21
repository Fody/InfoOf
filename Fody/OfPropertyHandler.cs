using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{


    void HandleOfPropertyGet(Instruction instruction, ILProcessor ilProcessor)
    {
        var previous = instruction.Previous;
        var ldString = GetLdString(previous);
        var property = GetPropertyDefinition(ldString);
        if (property.GetMethod == null)
        {
            throw new WeavingException(string.Format("Could not find property named '{0}'.", ldString));
        }
        previous.OpCode = OpCodes.Ldtoken;
        previous.Operand = property.GetMethod;
        instruction.Operand = getMethodFromHandle;
        ilProcessor.InsertAfter(instruction, Instruction.Create(OpCodes.Castclass, methodInfoType));
    }    

    void HandleOfPropertySet(Instruction instruction, ILProcessor ilProcessor)
    {
        var previous = instruction.Previous;
        var ldString = GetLdString(previous);
        var property = GetPropertyDefinition(ldString);
        if (property.SetMethod == null)
        {
            throw new WeavingException(string.Format("Could not find property named '{0}'.", ldString));
        }
        previous.OpCode = OpCodes.Ldtoken;
        previous.Operand = property.SetMethod;
        instruction.Operand = getMethodFromHandle;
        ilProcessor.InsertAfter(instruction, Instruction.Create(OpCodes.Castclass, methodInfoType));
    }

    PropertyDefinition GetPropertyDefinition(string ldString)
    {
        var strings = ldString.Split('.');
        var typeName = string.Join(".", strings.Take(strings.Length - 1));
        var propertyName = strings.Last();

        var typeDefinition = GetTypeDefinition(typeName);

        var property = typeDefinition.Properties.FirstOrDefault(x => x.Name == propertyName);

        if (property == null)
        {
            throw new WeavingException(string.Format("Could not find property named '{0}'.", ldString));
        }
        return property;
    }

}