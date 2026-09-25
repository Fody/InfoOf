// ReSharper disable UnusedMember.Local

public class GenericMethod
{
    [Test]
    public async Task Simple()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("Method", null);
        await Assert.That(methodDefinition).IsNotNull();
    }

    [Test]
    public async Task MethodWithOverloadBasic()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("MethodWithOverload", null);
        await Assert.That(methodDefinition).IsNotNull();
        await Assert.That(methodDefinition.FullName).IsEqualTo("System.Void GenericMethod::MethodWithOverload()");
        // This will find the generic method first, as it's the first in the class definition.
        // There is no way distinguishing generic and non generic methods with the same parameters.
        await Assert.That(methodDefinition.HasGenericParameters).IsTrue();
    }

    [Test]
    public async Task MethodWithOverloadParam()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("MethodWithOverload", ["System.Int32"]);
        await Assert.That(methodDefinition).IsNotNull();
        await Assert.That(methodDefinition.FullName).IsEqualTo("System.Void GenericMethod::MethodWithOverload(System.Int32)");
        await Assert.That(methodDefinition.HasGenericParameters).IsFalse();
    }

    [Test]
    public async Task MethodWithOverloadGenericParam()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("MethodWithOverload", ["T"]);
        await Assert.That(methodDefinition).IsNotNull();
        await Assert.That(methodDefinition.FullName).IsEqualTo("System.Void GenericMethod::MethodWithOverload(T)");
        await Assert.That(methodDefinition.HasGenericParameters).IsTrue();
    }


    void Method<T>() => throw new NotImplementedException();

    void MethodWithOverload<T>() => throw new NotImplementedException();

    void MethodWithOverload() => throw new NotImplementedException();

    void MethodWithOverload(int param) => throw new NotImplementedException();

    void MethodWithOverload<T>(T param) => throw new NotImplementedException();
}