using Mono.Cecil;
using Mono.Cecil.Cil;

class TypeReferenceData
{
    public TypeReference TypeReference { get; }
    public Instruction Instruction { get; }

    public TypeReferenceData(TypeReference typeReference, Instruction instruction)
    {
        TypeReference = typeReference;
        Instruction = instruction;
    }
}