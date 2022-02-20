using System;
using System.Linq;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Mono.Collections.Generic;

#nullable enable

public sealed class ILProcessor : IDisposable
{
    private readonly MethodBody _body;
    private readonly Collection<Instruction> _instructions;

    internal ILProcessor(MethodBody body)
    {
        _body = body;
        _instructions = body.Instructions;

        body.SimplifyMacros();
    }

    public void InsertBefore(Instruction target, Instruction instruction)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));
        if (instruction == null)
            throw new ArgumentNullException(nameof(instruction));
        var index = _instructions.IndexOf(target);
        if (index == -1)
            throw new ArgumentOutOfRangeException(nameof(target));

        _instructions.Insert(index, instruction);

        UpdateReferences(target, instruction);
    }

    public void InsertAfter(Instruction target, Instruction instruction)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));
        if (instruction == null)
            throw new ArgumentNullException(nameof(instruction));
        var index = _instructions.IndexOf(target);
        if (index == -1)
            throw new ArgumentOutOfRangeException(nameof(target));

        _instructions.Insert(index + 1, instruction);
    }

    public void Remove(Instruction instruction)
    {
        if (instruction == null)
            throw new ArgumentNullException(nameof(instruction));
        var index = _instructions.IndexOf(instruction);
        if (index == -1)
            throw new ArgumentOutOfRangeException(nameof(instruction));

        _instructions.RemoveAt(index);

        var updated = _instructions[index];

        UpdateReferences(instruction, updated);
    }

    private void UpdateReferences(Instruction oldInstruction, Instruction newInstruction)
    {
        foreach (var updateInstruction in _body.Instructions.Where(i => i.Operand == oldInstruction))
            updateInstruction.Operand = newInstruction;

        foreach (var handler in _body.ExceptionHandlers)
        {
            if (handler.HandlerStart == oldInstruction)
                handler.HandlerStart = newInstruction;
            if (handler.FilterStart == oldInstruction)
                handler.FilterStart = newInstruction;
            if (handler.TryStart == oldInstruction)
                handler.TryStart = newInstruction;
            if (handler.HandlerEnd == oldInstruction)
                handler.HandlerEnd = newInstruction;
            if (handler.TryEnd == oldInstruction)
                handler.TryEnd = newInstruction;
        }

        UpdateDebugInformation(oldInstruction, newInstruction);
    }

    private void UpdateDebugInformation(Instruction oldInstruction, Instruction newInstruction)
    {
        var debugInformation = _body.Method.DebugInformation;
        if (!debugInformation.HasSequencePoints)
            return;

        var sequencePoint = debugInformation.GetSequencePoint(oldInstruction);
        if (sequencePoint == null)
            return;

        debugInformation.SequencePoints.Remove(sequencePoint);
        debugInformation.SequencePoints.Add(new SequencePoint(newInstruction, sequencePoint.Document));

        if (newInstruction != _instructions.First())
            return;

        var oldScope = debugInformation.Scope;
        var scope = new ScopeDebugInformation(_instructions.First(), _instructions.Last());
        foreach (var variable in oldScope.Variables) scope.Variables.Add(variable);

        debugInformation.Scope = scope;
    }

    public void Dispose()
    {
        _body.OptimizeMacros();
    }
}