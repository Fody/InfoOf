class GenericParameterSeparatorToken : IToken
{
    public IState Process(IState currentState) =>
        currentState.OnGenericParamSeparator(currentState);
}