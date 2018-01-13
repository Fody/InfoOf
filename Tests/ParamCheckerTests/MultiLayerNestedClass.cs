using System.Collections.Generic;
using Xunit;

// ReSharper disable UnusedMember.Local

public class MultiLayerNestedClass
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method",null);
        Assert.Single(methodDefinitions);
    }

    [Fact]
    public void SimpleWithParam()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "Nested2" });
        Assert.Single(methodDefinitions);
    }

    [Fact]
    public void Full()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "MultiLayerNestedClass/Nested/Nested2" });
        Assert.Single(methodDefinitions);
    }

    public class Nested
    {
        public class Nested2
        {
        }
    }

    // ReSharper disable once UnusedParameter.Local
    void Method(Nested.Nested2 param)
    {
    }
}