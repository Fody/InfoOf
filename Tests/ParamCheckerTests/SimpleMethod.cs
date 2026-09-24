using Fody;

// ReSharper disable UnusedMember.Local

public class SimpleMethod
{
    [Test]
    public async Task Simple()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var method = target.FindMethodDefinitions("Method", null);
        await Assert.That(method).IsNotNull();
    }

    [Test]
    public async Task SimpleParam()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        var method = target.FindMethodDefinitions("MethodWithParam", ["System.Int32"]);
        await Assert.That(method).IsNotNull();
    }

    [Test]
    public async Task BadNamespace()
    {
        var target = TypeFinder.Find<SimpleMethod>();
        await Assert.That(() => target.FindMethodDefinitions("MethodWithParam", ["System2.Int32"])).Throws<WeavingException>();
    }

    void Method()
    {
    }

    [Test]
    public async Task WithParam()
    {
        var method = TypeFinder.Find<SimpleMethod>().FindMethodDefinitions("MethodWithParam", null);
        await Assert.That(method).IsNotNull();
    }

    // ReSharper disable once UnusedParameter.Local
    void MethodWithParam(int param)
    {
    }
}