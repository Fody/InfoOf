using Mono.Cecil;
using Mono.Cecil.Cil;

partial class ModuleWeaver
{
    (TypeReference, Instruction) LoadTypeReference(MethodReference methodReference, ILProcessor processor, Instruction instruction)
    {
        if (methodReference is GenericInstanceMethod genericReference)
        {
            return (ModuleDefinition.ImportReference(genericReference.GenericArguments[0]), instruction);
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