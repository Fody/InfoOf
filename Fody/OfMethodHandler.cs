using System.Linq;
using Mono.Cecil.Cil;

public partial class ModuleWeaver
{

    void HandleOfMethod(Instruction instruction, ILProcessor ilProcessor)
    {
        //Info.OfMethod("AssemblyToProcess","MethodClass","InstanceMethod");
        //"System.Reflection.MethodInfo MethodClass::WithGenericParamMethod(System.Action`1<System.Int32>)"
        //"System.Reflection.MethodInfo MethodClass::WithGenericParamMethod(System.Action`1<T>)"
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
        ilProcessor.Remove(methodNameInstruction);
        ilProcessor.Replace(assemblyNameInstruction, Instruction.Create(OpCodes.Ldtoken, methodReference));


        if (typeDefinition.HasGenericParameters)
        {
            var typeReference = ModuleDefinition.Import(typeDefinition);
            ilProcessor.InsertBefore(instruction, Instruction.Create(OpCodes.Ldtoken, typeReference));
            instruction.Operand = getMethodFromHandleGeneric;
        }
        else
        {
            instruction.Operand = getMethodFromHandle;
        }
        
        ilProcessor.InsertAfter(instruction,Instruction.Create(OpCodes.Castclass,methodInfoType));
    }

}

