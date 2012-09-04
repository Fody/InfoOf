using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class SimpleMethod
{
 
  

    [Test]
    public void Simple()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var methodDefinitions = target.FindMethodDefinitions("Method", null);
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void SimpleParam()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var methodDefinitions = target.FindMethodDefinitions("MethodWithParam", new List<string> { "System.Int32" });
        Assert.AreEqual(1, methodDefinitions.Count);
    }
    [Test]
    public void BadNamespace()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var methodDefinitions = target.FindMethodDefinitions("MethodWithParam", new List<string> { "System2.Int32" });
        Assert.AreEqual(0, methodDefinitions.Count);
    }


    void Method()
    {
        
    }

    [Test]
    public void WithParam()
    {
        var methodDefinitions = TypeFinder.Find<SimpleMethod>().FindMethodDefinitions("MethodWithParam", null);
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    void MethodWithParam(int param)
    {

    }
}