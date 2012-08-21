//using System.Linq;
//using NUnit.Framework;

//[TestFixture]
//public class TypeNameParserTests
//{
//    [Test]
//    public void Simple()
//    {
//        var typeNameParser = Parser.Parse("Class1");
//        Assert.AreEqual("Class1", typeNameParser.Name);
//        Assert.IsNull(typeNameParser.AssemblyName);
//    }
//    [Test]
//    public void Generic()
//    {
//        var typeNameParser = Parser.Parse("Class1[T]");
//        Assert.AreEqual("Class1", typeNameParser.Name);
//        Assert.AreEqual("T", typeNameParser.GenericParameters.First().Name);
//    }
//    [Test]
//    public void MultipleGeneric()
//    {
//        var typeNameParser = Parser.Parse("Class1[T,K]");
//        Assert.AreEqual("Class1", typeNameParser.Name);
//        Assert.AreEqual("T", typeNameParser.GenericParameters[0].Name);
//        Assert.AreEqual("K", typeNameParser.GenericParameters[1].Name);
//    }
//    [Test]
//    public void NestedWithAssembly()
//    {
//        var typeNameParser = Parser.Parse(@"ContainingClass+NestedClass,MyAssembly");
//        Assert.AreEqual("ContainingClass", typeNameParser.Name);
//        Assert.AreEqual("MyAssembly", typeNameParser.AssemblyName);
//        Assert.AreEqual("NestedClass", typeNameParser.Nested.First());
//    }

    
//}