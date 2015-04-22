using System.Collections.Generic;
using NUnit.Framework;
// ReSharper disable UnusedMember.Local

[TestFixture]
public class MultiLayerNestedClass
{

    [Test]
    public void Simple()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method",null);
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void SimpleWithParam()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "Nested2" });
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void Full()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "MultiLayerNestedClass/Nested/Nested2" });
        Assert.AreEqual(1, methodDefinitions.Count);
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


