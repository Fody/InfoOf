using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fody;

public static class TypeNameParser
{
    public static ParsedTypeName Parse(string typeName) =>
        Tokenize(typeName)
            .Aggregate((IState) new TokenReadState(new TypeNameState()),
                (s, t) => t.Process(s))
            .Validate()
            .Build();

    public const char GenericTypeStart = '<';
    public const char GenericTypeEnd = '>';
    public const char AssemblyNameSeparator = '|';
    public const char GenericParamSeparator = ',';
    public const char EscapeSequence = '\\';

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