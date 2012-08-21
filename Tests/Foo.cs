using System;
using NUnit.Framework;

[TestFixture]
public class Foo
{
    public string Property { get; set; }

    [Test]
    public void Bar()
    {
        var methodInfo = typeof(GenericType<,,>);
        
        Console.WriteLine(methodInfo.AssemblyQualifiedName);
    }
}
public class GenericType<T>
{
    
}
public class GenericType<T,K>
{
    
}
public class GenericType<T,K,Z>
{
    
}