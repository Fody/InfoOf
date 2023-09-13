using Fody;

// ReSharper disable UnusedMember.Local

public class SimpleMethod
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var method = target.FindMethodDefinitions("Method", null);
        Assert.NotNull(method);
    }

    [Fact]
    public void SimpleParam()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var method = target.FindMethodDefinitions("MethodWithParam", new List<string> { "System.Int32" });
        Assert.NotNull(method);
    }

    [Fact]
    public void BadNamespace()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        Assert.Throws<WeavingException>(() => target.FindMethodDefinitions("MethodWithParam", new List<string> {"System2.Int32"}));
    }

    void Method()
    {
    }

    [Fact]
    public void WithParam()
    {
        var method = TypeFinder.Find<SimpleMethod>().FindMethodDefinitions("MethodWithParam", null);
        Assert.NotNull(method);
    }

    // ReSharper disable once UnusedParameter.Local
    void MethodWithParam(int param)
    {
    }
}