interface IState
{
    IState OnGenericTypeStart();
    IState OnGenericTypeEnd(IState currentState);
    IState OnAssemblyNameSeparator();
    IState OnGenericParamSeparator(IState currentState);
    IState OnReadToken(string token);
    string Token { get; set; }
    IState Validate();
    ParsedTypeName Build();
}