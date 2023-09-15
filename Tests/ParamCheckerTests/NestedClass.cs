using MyNamespace;

// ReSharper disable UnusedMember.Local

public class NestedClass
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method",null);
        Assert.NotNull(method);
    }
    [Fact]
    public void SimpleParam()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method", new() { "Nested" });
        Assert.NotNull(method);
    }

    [Fact]
    public void Full()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method", new() { "Root/Nested" });
        Assert.NotNull(method);
    }

    [Fact]
    public void FullWithNamespace()
    {
        var target = TypeFinder.Find<NestedClass>();
        var method = target.FindMethodDefinitions("Method", new() { "MyNamespace.Root/Nested" });
        Assert.NotNull(method);
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