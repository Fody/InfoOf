# <img src="/package_icon.png" height="30px"> InfoOf.Fody

[![NuGet Status](https://img.shields.io/nuget/v/InfoOf.Fody.svg)](https://www.nuget.org/packages/InfoOf.Fody/)

Provides `methodof`, `propertyof` and `fieldof` equivalents of [`typeof`](http://msdn.microsoft.com/en-us/library/58918ffs.aspx).

**See [Milestones](../../milestones?state=closed) for release notes.**


### This is an add-in for [Fody](https://github.com/Fody/Home/)

**It is expected that all developers using Fody [become a Patron on OpenCollective](https://opencollective.com/fody/contribute/patron-3059). [See Licensing/Patron FAQ](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) for more information.**


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


### Input Code

snippet: usage


### What gets compiled

snippet: UsageCompiled

## Specifying Parameters

- Parameters are specified with their full type name
- For methods, when no parameters are specified, the method with the least number of parameters will be returned.
- Parameters are specified as comma separated list, e.g. `"System.String, System.Int32"`.
- For every parameter, the first namespace part can be omitted, so `"String, Int32"` works, too.
- Nested namespaces are not handled, only `"Regex"` won't work, but `"System.Text.RegularExpressions.Regex"` or `"Text.RegularExpressions.Regex"`.

## Finding Generic Methods

Actually there is no specific support for generic methods. Both `"Method()"` and `"Method<T>()"` will be found by the name `Method`.

If there is a non-generic method and a generic overload with the same parameter signature, only the first of both will be returned.

## Specifying Generic Types in Method Parameters

The `typeName` parameter of the Info.Of* methods use the following BNF grammar:

```
<fullTypeSpec> ::= <typeName> [<genericSpec>]
<genericSpec>  ::= "<" <genericTypes> ">"
<genericTypes> ::= <genericType> ["," <genericTypes>]
<genericType>  ::= <fullTypeSpec>
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

To specify a `Dictionary<int, string>`, the typeName would be ```System.Collections.Generic.Dictionary`2<System.Int32,System.String>```.

## Specifying Generic Parameter Types in Generic Methods
To find a method with the following signature

```c#
MyMethod<T>(T param)
```
use
```c#
Info.OfMethod<MyClass>("MyMethod", "T")
```


## Escape Sequences

If the following chars are part of the typeName, they will need to be escaped with a "\\": `"\", "<", ">", "|", ","`.

Also, whitespace is ignored by default, so they also need to be escaped with "\\" if part of the typeName.


## Why not use Expressions

It would also be possible to define members and types using a combination of generics and expressions. This would allow for intellisense at code time. The problem with expressions are as  follows

 1. The conversion of expression to "infoof"s is significantly more complex. Making the solution more complex and having a negative impact on compile performance.
 1. Expressions cannot represent non public types or members.
 1. It is difficult to represent all combinations of members using expressions.


## But it is not strong typed

**Actually it is strong typed**, it does not have intellisense. If any of the strings passed into `Info` do not map to a type or member it will log a build error and stop the build.



## Icon

[Information](https://thenounproject.com/noun/information/#icon-No9867) designed by [Phil Goodwin](https://thenounproject.com/Fhlcreative) from [The Noun Project](https://thenounproject.com).