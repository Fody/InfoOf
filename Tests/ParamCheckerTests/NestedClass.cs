using MyNamespace;

// ReSharper disable UnusedMember.Local

public class NestedClass
{
    [Test]
    public async Task Simple()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method",null);
        await Assert.That(method).IsNotNull();
    }
    [Test]
    public async Task SimpleParam()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method", ["Nested"]);
        await Assert.That(method).IsNotNull();
    }

    [Test]
    public async Task Full()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method", ["Root/Nested"]);
        await Assert.That(method).IsNotNull();
    }

    [Test]
    public async Task FullWithNamespace()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method", ["MyNamespace.Root/Nested"]);
        await Assert.That(method).IsNotNull();
    }

    // ReSharper disable once UnusedParameter.Local
    void Method(Root.Nested param)
    {

    }
}

namespace MyNamespace
{
    public class Root
    {
        public class Nested;
    }
}