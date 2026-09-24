// ReSharper disable UnusedMember.Local

public class MultiLayerNestedClass
{
    [Test]
    public async Task Simple()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var method = target.FindMethodDefinitions("Method",null);
        await Assert.That(method).IsNotNull();
    }

    [Test]
    public async Task SimpleWithParam()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var method = target.FindMethodDefinitions("Method", ["Nested2"]);
        await Assert.That(method).IsNotNull();
    }

    [Test]
    public async Task Full()
    {
        var target = TypeFinder.Find<MultiLayerNestedClass>();
        var method = target.FindMethodDefinitions("Method", ["MultiLayerNestedClass/Nested/Nested2"]);
        await Assert.That(method).IsNotNull();
    }

    public class Nested
    {
        public class Nested2;
    }

    // ReSharper disable once UnusedParameter.Local
    void Method(Nested.Nested2 param)
    {
    }
}