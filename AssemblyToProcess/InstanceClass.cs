using System;
using System.Reflection;
// ReSharper disable UnusedMember.Local

public class InstanceClass
{
    public InstanceClass()
    {
    }

    public InstanceClass(string _)
    {
    }

    public InstanceClass(string y, int x)
    {
    }

    string instanceField;

    public FieldInfo GetInstanceField()
    {
        return Info.OfField("AssemblyToProcess", "InstanceClass", "instanceField");
    }

    static string staticField;

    public FieldInfo GetStaticField()
    {
        return Info.OfField("AssemblyToProcess", "InstanceClass", "staticField");
    }

    string InstanceProperty { get; set; }

    public MethodInfo GetInstanceGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "InstanceClass", "InstanceProperty");
    }

    public MethodInfo GetInstanceSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "InstanceClass", "InstanceProperty");
    }

    static string StaticProperty { get; set; }

    public MethodInfo GetStaticGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "InstanceClass", "StaticProperty");
    }

    public MethodInfo GetStaticSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "InstanceClass", "StaticProperty");
    }

    // ReSharper disable UnusedParameter.Local
    static void MethodWithParams(string param1, int param2)
    {
    }
    // ReSharper restore UnusedParameter.Local

    public MethodInfo GetMethodWithParams()
    {
        return Info.OfMethod("AssemblyToProcess", "InstanceClass", "MethodWithParams", "String, Int32");
    }

    public MethodInfo GetMethodTyped()
    {
        return Info.OfMethod<InstanceClass>(nameof(MethodWithParams));
    }

    public MethodInfo GetMethodWithParamsTyped()
    {
        return Info.OfMethod<InstanceClass>(nameof(MethodWithParams), "String, Int32");
    }

    void InstanceMethod()
    {
    }

    public MethodInfo GetInstanceMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "InstanceClass", "InstanceMethod");
    }

    static void StaticMethod()
    {
    }

    public MethodInfo GetStaticMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "InstanceClass", "StaticMethod");
    }

    public Type GetTypeInfo()
    {
        return Info.OfType("AssemblyToProcess", "InstanceClass");
    }

    public Type GetTypeInfoFromInternal()
    {
        return Info.OfType("AssemblyToReference", "InternalClass");
    }

    public ConstructorInfo GetConstructorInfo()
    {
        return Info.OfConstructor("AssemblyToProcess", "InstanceClass");
    }

    public ConstructorInfo GetConstructorInfoWithParam()
    {
        return Info.OfConstructor("AssemblyToProcess", "InstanceClass", "String");
    }

    public ConstructorInfo GetConstructorInfoWithMultipleParam()
    {
        return Info.OfConstructor("AssemblyToProcess", "InstanceClass", "String, Int32");
    }

    public ConstructorInfo GetConstructorInfoWithParamTyped()
    {
        return Info.OfConstructor<InstanceClass>("String");
    }

    public object this[string index]
    {
        get => null;
        set => throw new NotImplementedException();
    }

    public double this[int index]
    {
        get => default;
        set => throw new NotImplementedException();
    }

    public MethodInfo GetStringIndexerGet()
    {
        return Info.OfIndexerGet("AssemblyToProcess", "InstanceClass", "String");
    }

    public MethodInfo GetIntIndexerGet()
    {
        return Info.OfIndexerGet("AssemblyToProcess", "InstanceClass", "Int32");
    }

    public MethodInfo GetStringIndexerSet()
    {
        return Info.OfIndexerSet("AssemblyToProcess", "InstanceClass", "String");
    }

    public MethodInfo GetIntIndexerSet()
    {
        return Info.OfIndexerSet("AssemblyToProcess", "InstanceClass", "Int32");
    }

    public MethodInfo GetStringIndexerGetTyped()
    {
        return Info.OfIndexerGet<InstanceClass>("String");
    }

    public MethodInfo GetIntIndexerGetTyped()
    {
        return Info.OfIndexerGet<InstanceClass>("Int32");
    }

    public MethodInfo GetStringIndexerSetTyped()
    {
        return Info.OfIndexerSet<InstanceClass>("String");
    }

    public MethodInfo GetIntIndexerSetTyped()
    {
        return Info.OfIndexerSet<InstanceClass>("Int32");
    }
}