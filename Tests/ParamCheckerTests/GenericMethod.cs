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

    void Method<T>()
    {
    }
}