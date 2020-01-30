# <img src="/package_icon.png" height="30px"> InfoOf.Fody

[![Chat on Gitter](https://img.shields.io/gitter/room/fody/fody.svg)](https://gitter.im/Fody/Fody)
[![NuGet Status](https://img.shields.io/nuget/v/InfoOf.Fody.svg)](https://www.nuget.org/packages/InfoOf.Fody/)

Provides `methodof`, `propertyof` and `fieldof` equivalents of [`typeof`](http://msdn.microsoft.com/en-us/library/58918ffs.aspx).


### This is an add-in for [Fody](https://github.com/Fody/Home/)

**It is expected that all developers using Fody either [become a Patron on OpenCollective](https://opencollective.com/fody/contribute/patron-3059), or have a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-fody?utm_source=nuget-fody&utm_medium=referral&utm_campaign=enterprise). [See Licensing/Patron FAQ](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) for more information.**


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

snippet: usage


### What gets compiled

snippet: UsageCompiled


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


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Information](https://thenounproject.com/noun/information/#icon-No9867) designed by [Phil Goodwin](https://thenounproject.com/Fhlcreative) from [The Noun Project](https://thenounproject.com).