using System.Linq;
using Mono.Cecil.Cil;

public static class MethodBodyExtensions
{
    public static void UpdateInstructions(this MethodBody body,
        Instruction oldInstruction, Instruction newInstruction)
    {
        foreach (var updateInstruction in body.Instructions
            .Where(i => i.Operand == oldInstruction))
        {
            updateInstruction.Operand = newInstruction;
        }

        foreach (var updateInstruction in body.ExceptionHandlers
            .Where(h => h.HandlerEnd == oldInstruction))
        {
            updateInstruction.HandlerEnd = newInstruction;
        }
    }
}
