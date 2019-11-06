using Xunit;
using Xunit.Abstractions;

public class Snippets :
    XunitApprovalBase
{
    [Fact]
    public void Usage()
    {
        #region usage

        var type = Info.OfType("AssemblyName", "MyClass");

        var method = Info.OfMethod("AssemblyName", "MyClass", "MyMethod");
        var methodTyped = Info.OfMethod<MyClass>("MyMethod");

        var constructor = Info.OfConstructor("AssemblyName", "MyClass");
        var constructorTyped = Info.OfConstructor<MyClass>();

        var getProperty = Info.OfPropertyGet("AssemblyName", "MyClass", "MyProperty");
        var getPropertyTyped = Info.OfPropertyGet<MyClass>("MyProperty");

        var setProperty = Info.OfPropertySet("AssemblyName", "MyClass", "MyProperty");
        var setPropertyTyped = Info.OfPropertySet<MyClass>("MyProperty");

        var field = Info.OfField("AssemblyName", "MyClass", "myField");
        var fieldTyped = Info.OfField<MyClass>("myField");

        #endregion

/*
#region UsageCompiled

var type = typeof(MyClass);

var method = methodof(MyClass.MyMethod);
var methodTyped = methodof(MyClass.MyMethod);

var constructor = methodof(MyClass..ctor);
var constructorTyped = methodof(MyClass..ctor);

var getProperty = methodof(MyClass.get_MyProperty);
var getPropertyTyped = methodof(MyClass.get_MyProperty);

var setProperty = methodof(MyClass.set_MyProperty);
var setPropertyTyped = methodof(MyClass.set_MyProperty);

var field = fieldof(MyClass.myField);
var fieldTyped = fieldof(MyClass.myField);

#endregion
*/
    }

    public Snippets(ITestOutputHelper output) :
        base(output)
    {
    }
}

public class MyClass
{
    public string MyProperty { get; set; }

    public void MyMethod()
    {
    }

    public string myField;
}