using Xunit;

// ReSharper disable UnusedMember.Local

public class GenericMethod
{
    [Fact]
    public void Simple()
    {
        var target = TypeFinder.Find<GenericMethod>();
        var methodDefinitions = target.FindMethodDefinitions("Method", null);
        Assert.Single(methodDefinitions);
    }

    void Method<T>()
    {
    }
}