using System.Reflection;
using Fody;

public partial class IntegrationTests
{
    static Assembly assembly;
    static Fody.TestResult testResult;

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

    [Test]
    public async Task GenericPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetPropertyGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericPropertyGetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetPropertyTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetPropertyGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericPropertySetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetPropertyTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetPropertyGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticPropertyGetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetPropertyTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetPropertyGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticPropertySetTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetPropertyTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task GenericFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceFieldGeneric();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task GenericFieldTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceFieldTyped();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticFieldGeneric();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticFieldTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticFieldTyped();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task GetSystemGeneric()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSystemGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethodGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericMethodTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethodTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethodGeneric();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericStaticMethodTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethodTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericTypeInfo()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfo();
        await Assert.That(typeInfo).IsNotNull();
    }

    [Test]
    public async Task GenericTypeInfoGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfoGeneric();
        await Assert.That(typeInfo).IsNotNull();

        var genericParams = typeInfo.GenericTypeArguments;
        await Assert.That(genericParams).IsNotNull();
        await Assert.That(genericParams).IsNotEmpty();
        await Assert.That(genericParams[0]).IsEqualTo(typeof(IDictionary<string, int>));
    }

    [Test]
    public async Task InstancePropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstancePropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task StaticPropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task StaticPropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task PropertyGetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetGetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task PropertySetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSetProperty();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task StaticField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task FieldClassWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetField();
        await Assert.That(fieldInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceMethodWithParams()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithParams();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceMethodWithParamsOmitted()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceMethodWithParamsTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithParamsTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceMethodWithSimpleGenericParamsTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithSimpleGenericParamsTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceMethodWithComplexGenericParamsTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithComplexGenericParamsTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task StaticMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task MethodWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task TypeInfo()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfo();
        await Assert.That(typeInfo).IsNotNull();
    }

    [Test]
    public async Task TypeInfoFromInternal()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeInfo = instance.GetTypeInfoFromInternal();
        await Assert.That(typeInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceConstructor()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        await Assert.That(constructorInfo).IsNotNull();
        await Assert.That(constructorInfo.GetParameters()).IsEmpty();
    }

    [Test]
    public async Task InstanceConstructorWithParam()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithParam();
        await Assert.That(constructorInfo).IsNotNull();
    }
    [Test]
    public async Task GetConstructorInfoWithMultipleParam()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithMultipleParam();
        await Assert.That(constructorInfo).IsNotNull();
    }

    [Test]
    public async Task InstanceConstructorWithParamTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithParamTyped();
        await Assert.That(constructorInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerSet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerSet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerGetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerGetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerSetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerSetTyped()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerGet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerGet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerSet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerSet_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSet();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerGetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerGetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerGetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerGetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetStringIndexerSetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStringIndexerSetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GetIntIndexerSetTyped_Generic()
    {
        var type = assembly.GetType("GenericClass`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetIntIndexerSetTyped();
        await Assert.That(methodInfo).IsNotNull();
    }

    [Test]
    public async Task GenericConstructor()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        await Assert.That(constructorInfo).IsNotNull();
    }

    [Test]
    public async Task GenericConstructorGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoGeneric();
        await Assert.That(constructorInfo).IsNotNull();
    }

    [Test]
    public async Task GenericConstructorTyped()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoTyped();
        await Assert.That(constructorInfo).IsNotNull();
    }

    [Test]
    public async Task GetListField()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetListField();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task GetListMethod()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetListMethod();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task GetListProperty()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetListProperty();
        await Assert.That(info).IsNotNull();
    }
}