public class GenericTypeParameters
{
    [Fact]
    public void FindMethodWithGenericParameters()
    {
        var target = TypeFinder.Find<GenericTypeParameters>();
        var methodDefinition = target.FindMethodDefinitions("Method", new() { "System.Collections.Generic.Dictionary`2<System.Int32,System.String>" });
        Assert.NotNull(methodDefinition);
        Assert.Equal("System.Void GenericTypeParameters::Method(System.Collections.Generic.Dictionary`2<System.Int32,System.String>)", methodDefinition.FullName);
    }

    void Method() => throw new NotImplementedException();

    void Method(int param) => throw new NotImplementedException();

    void Method(Dictionary<int, string> param) => throw new NotImplementedException();
}

