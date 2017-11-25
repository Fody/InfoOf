class AssemblyNameSeparatorToken : IToken
{
    public IState Process(IState currentState) =>
        currentState.OnAssemblyNameSeparator();
}