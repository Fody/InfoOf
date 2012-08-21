using System.Linq;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{

    void HandleOfMethod(Instruction instruction, ILProcessor ilProcessor)
    {
        var previous = instruction.Previous;
        var ldString = GetLdString(previous);
        var strings = ldString.Split('.');
        var typeName = string.Join(".", strings.Take(strings.Length - 1));
        var methodName = strings.Last();

        var typeDefinition = GetTypeDefinition(typeName);

        var method = typeDefinition.Methods.FirstOrDefault(x => x.Name == methodName);

        if (method == null)
        {
            throw new WeavingException(string.Format("Could not find method named '{0}'.", ldString));
        }

        previous.OpCode = OpCodes.Ldtoken;
        previous.Operand = method;
        instruction.Operand = getMethodFromHandle;
        ilProcessor.InsertAfter(instruction,Instruction.Create(OpCodes.Castclass,methodInfoType));
    }

}

