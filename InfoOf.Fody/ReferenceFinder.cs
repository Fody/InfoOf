public partial class ModuleWeaver
{
    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "System.Reflection";
    }

    public void FindReferences()
    {
        var methodBaseType = FindTypeDefinition("MethodBase");
        getMethodFromHandle = methodBaseType.Methods
            .First(_ => _.Name == "GetMethodFromHandle" &&
                        _.Parameters.Count == 1 &&
                        _.Parameters[0].ParameterType.Name == "RuntimeMethodHandle");
        getMethodFromHandle = ModuleDefinition.ImportReference(getMethodFromHandle);
        getMethodFromHandleGeneric = methodBaseType.Methods
            .First(_ => _.Name == "GetMethodFromHandle" &&
                        _.Parameters.Count == 2 &&
                        _.Parameters[0].ParameterType.Name == "RuntimeMethodHandle" &&
                        _.Parameters[1].ParameterType.Name == "RuntimeTypeHandle");
        getMethodFromHandleGeneric = ModuleDefinition.ImportReference(getMethodFromHandleGeneric);

        var fieldInfoType = FindTypeDefinition("FieldInfo");
        getFieldFromHandle = fieldInfoType.Methods
            .First(_ => _.Name == "GetFieldFromHandle" &&
                        _.Parameters.Count == 1 &&
                        _.Parameters[0].ParameterType.Name == "RuntimeFieldHandle");
        getFieldFromHandle = ModuleDefinition.ImportReference(getFieldFromHandle);
        getFieldFromHandleGeneric = fieldInfoType.Methods
            .First(_ => _.Name == "GetFieldFromHandle" &&
                        _.Parameters.Count == 2 &&
                        _.Parameters[0].ParameterType.Name == "RuntimeFieldHandle" &&
                        _.Parameters[1].ParameterType.Name == "RuntimeTypeHandle");
        getFieldFromHandleGeneric = ModuleDefinition.ImportReference(getFieldFromHandleGeneric);

        methodInfoType = FindTypeDefinition("MethodInfo");
        methodInfoType = ModuleDefinition.ImportReference(methodInfoType);

        constructorInfoType = FindTypeDefinition("ConstructorInfo");
        constructorInfoType = ModuleDefinition.ImportReference(constructorInfoType);

        propertyInfoType = FindTypeDefinition("PropertyInfo");
        propertyInfoType = ModuleDefinition.ImportReference(propertyInfoType);

        var typeType = FindTypeDefinition("Type");
        getTypeFromHandle = typeType.Methods
            .First(_ => _.Name == "GetTypeFromHandle" &&
                        _.Parameters.Count == 1 &&
                        _.Parameters[0].ParameterType.Name == "RuntimeTypeHandle");
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