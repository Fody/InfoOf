using System.Collections.Generic;
using MyNamespace;
using NUnit.Framework;
// ReSharper disable UnusedMember.Local

[TestFixture]
public class NestedClass
{
    [Test]
    public void Simple()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method",null);
        Assert.AreEqual(1, methodDefinitions.Count);
    }
    [Test]
    public void SimpleParam()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "Nested" });
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void Full()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "Root/Nested" });
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void FullWithNamespace()
    {
        var target = TypeFinder.Find<NestedClass>();
        var methodDefinitions = target.FindMethodDefinitions("Method", new List<string> { "MyNamespace.Root/Nested" });
        Assert.AreEqual(1, methodDefinitions.Count);
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