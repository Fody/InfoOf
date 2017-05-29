[![Chat on Gitter Status](https://img.shields.io/gitter/room/fody/fody.svg?style=flat)](https://gitter.im/Fody)
[![NuGet Status](http://img.shields.io/nuget/v/InfoOf.Fody.svg?style=flat)](https://www.nuget.org/packages/InfoOf.Fody/)


## This is an add-in for [Fody](https://github.com/Fody/Fody/) 

![Icon](https://raw.github.com/Fody/InfoOf/master/Icons/package_icon.png)

Provides `methodof`, `propertyof` and `fieldof` equivalents of [`typeof`](http://msdn.microsoft.com/en-us/library/58918ffs.aspx) .

[Introduction to Fody](http://github.com/Fody/Fody/wiki/SampleUsage)

[![NuGet Status](https://img.shields.io/gitter/room/fody/fody.svg?style=flat)](https://gitter.im/Fody/Fody)

## The nuget package

https://nuget.org/packages/InfoOf.Fody/

    PM> Install-Package InfoOf.Fody


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


## Icon

<a href="http://thenounproject.com/noun/information/#icon-No9867" target="_blank">Information</a> designed by <a href="http://thenounproject.com/Fhlcreative" target="_blank">Phil Goodwin</a> from The Noun Project
