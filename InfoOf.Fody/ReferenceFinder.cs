using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

public partial class ModuleWeaver
{
    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "mscorlib";
        yield return "System.Reflection";
        yield return "System.Runtime";
        yield return "System.Core";
        yield return "netstandard";
        yield return "System.Private.CoreLib";
    }

    public void FindReferences()
    {
        var methodBaseType = FindType("MethodBase");
        getMethodFromHandle = methodBaseType.Methods
            .First(x => x.Name == "GetMethodFromHandle" &&
                        x.Parameters.Count == 1 &&
                        x.Parameters[0].ParameterType.Name == "RuntimeMethodHandle");
        getMethodFromHandle = ModuleDefinition.ImportReference(getMethodFromHandle);
        getMethodFromHandleGeneric = methodBaseType.Methods
            .First(x => x.Name == "GetMethodFromHandle" &&
                        x.Parameters.Count == 2 &&
                        x.Parameters[0].ParameterType.Name == "RuntimeMethodHandle" &&
                        x.Parameters[1].ParameterType.Name == "RuntimeTypeHandle");
        getMethodFromHandleGeneric = ModuleDefinition.ImportReference(getMethodFromHandleGeneric);

        var fieldInfoType = FindType("FieldInfo");
        getFieldFromHandle = fieldInfoType.Methods
            .First(x => x.Name == "GetFieldFromHandle" &&
                        x.Parameters.Count == 1 &&
                        x.Parameters[0].ParameterType.Name == "RuntimeFieldHandle");
        getFieldFromHandle = ModuleDefinition.ImportReference(getFieldFromHandle);
        getFieldFromHandleGeneric = fieldInfoType.Methods
            .First(x => x.Name == "GetFieldFromHandle" &&
                        x.Parameters.Count == 2 &&
                        x.Parameters[0].ParameterType.Name == "RuntimeFieldHandle" &&
                        x.Parameters[1].ParameterType.Name == "RuntimeTypeHandle");
        getFieldFromHandleGeneric = ModuleDefinition.ImportReference(getFieldFromHandleGeneric);

        methodInfoType = FindType("MethodInfo");
        methodInfoType = ModuleDefinition.ImportReference(methodInfoType);

        constructorInfoType = FindType("ConstructorInfo");
        constructorInfoType = ModuleDefinition.ImportReference(constructorInfoType);

        propertyInfoType = FindType("PropertyInfo");
        propertyInfoType = ModuleDefinition.ImportReference(propertyInfoType);

        var typeType = FindType("Type");
        getTypeFromHandle = typeType.Methods
            .First(x => x.Name == "GetTypeFromHandle" &&
                        x.Parameters.Count == 1 &&
                        x.Parameters[0].ParameterType.Name == "RuntimeTypeHandle");
        getTypeFromHandle = ModuleDefinition.ImportReference(getTypeFromHandle);
    }

    MethodReference getMethodFromHandle;
    MethodReference getTypeFromHandle;
    TypeReference methodInfoType;
    TypeReference constructorInfoType;
    TypeReference propertyInfoType;
    MethodReference getFieldFromHandle;
    MethodReference getFieldFromHandleGeneric;
    MethodReference getMethodFromHandleGeneric;
}