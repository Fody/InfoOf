class GenericTypeEndToken : IToken
{
    public IState Process(IState currentState) =>
        currentState.OnGenericTypeEnd(currentState);
}