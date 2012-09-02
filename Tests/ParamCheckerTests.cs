using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NUnit.Framework;

[TestFixture]
public class ParamCheckerTests
{
    TypeDefinition typeDefinition;
    public ParamCheckerTests()
    {
        var location = typeof(ParamCheckerTests).Assembly.CodeBase;
        location = location.Replace("file:///", "");

        typeDefinition = ModuleDefinition.ReadModule(location).GetTypes().First(x=>x.Name == "ParamCheckerTests");
    }
    
    [Test]
    public void FindSimpleMethod()
    {
        var methodDefinitions = typeDefinition.FindMethodDefinitions("SimpleMethod", null);
        Assert.AreEqual(1,methodDefinitions.Count);
    }

    [Test]
    public void FindWithParamMethod()
    {
        var methodDefinitions = typeDefinition.FindMethodDefinitions("WithParamMethod", new List<string> { "Int32" });
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void FindWithParamAndNamespace()
    {
        var methodDefinitions = typeDefinition.FindMethodDefinitions("WithParamMethod", new List<string> { "System.Int32" });
        Assert.AreEqual(1, methodDefinitions.Count);
    }

    [Test]
    public void FindWithParamAndNadNamespace()
    {
        var methodDefinitions = typeDefinition.FindMethodDefinitions("WithParamMethod", new List<string> { "System2.Int32" });
        Assert.AreEqual(0, methodDefinitions.Count);
    }

    void SimpleMethod()
    {
        
    }
    void WithParamMethod(int param)
    {
        
    }
}