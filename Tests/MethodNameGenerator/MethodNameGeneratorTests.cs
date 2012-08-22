using System.Linq;
using Mono.Cecil;
using NUnit.Framework;

[TestFixture]
public class MethodNameGeneratorTests
{
    ModuleDefinition moduleDefinition;


    public MethodNameGeneratorTests()
        {
             moduleDefinition = ModuleDefinition.ReadModule(GetType().Assembly.CodeBase.Replace("file:///", ""));
        }

    MethodDefinition GetMethod<T>(string method)
    {
        var typeDefinition = moduleDefinition.GetTypes().First(x => x.Name == typeof(T).Name);
        return typeDefinition.Methods.First(x => x.Name == method);
    }

    [Test]
    public void SimpleMethodTest()
    {
        var methodDefinition = GetMethod<SimpleClass>("SimpleMethod");
        Assert.AreEqual("SimpleClass.SimpleMethod()", methodDefinition.FullName());
    }

}