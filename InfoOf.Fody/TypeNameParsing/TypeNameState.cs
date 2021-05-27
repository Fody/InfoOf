using System;
using Fody;

class TypeNameState : IState
{
    AssemblyNameState parentState;

    public TypeNameState()
    {
    }

    public TypeNameState(AssemblyNameState parentState) =>
        this.parentState = parentState;

    public IState OnGenericTypeStart() =>
        new GenericParameterState(this).OnGenericTypeStart();

    public IState OnGenericTypeEnd(IState currentState)
    {
        if (parentState == null)
        {
            throw new WeavingException("Unexpected generic type end");
        }

        return parentState.OnGenericTypeEnd(currentState);
    }

    public IState OnAssemblyNameSeparator() =>
        throw new WeavingException("Unexpected assembly name separator");

    public IState OnGenericParamSeparator(IState currentState)
    {
        if (parentState == null)
        {
            throw new WeavingException("Unexpected generic param separator");
        }

        return parentState.OnGenericParamSeparator(currentState);
    }

    public IState OnReadToken(string token) =>
        throw new InvalidOperationException();

    public string Token { get; set; }

    public IState Validate()
    {
        if (parentState == null)
        {
            return this;
        }

        throw new WeavingException($"Unbalanced type specification, are you missing a {TypeNameParser.GenericTypeEnd}?");
    }

    public ParsedTypeName Build() => new() {TypeName = Token};
}