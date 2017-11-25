class NullToken : IToken
{
    public IState Process(IState currentState) => currentState;
}