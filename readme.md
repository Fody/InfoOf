[![Chat on Gitter](https://img.shields.io/gitter/room/fody/fody.svg?style=flat&max-age=86400)](https://gitter.im/Fody/Fody) [![NuGet Status](https://img.shields.io/nuget/v/InfoOf.Fody.svg?style=flat&max-age=86400)](https://www.nuget.org/packages/InfoOf.Fody/)


## This is an add-in for [Fody](https://github.com/Fody/Home/)

![Icon](https://raw.githubusercontent.com/Fody/InfoOf/master/package_icon.png)

Provides `methodof`, `propertyof` and `fieldof` equivalents of [`typeof`](http://msdn.microsoft.com/en-us/library/58918ffs.aspx).


## Usage

See also [Fody usage](https://github.com/Fody/Home/blob/master/pages/usage.md).


### NuGet installation

Install the [InfoOf.Fody NuGet package](https://nuget.org/packages/InfoOf.Fody/) and update the [Fody NuGet package](https://nuget.org/packages/Fody/):

```powershell
PM> Install-Package Fody
PM> Install-Package InfoOf.Fody
```

The `Install-Package Fody` is required since NuGet always defaults to the oldest, and most buggy, version of any dependency.


### Add to FodyWeavers.xml

Add `<InfoOf/>` to [FodyWeavers.xml](https://github.com/Fody/Home/blob/master/pages/usage.md#add-fodyweaversxml)

```xml
<Weavers>
  <InfoOf/>
</Weavers>
```


### Your Code

```csharp
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
```


### What gets compiled

```c#
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
```


## Specifying Generic Types

The `typeName` parameter of the Info.Of* methods use the following BNF grammar:

```
<fullTypeSpec> ::= <typeName> [<genericSpec>]
<genericSpec>  ::= "<" <genericTypes> ">"
<genericTypes> ::= <genericType> ["," <genericTypes>]
<genericType>  ::= <assemblyName> "|" <fullTypeSpec>
<name>         ::= <identifier> [<name>]
<typeName>     ::= <name>
<assemblyName> ::= <name>
<identifier>   ::= <letter> | <digit> | <specialChar>
<letter>       ::= "A" | "B" | "C" | "D" | "E" | "F" | "G" | "H" | "I" | "J" | "K" | "L" | "M" |
                   "N" | "O" | "P" | "Q" | "R" | "S" | "T" | "U" | "V" | "W" | "X" | "Y" | "Z" |
                   "a" | "b" | "c" | "d" | "e" | "f" | "g" | "h" | "i" | "j" | "k" | "l" | "m" |
                   "n" | "o" | "p" | "q" | "r" | "s" | "t" | "u" | "v" | "w" | "x" | "y" | "z"
<digit>        ::= "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9"
<specialChar>  ::= "." | "`"
```

To specify a `Dictionary<int, string>`, the typeName would be `System.Collections.Generic.Dictionary``2<mscorlib|System.Int32,mscorlib|System.String>`.


### Escape Sequences

If the following chars are part of your typeName, they will need to be escaped with a "\\": `"\", "<", ">", "|", ","`.

Also, whitespace is ignored by default, so they also need to be escaped with "\\" if they are part of your typeName.


## Why not use Expressions

It would also be possible to define members and types using a combination of generics and expressions. This would allow for intellisense at code time. The problem with expressions are as  follows

 1. The conversion of expression to "infoof"s is significantly more complex. Making the solution more complex and having a negative impact on compile performance.
 1. Expressions cannot represent non public types or members.
 1. It is difficult to represent all combinations of members using expressions.


## But it is not strong typed

**Actually it is strong typed**, it just does not have intellisense. If any of the strings passed into `Info` do not map to a type or member it will log a build error and stop the build.


## Icon

[Information](https://thenounproject.com/noun/information/#icon-No9867) designed by [Phil Goodwin](https://thenounproject.com/Fhlcreative) from [The Noun Project](https://thenounproject.com).