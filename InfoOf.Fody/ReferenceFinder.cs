using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

public partial class ModuleWeaver
{

    public void FindReferences()
    {
        var coreTypes = new List<TypeDefinition>();
        AppendTypes("mscorlib", coreTypes);
        AppendTypes("System.Reflection", coreTypes);
        AppendTypes("System.Runtime", coreTypes);
        AppendTypes("System.Core", coreTypes);
        AppendTypes("netstandard", coreTypes);
        AppendTypes("System.Private.CoreLib", coreTypes);

        var methodBaseType = coreTypes.First(x => x.Name == "MethodBase");
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

        var fieldInfoType = coreTypes.First(x => x.Name == "FieldInfo");
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

        methodInfoType = coreTypes.First(x => x.Name == "MethodInfo");
        methodInfoType = ModuleDefinition.ImportReference(methodInfoType);

        propertyInfoType = coreTypes.First(x => x.Name == "PropertyInfo");
        propertyInfoType = ModuleDefinition.ImportReference(propertyInfoType);

        var typeType = coreTypes.First(x => x.Name == "Type");
        getTypeFromHandle = typeType.Methods
            .First(x => x.Name == "GetTypeFromHandle" &&
                        x.Parameters.Count == 1 &&
                        x.Parameters[0].ParameterType.Name == "RuntimeTypeHandle");
        getTypeFromHandle = ModuleDefinition.ImportReference(getTypeFromHandle);
    }

    void AppendTypes(string name, List<TypeDefinition> coreTypes)
    {
        var definition = AssemblyResolver.Resolve(new AssemblyNameReference(name, null));
        if (definition != null)
        {
            coreTypes.AddRange(definition.MainModule.Types);
        }
    }

    MethodReference getMethodFromHandle;
    MethodReference getTypeFromHandle;
    TypeReference methodInfoType;
    TypeReference propertyInfoType;
    MethodReference getFieldFromHandle;
    MethodReference getFieldFromHandleGeneric;
    MethodReference getMethodFromHandleGeneric;
}