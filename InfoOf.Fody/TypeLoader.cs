using Mono.Cecil;
using Mono.Cecil.Cil;

partial class ModuleWeaver
{
    (TypeReference, Instruction) LoadTypeReference(MethodReference methodReference, ILProcessor processor, Instruction instruction)
    {
        if (methodReference is GenericInstanceMethod genericReference)
        {
            var genericArgument = genericReference.GenericArguments[0].GetElementType();

            return (ModuleDefinition.ImportReference(genericArgument), instruction);
        }

        var typeNameInstruction = instruction;
        var typeName = GetLdString(typeNameInstruction);

        var assemblyNameInstruction = typeNameInstruction.Previous;
        var assemblyName = GetLdString(assemblyNameInstruction);

        processor.Remove(typeNameInstruction);
        processor.Remove(assemblyNameInstruction);

        return (GetTypeReference(assemblyName, typeName), assemblyNameInstruction);
    }
}