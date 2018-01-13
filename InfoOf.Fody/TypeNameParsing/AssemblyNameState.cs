using System;
using Fody;

class AssemblyNameState : IState
{
    GenericParameterState parentState;
    IState childState;

    public AssemblyNameState(GenericParameterState parentState) =>
        this.parentState = parentState;

    public IState OnGenericTypeStart() =>
        throw new WeavingException($"Expected assembly name separator, got {TypeNameParser.GenericTypeStart}");

    public IState OnGenericTypeEnd(IState currentState)
    {
        if (currentState is AssemblyNameState assemblyNameState &&
            assemblyNameState.childState == null)
        {
            throw new WeavingException($"Expected assembly name separator, got {TypeNameParser.GenericTypeEnd}");
        }

        childState = currentState;
        return parentState.OnGenericTypeEnd(this);
    }

    public IState OnAssemblyNameSeparator() =>
        new TokenReadState(new TypeNameState(this));

    public IState OnGenericParamSeparator(IState currentState)
    {
        if (currentState is AssemblyNameState assemblyNameState &&
            assemblyNameState.childState == null)
        {
            throw new WeavingException($"Expected assembly name separator, got {TypeNameParser.GenericParamSeparator}");
        }

        childState = currentState;
        return parentState.OnGenericParamSeparator(this);
    }

    public IState OnReadToken(string token) =>
        throw new InvalidOperationException();

    public string Token { get; set; }

    public IState Validate() =>
        throw new WeavingException("Expected assembly name separator, got <end of type>");

    public ParsedTypeName Build()
    {
        if (childState is GenericParameterState)
        {
            childState.Token = Token;
            return childState.Build();
        }

        return new ParsedTypeName
        {
            Assembly = Token,
            TypeName = childState.Token
        };
    }
}