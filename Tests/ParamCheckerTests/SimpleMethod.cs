using System.Collections.Generic;
using Xunit;

// ReSharper disable UnusedMember.Local

public class SimpleMethod
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var methodDefinitions = target.FindMethodDefinitions("Method", null);
        Assert.Single(methodDefinitions);
    }

    [Fact]
    public void SimpleParam()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var methodDefinitions = target.FindMethodDefinitions("MethodWithParam", new List<string> { "System.Int32" });
        Assert.Single(methodDefinitions);
    }
    [Fact]
    public void BadNamespace()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var methodDefinitions = target.FindMethodDefinitions("MethodWithParam", new List<string> { "System2.Int32" });
        Assert.Empty(methodDefinitions);
    }

    void Method()
    {
    }

    [Fact]
    public void WithParam()
    {
        var methodDefinitions = TypeFinder.Find<SimpleMethod>().FindMethodDefinitions("MethodWithParam", null);
        Assert.Single(methodDefinitions);
    }

    // ReSharper disable once UnusedParameter.Local
    void MethodWithParam(int param)
    {
    }
}