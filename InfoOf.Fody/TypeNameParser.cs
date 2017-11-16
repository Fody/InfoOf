using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ParsedTypeName
{
    public string Assembly { get; set; }
    public string TypeName { get; set; }
    public IReadOnlyList<ParsedTypeName> GenericParameters { get; set; }

    public override string ToString()
    {
        if (GenericParameters == null)
        {
            return TypeName;
        }

        return $"{TypeName}<{string.Join(", ", GenericParameters.Select(p => p.ToString()))}>";
    }
}

public static class TypeNameParser
{
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

    class TypeNameState : IState
    {
        readonly AssemblyNameState _parentState;

        public TypeNameState()
        {
        }

        public TypeNameState(AssemblyNameState parentState) =>
            _parentState = parentState;

        public IState OnGenericTypeStart() =>
            new GenericParameterState(this).OnGenericTypeStart();

        public IState OnGenericTypeEnd(IState currentState) =>
            _parentState.OnGenericTypeEnd(currentState);

        public IState OnAssemblyNameSeparator() =>
            throw new WeavingException("Unexpected assembly name separator");

        public IState OnGenericParamSeparator(IState currentState) =>
            _parentState.OnGenericParamSeparator(currentState);

        public IState OnReadToken(string token) =>
            throw new InvalidOperationException();

        public string Token { get; set; }

        public IState Validate()
        {
            if (_parentState == null)
            {
                return this;
            }

            throw new WeavingException("Unbalanced type specification, are you missing a " +
                GenericTypeEnd + "?");
        }

        public ParsedTypeName Build() =>
            new ParsedTypeName
            {
                TypeName = Token
            };
    }

    class GenericParameterState : IState
    {
        readonly TypeNameState _parentState;
        readonly IList<AssemblyNameState> _genericParameters;

        public GenericParameterState(TypeNameState parentState)
        {
            _parentState = parentState;
            _genericParameters = new List<AssemblyNameState>();
        }

        public IState OnGenericTypeStart() =>
            new TokenReadState(new AssemblyNameState(this));

        public IState OnGenericTypeEnd(IState currentState)
        {
            if (currentState is GenericParameterState)
            {
                return _parentState.OnGenericTypeEnd(currentState);
            }

            _genericParameters.Add((AssemblyNameState)currentState);
            return this;
        }

        public IState OnAssemblyNameSeparator() =>
            throw new WeavingException("Unexpected assembly name separator");

        public IState OnGenericParamSeparator(IState currentState)
        {
            _genericParameters.Add((AssemblyNameState)currentState);
            return new TokenReadState(new AssemblyNameState(this));
        }

        public IState OnReadToken(string token) =>
            throw new WeavingException("Unexpected name token");

        public string Token { get; set; }

        public IState Validate()
        {
            _parentState.Validate();
            return this;
        }

        public ParsedTypeName Build() =>
            new ParsedTypeName
            {
                Assembly = Token,
                TypeName = _parentState.Token,
                GenericParameters = _genericParameters.Select(p => p.Build()).ToList()
            };
    }

    class AssemblyNameState : IState
    {
        readonly GenericParameterState _parentState;
        IState _childState;

        public AssemblyNameState(GenericParameterState parentState) =>
            _parentState = parentState;

        public IState OnGenericTypeStart() =>
            throw new WeavingException("Expected assembly name separator, got " + GenericTypeStart);

        public IState OnGenericTypeEnd(IState currentState)
        {
            _childState = currentState;
            return _parentState.OnGenericTypeEnd(this);
        }

        public IState OnAssemblyNameSeparator() =>
            new TokenReadState(new TypeNameState(this));

        public IState OnGenericParamSeparator(IState currentState)
        {
            _childState = currentState;
            return _parentState.OnGenericParamSeparator(this);
        }

        public IState OnReadToken(string token) =>
            throw new InvalidOperationException();

        public string Token { get; set; }

        public IState Validate() =>
            throw new WeavingException("Expected assembly name separator, got <end of type>");

        public ParsedTypeName Build()
        {
            if (_childState is GenericParameterState)
            {
                _childState.Token = Token;
                return _childState.Build();
            }

            return new ParsedTypeName
            {
                Assembly = Token,
                TypeName = _childState.Token
            };
        }
    }

    class TokenReadState : IState
    {
        readonly IState _parentState;

        public TokenReadState(IState parentState) =>
            _parentState = parentState;

        public IState OnGenericTypeStart() =>
            throw new WeavingException("Expected a name, got " + GenericTypeStart);

        public IState OnGenericTypeEnd(IState currentState) =>
            throw new WeavingException("Expected a name, got " + GenericTypeEnd);

        public IState OnAssemblyNameSeparator() =>
            throw new WeavingException("Expected a name, got " + AssemblyNameSeparator);

        public IState OnGenericParamSeparator(IState currentState) =>
            throw new WeavingException("Expected a name, got " + GenericParamSeparator);

        public IState OnReadToken(string token)
        {
            _parentState.Token = token;
            return _parentState;
        }

        public string Token { get; set; }

        public IState Validate() =>
            throw new WeavingException("Expected a name, got <end of type>");

        public ParsedTypeName Build() =>
            throw new InvalidOperationException();
    }

    public static ParsedTypeName Parse(string typeName) =>
        Tokenize(typeName)
            .Aggregate((IState)new TokenReadState(new TypeNameState()),
                (s, t) => t.Process(s))
            .Validate()
            .Build();

    interface IToken
    {
        IState Process(IState currentState);
    }

    class GenericTypeStartToken : IToken
    {
        public IState Process(IState currentState) =>
            currentState.OnGenericTypeStart();
    }

    class GenericTypeEndToken : IToken
    {
        public IState Process(IState currentState) =>
            currentState.OnGenericTypeEnd(currentState);
    }

    class AssemblyNameSeparatorToken : IToken
    {
        public IState Process(IState currentState) =>
            currentState.OnAssemblyNameSeparator();
    }

    class GenericParameterSeparatorToken : IToken
    {
        public IState Process(IState currentState) =>
            currentState.OnGenericParamSeparator(currentState);
    }

    class NameToken : IToken
    {
        readonly string _token;

        public NameToken(string token) => _token = token;

        public IState Process(IState currentState) =>
            currentState.OnReadToken(_token);
    }

    class NullToken : IToken
    {
        public IState Process(IState currentState) => currentState;
    }

    const char GenericTypeStart = '<';
    const char GenericTypeEnd = '>';
    const char AssemblyNameSeparator = '|';
    const char GenericParamSeparator = ',';
    const char EscapeSequence = '\\';

    static IEnumerable<IToken> Tokenize(string typeName)
    {
        var currentToken = new StringBuilder();

        for (var index = 0; index < typeName.Length; ++index)
        {
            var currentChar = typeName[index];
            switch (currentChar)
            {
            case GenericTypeStart:
                yield return CheckForNameToken();
                yield return new GenericTypeStartToken();
                break;
            case GenericTypeEnd:
                yield return CheckForNameToken();
                yield return new GenericTypeEndToken();
                break;
            case AssemblyNameSeparator:
                yield return CheckForNameToken();
                yield return new AssemblyNameSeparatorToken();
                break;
            case GenericParamSeparator:
                yield return CheckForNameToken();
                yield return new GenericParameterSeparatorToken();
                break;
            default:
                if (currentChar == EscapeSequence)
                {
                    var escapedChar = typeName[++index];
                    switch (escapedChar)
                    {
                    case GenericTypeStart:
                    case GenericTypeEnd:
                    case AssemblyNameSeparator:
                    case GenericParamSeparator:
                    case EscapeSequence:
                        currentToken.Append(escapedChar);
                        continue;
                    default:
                        if (char.IsWhiteSpace(escapedChar))
                        {
                            currentToken.Append(escapedChar);
                            continue;
                        }
                        throw new WeavingException($"Unrecognized escape sequence '\\{escapedChar}'");
                    }
                }

                if (!char.IsWhiteSpace(currentChar))
                {
                    currentToken.Append(currentChar);
                }
                break;
            }
        }

        yield return CheckForNameToken();

        IToken CheckForNameToken()
        {
            if (currentToken.Length == 0)
            {
                return new NullToken();
            }

            var token = currentToken.ToString();
            currentToken.Clear();
            return new NameToken(token);
        }
    }
}
