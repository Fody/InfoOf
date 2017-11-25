class NameToken : IToken
{
    string token;

    public NameToken(string token) => this.token = token;

    public IState Process(IState currentState) =>
        currentState.OnReadToken(token);
}