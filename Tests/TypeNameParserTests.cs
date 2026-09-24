using Fody;

public class TypeNameParserTests
{
    [Test]
    public async Task Simple()
    {
        var parsedTypeName = TypeNameParser.Parse("a");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo("a");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        await Assert.That(parsedTypeName.GenericParameters).IsNull();
    }

    [Test]
    public async Task SimpleWithSpecialChars()
    {
        var parsedTypeName = TypeNameParser.Parse(@"\<\>\|\,\\\ ");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo(@"<>|,\ ");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        await Assert.That(parsedTypeName.GenericParameters).IsNull();
    }

    [Test]
    public async Task SimpleIgnoresWhiteSpace()
    {
        var parsedTypeName = TypeNameParser.Parse(" \ta\r\n");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo("a");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        await Assert.That(parsedTypeName.GenericParameters).IsNull();
    }

    [Test]
    public async Task Generic()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c>");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo("a");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        var parameters = parsedTypeName.GenericParameters;
        await Assert.That(parameters).IsNotNull();
        await Assert.That(parameters).IsNotEmpty();
        await Assert.That(parameters).HasSingleItem();
        await Assert.That(parameters[0].Assembly).IsEqualTo("b");
        await Assert.That(parameters[0].TypeName).IsEqualTo("c");
        await Assert.That(parameters[0].GenericParameters).IsNull();
    }

    [Test]
    public async Task MultipleGeneric()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c,d|e>");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo("a");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        var parameters = parsedTypeName.GenericParameters;
        await Assert.That(parameters).IsNotNull();
        await Assert.That(parameters).IsNotEmpty();
        await Assert.That(parameters.Count).IsEqualTo(2);
        await Assert.That(parameters[0].Assembly).IsEqualTo("b");
        await Assert.That(parameters[0].TypeName).IsEqualTo("c");
        await Assert.That(parameters[0].GenericParameters).IsNull();
        await Assert.That(parameters[1].Assembly).IsEqualTo("d");
        await Assert.That(parameters[1].TypeName).IsEqualTo("e");
        await Assert.That(parameters[1].GenericParameters).IsNull();
    }

    [Test]
    public async Task TwoLevelsDeep()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c<d|e>>");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo("a");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        var parameters = parsedTypeName.GenericParameters;
        await Assert.That(parameters).IsNotNull();
        await Assert.That(parameters).IsNotEmpty();
        await Assert.That(parameters).HasSingleItem();
        await Assert.That(parameters[0].Assembly).IsEqualTo("b");
        await Assert.That(parameters[0].TypeName).IsEqualTo("c");
        await Assert.That(parameters[0].GenericParameters).IsNotNull();
        await Assert.That(parameters[0].GenericParameters).IsNotEmpty();
        await Assert.That(parameters[0].GenericParameters).HasSingleItem();
        await Assert.That(parameters[0].GenericParameters[0].Assembly).IsEqualTo("d");
        await Assert.That(parameters[0].GenericParameters[0].TypeName).IsEqualTo("e");
        await Assert.That(parameters[0].GenericParameters[0].GenericParameters).IsNull();
    }

    [Test]
    public async Task DoubleGeneric()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c<d|e>,f|g>");

        await Assert.That(parsedTypeName.TypeName).IsEqualTo("a");
        await Assert.That(parsedTypeName.Assembly).IsNull();
        var parameters = parsedTypeName.GenericParameters;
        await Assert.That(parameters).IsNotNull();
        await Assert.That(parameters).IsNotEmpty();
        await Assert.That(parameters.Count).IsEqualTo(2);
        await Assert.That(parameters[0].Assembly).IsEqualTo("b");
        await Assert.That(parameters[0].TypeName).IsEqualTo("c");
        await Assert.That(parameters[0].GenericParameters).IsNotNull();
        await Assert.That(parameters[0].GenericParameters).IsNotEmpty();
        await Assert.That(parameters[0].GenericParameters).HasSingleItem();
        await Assert.That(parameters[0].GenericParameters[0].Assembly).IsEqualTo("d");
        await Assert.That(parameters[0].GenericParameters[0].TypeName).IsEqualTo("e");
        await Assert.That(parameters[0].GenericParameters[0].GenericParameters).IsNull();
        await Assert.That(parameters[1].Assembly).IsEqualTo("f");
        await Assert.That(parameters[1].TypeName).IsEqualTo("g");
        await Assert.That(parameters[1].GenericParameters).IsNull();
    }

    [Test]
    [Arguments("<")]
    [Arguments("a<<")]
    [Arguments("a<b|<")]
    [Arguments("a<b|c,<")]
    public async Task GenericStartWithoutTypeName(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected a name, got <");
    }

    [Test]
    [Arguments(">")]
    [Arguments("a<>")]
    [Arguments("a<b|>")]
    [Arguments("a<b|c,>")]
    public async Task GenericEndWithoutTypeName(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected a name, got >");
    }

    [Test]
    [Arguments("|")]
    [Arguments("a<|")]
    [Arguments("a<b||")]
    [Arguments("a<b|c,|")]
    public async Task AssemblySeparatorWithoutTypeName(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected a name, got |");
    }

    [Test]
    [Arguments(",")]
    [Arguments("a<,")]
    [Arguments("a<b|,")]
    [Arguments("a<b|c,,")]
    public async Task GenericParamSeparatorWithoutTypeName(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected a name, got ,");
    }

    [Test]
    public async Task UnrecognizedEscapeSequence()
    {
        var exception = await Assert.That(() => TypeNameParser.Parse("\\a")).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unrecognized escape sequence '\\a'");
    }

    [Test]
    [Arguments("")]
    [Arguments("a<")]
    [Arguments("a<b|")]
    public async Task EmptyTypeName(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected a name, got <end of type>");
    }

    [Test]
    public async Task UnbalancedTypeSpec_AssemblyName()
    {
        var exception = await Assert.That(() => TypeNameParser.Parse("a<b")).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected assembly name separator, got <end of type>");
    }

    [Test]
    public async Task UnbalancedTypeSpec_TypeName()
    {
        var exception = await Assert.That(() => TypeNameParser.Parse("a<b|c")).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unbalanced type specification, are you missing a >?");
    }

    [Test]
    [Arguments("a|b")]
    [Arguments("a<b|c>|")]
    [Arguments("a<b|c<d|e>|")]
    public async Task UnexpectedAssemblyNameSeparator(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unexpected assembly name separator");
    }

    [Test]
    public async Task GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeStart()
    {
        var exception = await Assert.That(() => TypeNameParser.Parse("a<b<")).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected assembly name separator, got <");
    }

    [Test]
    public async Task GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeEnd()
    {
        var exception = await Assert.That(() => TypeNameParser.Parse("a<b>")).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected assembly name separator, got >");
    }

    [Test]
    public async Task GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeSeparator()
    {
        var exception = await Assert.That(() => TypeNameParser.Parse("a<b,")).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Expected assembly name separator, got ,");
    }

    [Test]
    [Arguments("a<b|c>d")]
    [Arguments("a<b|c<d|e>f")]
    public async Task UnexpectedNameToken(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unexpected name token");
    }

    [Test]
    [Arguments("a<b|c>,")]
    [Arguments("a<b|c<d|e>>,")]
    public async Task UnexpectedGenericTypeSeparator(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unexpected generic param separator");
    }

    [Test]
    [Arguments("a<b|c>>")]
    [Arguments("a<b|c<d|e>>>")]
    public async Task UnexpectedGenericTypeEnd(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unexpected generic type end");
    }

    [Test]
    [Arguments("a<b|c><")]
    [Arguments("a<b|c<d|e><")]
    public async Task UnexpectedGenericTypeStart(string typeName)
    {
        var exception = await Assert.That(() => TypeNameParser.Parse(typeName)).Throws<WeavingException>();
        await Assert.That(exception!.Message).IsEqualTo("Unexpected generic type start");
    }
}