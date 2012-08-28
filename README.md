## This is an add-in for [Fody](https://github.com/SimonCropp/Fody/) 

Provides `methodof`, `propertyof` and `fieldof` equivalents of [`typeof`](http://msdn.microsoft.com/en-us/library/58918ffs.aspx) .

[Introduction to Fody](http://github.com/SimonCropp/Fody/wiki/SampleUsage)

## Nuget package http://nuget.org/packages/InfoOf.Fody 

### Your Code

	var type = Info.OfType("AssemblyName", "MyClass");
	var method = Info.OfMethod("AssemblyName", "MyClass", "MyMethod");
	var getProperty = Info.OfPropertyGet("AssemblyName", "MyClass", "MyProperty");
	var setProperty = Info.OfPropertySet("AssemblyName", "MyClass", "MyProperty");
	var field = Info.OfField("AssemblyName", "MyClass", "myField");

### What gets compiled

	var type = typeof(MyClass);
	var method = methodof(MyClass.MyMethod);
	var getPropertyMethod = methodof(MyClass.get_MyProperty)
	var setPropertyMethod = methodof(MyClass.set_MyProperty)
	var field = fieldof(MyClass.myField);




 

 
