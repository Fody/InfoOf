class GenericTypeStartToken : IToken
{
    public IState Process(IState currentState) =>
        currentState.OnGenericTypeStart();
}