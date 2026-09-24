public class GenericTypeParameters
{
    [Test]
    public async Task FindMethodWithGenericParameters()
    {
        var target = TypeFinder.Find<GenericTypeParameters>();
        var methodDefinition = target.FindMethodDefinitions("Method", ["System.Collections.Generic.Dictionary`2<System.Int32,System.String>"]);
        await Assert.That(methodDefinition).IsNotNull();
        await Assert.That(methodDefinition.FullName).IsEqualTo("System.Void GenericTypeParameters::Method(System.Collections.Generic.Dictionary`2<System.Int32,System.String>)");
    }

    void Method() => throw new NotImplementedException();

    void Method(int param) => throw new NotImplementedException();

    void Method(Dictionary<int, string> param) => throw new NotImplementedException();
}

