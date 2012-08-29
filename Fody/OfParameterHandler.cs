using System.Linq;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{

    void HandleOfParameter(Instruction instruction, ILProcessor ilProcessor)
    {
        //Info.OfMethod("AssemblyToProcess","MethodClass","InstanceMethod");

        var methodNameInstruction = instruction.Previous;
        var methodName = GetLdString(methodNameInstruction);

        var typeNameInstruction = methodNameInstruction.Previous;
        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        var typeDefinition = GetTypeDefinition(assemblyName, typeName);

        var methodDefinition = typeDefinition.Methods.FirstOrDefault(x => x.Name == methodName);
        if (methodDefinition == null)
        {
            throw new WeavingException(string.Format("Could not find method named '{0}'.", methodName));
        }

        var methodReference = ModuleDefinition.Import(methodDefinition);

        ilProcessor.Remove(typeNameInstruction);


        assemblyNameInstruction.OpCode = OpCodes.Ldtoken;
        assemblyNameInstruction.Operand = methodReference;

        instruction.Operand = getMethodFromHandle;
        
        ilProcessor.InsertAfter(instruction,Instruction.Create(OpCodes.Castclass,methodInfoType));
    }

}

