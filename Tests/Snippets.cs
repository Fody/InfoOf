public class Snippets
{
    void Usage()
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

        var getIndexer = Info.OfIndexerGet("AssemblyName", "MyClass", "Int32");
        var getIndexerTyped = Info.OfIndexerGet<MyClass>("Int32");

        var setIndexer = Info.OfIndexerSet("AssemblyName", "MyClass", "Int32");
        var setIndexerTyped = Info.OfIndexerSet<MyClass>("Int32");

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

var getIndexer = methodof(MyClass.get_Item);
var getIndexerTyped = methodof(MyClass.get_Item);

var setIndexer = methodof(MyClass.set_Item);
var setIndexerTyped = methodof(MyClass.set_Item);

#endregion
*/
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