#nullable enable

public sealed class ILProcessor : IDisposable
{
    readonly MethodBody body;
    readonly Collection<Instruction> instructions;

    internal ILProcessor(MethodBody body)
    {
        this.body = body;
        instructions = body.Instructions;

        body.SimplifyMacros();
    }

    public void InsertBefore(Instruction target, Instruction instruction)
    {
        var index = instructions.IndexOf(target);
        if (index == -1)
        {
            throw new ArgumentOutOfRangeException(nameof(target));
        }

        instructions.Insert(index, instruction);

        UpdateReferences(target, instruction);
    }

    public void InsertAfter(Instruction target, Instruction instruction)
    {
        var index = instructions.IndexOf(target);
        if (index == -1)
        {
            throw new ArgumentOutOfRangeException(nameof(target));
        }

        instructions.Insert(index + 1, instruction);
    }

    public void Remove(Instruction instruction)
    {
        var index = instructions.IndexOf(instruction);
        if (index == -1)
        {
            throw new ArgumentOutOfRangeException(nameof(instruction));
        }

        instructions.RemoveAt(index);

        var updated = instructions[index];

        UpdateReferences(instruction, updated);
    }

    void UpdateReferences(Instruction oldInstruction, Instruction newInstruction)
    {
        foreach (var updateInstruction in body.Instructions.Where(_ => _.Operand == oldInstruction))
        {
            updateInstruction.Operand = newInstruction;
        }

        foreach (var handler in body.ExceptionHandlers)
        {
            if (handler.HandlerStart == oldInstruction)
            {
                handler.HandlerStart = newInstruction;
            }

            if (handler.FilterStart == oldInstruction)
            {
                handler.FilterStart = newInstruction;
            }

            if (handler.TryStart == oldInstruction)
            {
                handler.TryStart = newInstruction;
            }

            if (handler.HandlerEnd == oldInstruction)
            {
                handler.HandlerEnd = newInstruction;
            }

            if (handler.TryEnd == oldInstruction)
            {
                handler.TryEnd = newInstruction;
            }
        }

        UpdateDebugInformation(oldInstruction, newInstruction);
    }

    void UpdateDebugInformation(Instruction oldInstruction, Instruction newInstruction)
    {
        var debugInformation = body.Method.DebugInformation;
        if (!debugInformation.HasSequencePoints)
        {
            return;
        }

        var sequencePoint = debugInformation.GetSequencePoint(oldInstruction);
        if (sequencePoint == null)
        {
            return;
        }

        debugInformation.SequencePoints.Remove(sequencePoint);
        debugInformation.SequencePoints.Add(new(newInstruction, sequencePoint.Document));

        if (newInstruction != instructions.First())
        {
            return;
        }

        var oldScope = debugInformation.Scope;
        var scope = new ScopeDebugInformation(instructions.First(), instructions.Last());
        foreach (var variable in oldScope.Variables) scope.Variables.Add(variable);

        debugInformation.Scope = scope;
    }

    public void Dispose()
    {
        body.OptimizeMacros();
    }
}