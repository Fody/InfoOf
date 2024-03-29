// ReSharper disable UnusedMember.Local

public class GenericMethod
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("Method", null);
        Assert.NotNull(methodDefinition);
    }

    [Fact]
    public void MethodWithOverloadBasic()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("MethodWithOverload", null);
        Assert.NotNull(methodDefinition);
        Assert.Equal("System.Void GenericMethod::MethodWithOverload()", methodDefinition.FullName);
        // This will find the generic method first, as it's the first in the class definition.
        // There is no way distinguishing generic and non generic methods with the same parameters.
        Assert.True(methodDefinition.HasGenericParameters);
    }

    [Fact]
    public void MethodWithOverloadParam()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("MethodWithOverload", ["System.Int32"]);
        Assert.NotNull(methodDefinition);
        Assert.Equal("System.Void GenericMethod::MethodWithOverload(System.Int32)", methodDefinition.FullName);
        Assert.False(methodDefinition.HasGenericParameters);
    }

    [Fact]
    public void MethodWithOverloadGenericParam()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinition = target.FindMethodDefinitions("MethodWithOverload", ["T"]);
        Assert.NotNull(methodDefinition);
        Assert.Equal("System.Void GenericMethod::MethodWithOverload(T)", methodDefinition.FullName);
        Assert.True(methodDefinition.HasGenericParameters);
    }


    void Method<T>() => throw new NotImplementedException();

    void MethodWithOverload<T>() => throw new NotImplementedException();

    void MethodWithOverload() => throw new NotImplementedException();

    void MethodWithOverload(int param) => throw new NotImplementedException();

    void MethodWithOverload<T>(T param) => throw new NotImplementedException();
}