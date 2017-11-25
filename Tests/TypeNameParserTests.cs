using NUnit.Framework;

[TestFixture]
public class TypeNameParserTests
{
    [Test]
    public void Simple()
    {
        var parsedTypeName = TypeNameParser.Parse("a");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo("a"));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Null);
    }

    [Test]
    public void SimpleWithSpecialChars()
    {
        var parsedTypeName = TypeNameParser.Parse(@"\<\>\|\,\\\ ");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo(@"<>|,\ "));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Null);
    }

    [Test]
    public void SimpleIgnoresWhiteSpace()
    {
        var parsedTypeName = TypeNameParser.Parse(" \ta\r\n");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo("a"));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Null);
    }

    [Test]
    public void Generic()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c>");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo("a"));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Not.Null.Or.Empty);
        Assert.That(parsedTypeName.GenericParameters, Has.Count.EqualTo(1));
        Assert.That(parsedTypeName.GenericParameters[0].Assembly, Is.EqualTo("b"));
        Assert.That(parsedTypeName.GenericParameters[0].TypeName, Is.EqualTo("c"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters, Is.Null);
    }

    [Test]
    public void MultipleGeneric()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c,d|e>");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo("a"));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Not.Null.Or.Empty);
        Assert.That(parsedTypeName.GenericParameters, Has.Count.EqualTo(2));
        Assert.That(parsedTypeName.GenericParameters[0].Assembly, Is.EqualTo("b"));
        Assert.That(parsedTypeName.GenericParameters[0].TypeName, Is.EqualTo("c"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters, Is.Null);
        Assert.That(parsedTypeName.GenericParameters[1].Assembly, Is.EqualTo("d"));
        Assert.That(parsedTypeName.GenericParameters[1].TypeName, Is.EqualTo("e"));
        Assert.That(parsedTypeName.GenericParameters[1].GenericParameters, Is.Null);
    }

    [Test]
    public void TwoLevelsDeep()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c<d|e>>");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo("a"));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Not.Null.Or.Empty);
        Assert.That(parsedTypeName.GenericParameters, Has.Count.EqualTo(1));
        Assert.That(parsedTypeName.GenericParameters[0].Assembly, Is.EqualTo("b"));
        Assert.That(parsedTypeName.GenericParameters[0].TypeName, Is.EqualTo("c"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters, Is.Not.Null.Or.Empty);
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters, Has.Count.EqualTo(1));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters[0].Assembly, Is.EqualTo("d"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters[0].TypeName, Is.EqualTo("e"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters[0].GenericParameters, Is.Null);
    }

    [Test]
    public void DoubleGeneric()
    {
        var parsedTypeName = TypeNameParser.Parse("a<b|c<d|e>,f|g>");

        Assert.That(parsedTypeName.TypeName, Is.EqualTo("a"));
        Assert.That(parsedTypeName.Assembly, Is.Null);
        Assert.That(parsedTypeName.GenericParameters, Is.Not.Null.Or.Empty);
        Assert.That(parsedTypeName.GenericParameters, Has.Count.EqualTo(2));
        Assert.That(parsedTypeName.GenericParameters[0].Assembly, Is.EqualTo("b"));
        Assert.That(parsedTypeName.GenericParameters[0].TypeName, Is.EqualTo("c"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters, Is.Not.Null.Or.Empty);
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters, Has.Count.EqualTo(1));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters[0].Assembly, Is.EqualTo("d"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters[0].TypeName, Is.EqualTo("e"));
        Assert.That(parsedTypeName.GenericParameters[0].GenericParameters[0].GenericParameters, Is.Null);
        Assert.That(parsedTypeName.GenericParameters[1].Assembly, Is.EqualTo("f"));
        Assert.That(parsedTypeName.GenericParameters[1].TypeName, Is.EqualTo("g"));
        Assert.That(parsedTypeName.GenericParameters[1].GenericParameters, Is.Null);
    }

    [TestCase("<")]
    [TestCase("a<<")]
    [TestCase("a<b|<")]
    [TestCase("a<b|c,<")]
    public void GenericStartWithoutTypeName(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got <"));
    }

    [TestCase(">")]
    [TestCase("a<>")]
    [TestCase("a<b|>")]
    [TestCase("a<b|c,>")]
    public void GenericEndWithoutTypeName(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got >"));
    }

    [TestCase("|")]
    [TestCase("a<|")]
    [TestCase("a<b||")]
    [TestCase("a<b|c,|")]
    public void AssemblySeparatorWithoutTypeName(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got |"));
    }

    [TestCase(",")]
    [TestCase("a<,")]
    [TestCase("a<b|,")]
    [TestCase("a<b|c,,")]
    public void GenericParamSeparatorWithoutTypeName(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got ,"));
    }

    [Test]
    public void UnrecognizedEscapeSequence()
    {
        TestDelegate handler = () => TypeNameParser.Parse("\\a");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unrecognized escape sequence '\\a'"));
    }

    [TestCase("")]
    [TestCase("a<")]
    [TestCase("a<b|")]
    public void EmptyTypeName(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got <end of type>"));
    }

    [Test]
    public void UnbalancedTypeSpec_AssemblyName()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected assembly name separator, got <end of type>"));
    }

    [Test]
    public void UnbalancedTypeSpec_TypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b|c");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unbalanced type specification, are you missing a >?"));
    }

    [TestCase("a|b")]
    [TestCase("a<b|c>|")]
    [TestCase("a<b|c<d|e>|")]
    public void UnexpectedAssemblyNameSeparator(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected assembly name separator"));
    }

    [Test]
    public void GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeStart()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b<");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected assembly name separator, got <"));
    }

    [Test]
    public void GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeEnd()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b>");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected assembly name separator, got >"));
    }

    [Test]
    public void GenericTypeMissingAssemblyNameSeparator_UnexpectedGenericTypeSeparator()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b,");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected assembly name separator, got ,"));
    }

    [TestCase("a<b|c>d")]
    [TestCase("a<b|c<d|e>f")]
    public void UnexpectedNameToken(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected name token"));
    }

    [TestCase("a<b|c>,")]
    [TestCase("a<b|c<d|e>>,")]
    public void UnexpectedGenericTypeSeparator(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected generic param separator"));
    }

    [TestCase("a<b|c>>")]
    [TestCase("a<b|c<d|e>>>")]
    public void UnexpectedGenericTypeEnd(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected generic type end"));
    }

    [TestCase("a<b|c><")]
    [TestCase("a<b|c<d|e><")]
    public void UnexpectedGenericTypeStart(string typeName)
    {
        TestDelegate handler = () => TypeNameParser.Parse(typeName);

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected generic type start"));
    }
}
