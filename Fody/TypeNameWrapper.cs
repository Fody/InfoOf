//using System.Collections.Generic;
//using System.Linq;
//using IKVM.Reflection;

//public static class TypeNameWrapper
//{
//    public static TypeSpec Parse(string typeName)
//    {
//        var typeNameParser = TypeNameParser.Parse(typeName, true);

//        return new TypeSpec
//            {
//                Name = typeNameParser.FirstNamePart,
//                GenericParameters = typeNameParser.genericParameters,
//                Nested = Nested(typeNameParser).ToList(),
//                AssemblyName = typeNameParser.AssemblyName
//            };
//    }

//    static IEnumerable<TypeSpec> Nested(TypeNameParser typeNameParser)
//    {
//        foreach (var nested in typeNameParser.nested)
//        {
//            yield return TypeNameWrapper.Parse(nested);
//        }
//    }
//}