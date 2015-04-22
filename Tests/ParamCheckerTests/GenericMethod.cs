using NUnit.Framework;
// ReSharper disable UnusedMember.Local

[TestFixture]
public class GenericMethod
{

    [Test]
    public void Simple()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinitions = target.FindMethodDefinitions("Method", null);
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    void Method<T>()
    {
        
    }

}