using System.Collections.Generic;
using Xunit;

// ReSharper disable UnusedMember.Local

public class MultiLayerNestedClass
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var method = target.FindMethodDefinitions("Method",null);
        Assert.NotNull(method);
    }

    [Fact]
    public void SimpleWithParam()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var method = target.FindMethodDefinitions("Method", new List<string> { "Nested2" });
        Assert.NotNull(method);
    }

    [Fact]
    public void Full()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var method = target.FindMethodDefinitions("Method", new List<string> { "MultiLayerNestedClass/Nested/Nested2" });
        Assert.NotNull(method);
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