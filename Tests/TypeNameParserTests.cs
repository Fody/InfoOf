using Fody;
using Xunit;
using Xunit.Abstractions;

public class TypeNameParserTests :
    XunitApprovalBase
{
    [Fact]
    public void Simple()
    {
        var parsedTypeName = TypeNameParser.Parse("a");

        Assert.Equal("a", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        Assert.Null(parsedTypeName.GenericParameters);
    }

    [Fact]
    public void SimpleWithSpecialChars()
    {
        var parsedTypeName = TypeNameParser.Parse(@"\<\>\|\,\\\ ");

        Assert.Equal(@"<>|,\ ", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        Assert.Null(parsedTypeName.GenericParameters);
    }

    [Fact]
    public void SimpleIgnoresWhiteSpace()
    {
        var parsedTypeName = TypeNameParser.Parse(" \ta\r\n");

        Assert.Equal("a", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        Assert.Null(parsedTypeName.GenericParameters);
    }

    [Fact]
    public void Generic()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c>");

        Assert.Equal("a", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        var parameters = parsedTypeName.GenericParameters;
        Assert.NotNull(parameters);
        Assert.NotEmpty(parameters);
        Assert.Equal(1, parameters.Count);
        Assert.Equal("b", parameters[0].Assembly);
        Assert.Equal("c", parameters[0].TypeName);
        Assert.Null(parameters[0].GenericParameters);
    }

    [Fact]
    public void MultipleGeneric()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c,d|e>");

        Assert.Equal("a", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        var parameters = parsedTypeName.GenericParameters;
        Assert.NotNull(parameters);
        Assert.NotEmpty(parameters);
        Assert.Equal(2, parameters.Count);
        Assert.Equal("b", parameters[0].Assembly);
        Assert.Equal("c", parameters[0].TypeName);
        Assert.Null(parameters[0].GenericParameters);
        Assert.Equal("d", parameters[1].Assembly);
        Assert.Equal("e", parameters[1].TypeName);
        Assert.Null(parameters[1].GenericParameters);
    }

    [Fact]
    public void TwoLevelsDeep()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c<d|e>>");

        Assert.Equal("a", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        var parameters = parsedTypeName.GenericParameters;
        Assert.NotNull(parameters);
        Assert.NotEmpty(parameters);
        Assert.Equal(1, parameters.Count);
        Assert.Equal("b", parameters[0].Assembly);
        Assert.Equal("c", parameters[0].TypeName);
        Assert.NotNull(parameters[0].GenericParameters);
        Assert.NotEmpty(parameters[0].GenericParameters);
        Assert.Equal(1, parameters[0].GenericParameters.Count);
        Assert.Equal("d", parameters[0].GenericParameters[0].Assembly);
        Assert.Equal("e", parameters[0].GenericParameters[0].TypeName);
        Assert.Null(parameters[0].GenericParameters[0].GenericParameters);
    }

    [Fact]
    public void DoubleGeneric()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c<d|e>,f|g>");

        Assert.Equal("a", parsedTypeName.TypeName);
        Assert.Null(parsedTypeName.Assembly);
        var parameters = parsedTypeName.GenericParameters;
        Assert.NotNull(parameters);
        Assert.NotEmpty(parameters);
        Assert.Equal(2, parameters.Count);
        Assert.Equal("b", parameters[0].Assembly);
        Assert.Equal("c", parameters[0].TypeName);
        Assert.NotNull(parameters[0].GenericParameters);
        Assert.NotEmpty(parameters[0].GenericParameters);
        Assert.Equal(1, parameters[0].GenericParameters.Count);
        Assert.Equal("d", parameters[0].GenericParameters[0].Assembly);
        Assert.Equal("e", parameters[0].GenericParameters[0].TypeName);
        Assert.Null(parameters[0].GenericParameters[0].GenericParameters);
        Assert.Equal("f", parameters[1].Assembly);
        Assert.Equal("g", parameters[1].TypeName);
        Assert.Null(parameters[1].GenericParameters);
    }

    [Theory]
    [InlineData("<")]
    [InlineData("a<<")]
    [InlineData("a<b|<")]
    [InlineData("a<b|c,<")]
    public void GenericStartWithoutTypeName(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Expected a name, got <", exception.Message);
    }

    [Theory]
    [InlineData(">")]
    [InlineData("a<>")]
    [InlineData("a<b|>")]
    [InlineData("a<b|c,>")]
    public void GenericEndWithoutTypeName(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Expected a name, got >", exception.Message);
    }

    [Theory]
    [InlineData("|")]
    [InlineData("a<|")]
    [InlineData("a<b||")]
    [InlineData("a<b|c,|")]
    public void AssemblySeparatorWithoutTypeName(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Expected a name, got |", exception.Message);
    }

    [Theory]
    [InlineData(",")]
    [InlineData("a<,")]
    [InlineData("a<b|,")]
    [InlineData("a<b|c,,")]
    public void GenericParamSeparatorWithoutTypeName(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Expected a name, got ,", exception.Message);
    }

    [Fact]
    public void UnrecognizedEscapeSequence()
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse("\\a"));
        Assert.Equal("Unrecognized escape sequence '\\a'", exception.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a<")]
    [InlineData("a<b|")]
    public void EmptyTypeName(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Expected a name, got <end of type>", exception.Message);
    }

    [Fact]
    public void UnbalancedTypeSpec_AssemblyName()
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse("a<b"));
        Assert.Equal("Expected assembly name separator, got <end of type>", exception.Message);
    }

    [Fact]
    public void UnbalancedTypeSpec_TypeName()
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse("a<b|c"));
        Assert.Equal("Unbalanced type specification, are you missing a >?", exception.Message);
    }

    [Theory]
    [InlineData("a|b")]
    [InlineData("a<b|c>|")]
    [InlineData("a<b|c<d|e>|")]
    public void UnexpectedAssemblyNameSeparator(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Unexpected assembly name separator", exception.Message);
    }

    [Fact]
    public void GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeStart()
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse("a<b<"));
        Assert.Equal("Expected assembly name separator, got <", exception.Message);
    }

    [Fact]
    public void GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeEnd()
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse("a<b>"));
        Assert.Equal("Expected assembly name separator, got >", exception.Message);
    }

    [Fact]
    public void GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeSeparator()
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse("a<b,"));
        Assert.Equal("Expected assembly name separator, got ,", exception.Message);
    }

    [Theory]
    [InlineData("a<b|c>d")]
    [InlineData("a<b|c<d|e>f")]
    public void UnexpectedNameToken(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Unexpected name token", exception.Message);
    }

    [Theory]
    [InlineData("a<b|c>,")]
    [InlineData("a<b|c<d|e>>,")]
    public void UnexpectedGenericTypeSeparator(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Unexpected generic param separator", exception.Message);
    }

    [Theory]
    [InlineData("a<b|c>>")]
    [InlineData("a<b|c<d|e>>>")]
    public void UnexpectedGenericTypeEnd(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Unexpected generic type end", exception.Message);
    }

    [Theory]
    [InlineData("a<b|c><")]
    [InlineData("a<b|c<d|e><")]
    public void UnexpectedGenericTypeStart(string typeName)
    {
        var exception = Assert.Throws<WeavingException>(() => TypeNameParser.Parse(typeName));
        Assert.Equal("Unexpected generic type start", exception.Message);
    }

    public TypeNameParserTests(ITestOutputHelper output) : 
        base(output)
    {
    }
}