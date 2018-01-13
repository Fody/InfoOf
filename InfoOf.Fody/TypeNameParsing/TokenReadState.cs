using System;
using Fody;

class TokenReadState : IState
{
    IState parentState;

    public TokenReadState(IState parentState) =>
        this.parentState = parentState;

    public IState OnGenericTypeStart() =>
        throw new WeavingException($"Expected a name, got {TypeNameParser.GenericTypeStart}");

    public IState OnGenericTypeEnd(IState currentState) =>
        throw new WeavingException($"Expected a name, got {TypeNameParser.GenericTypeEnd}");

    public IState OnAssemblyNameSeparator() =>
        throw new WeavingException($"Expected a name, got {TypeNameParser.AssemblyNameSeparator}");

    public IState OnGenericParamSeparator(IState currentState) =>
        throw new WeavingException($"Expected a name, got {TypeNameParser.GenericParamSeparator}");

    public IState OnReadToken(string token)
    {
        parentState.Token = token;
        return parentState;
    }

    public string Token { get; set; }

    public IState Validate() =>
        throw new WeavingException("Expected a name, got <end of type>");

    public ParsedTypeName Build() =>
        throw new InvalidOperationException();
}