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
	var getProperty = methodof(MyClass.get_MyProperty)
	var setProperty = methodof(MyClass.set_MyProperty)
	var field = fieldof(MyClass.myField);

## Why not use Expressions

It would also be possible to define members and types using a combination of generics and expressions. This would allow for intellisense at code time. The problem with expressions are as  follows

1. The conversion of expression to "infoof"s is significantly more complex. Making the solution more complex and having a negative impact on compile performance.
2. Expressions cannot represent non public types or members.
3. It is difficult to represent all combinations of members using expressions.

## But it is not strong typed

**Actually it is strong type**, it just does not have intellisense. If any of the strings passed into `Info` do not map to a type or member it will log a build error and stop the build.

 

 
