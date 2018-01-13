using System.Collections.Generic;
using MyNamespace;
using Xunit;

// ReSharper disable UnusedMember.Local

public class NestedClass
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method",null);
        Assert.Single(methodDefinitions);
    }
    [Fact]
    public void SimpleParam()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "Nested" });
        Assert.Single(methodDefinitions);
    }

    [Fact]
    public void Full()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "Root/Nested" });
        Assert.Single(methodDefinitions);
    }

    [Fact]
    public void FullWithNamespace()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "MyNamespace.Root/Nested" });
        Assert.Single(methodDefinitions);
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
        public class Nested
        {
        }
    }
}