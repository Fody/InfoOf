using System.Reflection;
using Fody;

public partial class IntegrationTests
{
    static Assembly assembly;
    static TestResult testResult;

    static IntegrationTests()
    {
        var weaver = new ModuleWeaver();
#if(NETFRAMEWORK)
        testResult = weaver.ExecuteTestRun("AssemblyToProcess.dll", ignoreCodes:new []{ "0x80131869"});
#else
        testResult = weaver.ExecuteTestRun("AssemblyToProcess.dll", runPeVerify: false);
#endif
        assembly = testResult.Assembly;
    }

    [Fact]
    public void GenericPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertyGetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetPropertyTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertySetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetPropertyTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertyGetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetPropertyTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertySetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetPropertyTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceFieldGeneric();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericFieldTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceFieldTyped();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericStaticField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericStaticFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticFieldGeneric();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericStaticFieldTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticFieldTyped();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GetSystemGeneric()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSystemGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethodGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericMethodTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethodTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethodGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticMethodTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethodTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericTypeInfo()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfo();
        Assert.NotNull(typeInfo);
    }

    [Fact]
    public void GenericTypeInfoGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfoGeneric();
        Assert.NotNull(typeInfo);

        var genericParams = typeInfo.GenericTypeArguments;
        Assert.NotNull(genericParams);
        Assert.NotEmpty(genericParams);
        Assert.Equal(typeof(IDictionary<string, int>), genericParams[0]);
    }

    [Fact]
    public void InstancePropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstancePropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void StaticPropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void StaticPropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PropertyGetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PropertySetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void StaticField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void FieldClassWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void InstanceMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceMethodWithParams()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithParams();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceMethodWithParamsOmitted()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceMethodWithParamsTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithParamsTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceMethodWithSimpleGenericParamsTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithSimpleGenericParamsTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceMethodWithComplexGenericParamsTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithComplexGenericParamsTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void StaticMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void MethodWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void TypeInfo()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfo();
        Assert.NotNull(typeInfo);
    }

    [Fact]
    public void TypeInfoFromInternal()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfoFromInternal();
        Assert.NotNull(typeInfo);
    }

    [Fact]
    public void InstanceConstructor()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        Assert.NotNull(constructorInfo);
        Assert.Empty(constructorInfo.GetParameters());
    }

    [Fact]
    public void InstanceConstructorWithParam()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithParam();
        Assert.NotNull(constructorInfo);
    }
    [Fact]
    public void GetConstructorInfoWithMultipleParam()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithMultipleParam();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void InstanceConstructorWithParamTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithParamTyped();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void GetStringIndexerGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerSet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerSet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerGetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerGetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerSetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerSetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerGet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerGet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerSet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerSet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSet();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerGetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerGetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetStringIndexerSetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GetIntIndexerSetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSetTyped();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericConstructor()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void GenericConstructorGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoGeneric();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void GenericConstructorTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoTyped();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void GetListField()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetListField();
        Assert.NotNull(info);
    }

    [Fact]
    public void GetListMethod()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetListMethod();
        Assert.NotNull(info);
    }

    [Fact]
    public void GetListProperty()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetListProperty();
        Assert.NotNull(info);
    }
}