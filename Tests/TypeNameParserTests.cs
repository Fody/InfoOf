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

    [Test]
    public void GenericStartWithoutTypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse("<");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got <"));
    }

    [Test]
    public void GenericEndWithoutTypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse(">");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got >"));
    }

    [Test]
    public void AssemblySeparatorWithoutTypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse("|");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected a name, got |"));
    }

    [Test]
    public void GenericParamSeparatorWithoutTypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse(",");

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

    [Test]
    public void EmptyTypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse("");

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

    [Test]
    public void UnexpectedAssemblyNameSeparator_TypeName()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a|b");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected assembly name separator"));
    }

    [Test]
    public void UnexpectedAssemblyNameSeparator_GenericParameter()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b|c<d|e>|");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected assembly name separator"));
    }

    [Test]
    public void GenericTypeMissingAssemblyNameSeparator()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b<");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Expected assembly name separator, got <"));
    }

    [Test]
    public void UnexpectedNameToken()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b|c>d");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected name token"));
    }

    [Test]
    public void UnexpectedGenericTypeSeparator()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b|c>,");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected generic param separator"));
    }

    [Test]
    public void UnexpectedGenericTypeEnd()
    {
        TestDelegate handler = () => TypeNameParser.Parse("a<b|c>>");

        Assert.That(handler, Throws.InstanceOf<WeavingException>()
            .With.Message.EqualTo("Unexpected generic type end"));
    }
}
