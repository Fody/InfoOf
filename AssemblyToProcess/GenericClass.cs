using System;
using System.Reflection;

public class GenericClass<T>
{
    string instanceField = string.Empty;

    public FieldInfo GetInstanceField()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1", "instanceField");
    }

    public FieldInfo GetInstanceFieldGeneric()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "instanceField");
    }

    public FieldInfo GetInstanceFieldTyped()
    {
        return Info.OfField<GenericClass<int>>(nameof(instanceField));
    }

    static string staticField = string.Empty;

    public FieldInfo GetStaticField()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1", "staticField");
    }

    public FieldInfo GetStaticFieldGeneric()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "staticField");
    }

    public FieldInfo GetStaticFieldTyped()
    {
        return Info.OfField<GenericClass<int>>(nameof(staticField));
    }

    string InstanceProperty { get; set; }

    public MethodInfo GetInstanceGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "GenericClass`1", "InstanceProperty");
    }

    public MethodInfo GetInstanceGetPropertyGeneric()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "InstanceProperty");
    }

    public MethodInfo GetInstanceGetPropertyTyped()
    {
        return Info.OfPropertyGet<GenericClass<int>>(nameof(InstanceProperty));
    }

    public MethodInfo GetInstanceSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1", "InstanceProperty");
    }

    public MethodInfo GetInstanceSetPropertyGeneric()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "InstanceProperty");
    }

    public MethodInfo GetInstanceSetPropertyTyped()
    {
        return Info.OfPropertySet<GenericClass<int>>(nameof(InstanceProperty));
    }

    static string StaticProperty { get; set; }

    public MethodInfo GetStaticGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "GenericClass`1", "StaticProperty");
    }

    public MethodInfo GetStaticGetPropertyGeneric()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "StaticProperty");
    }

    public MethodInfo GetStaticGetPropertyTyped()
    {
        return Info.OfPropertyGet<GenericClass<int>>(nameof(StaticProperty));
    }

    public MethodInfo GetStaticSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1", "StaticProperty");
    }

    public MethodInfo GetStaticSetPropertyGeneric()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "StaticProperty");
    }

    public MethodInfo GetStaticSetPropertyTyped()
    {
        return Info.OfPropertySet<GenericClass<int>>(nameof(StaticProperty));
    }

    void InstanceMethod()
    {
    }

    static void StaticMethod()
    {
    }

    public MethodInfo GetInstanceMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1", "InstanceMethod");
    }

    public MethodInfo GetInstanceMethodGeneric()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "InstanceMethod");
    }

    public MethodInfo GetInstanceMethodTyped()
    {
        return Info.OfMethod<GenericClass<int>>(nameof(InstanceMethod));
    }

    public MethodInfo GetStaticMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1", "StaticMethod");
    }

    public MethodInfo GetStaticMethodGeneric()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "StaticMethod");
    }

    public MethodInfo GetStaticMethodTyped()
    {
        return Info.OfMethod<GenericClass<int>>(nameof(StaticMethod));
    }

    public Type GetTypeInfo()
    {
        return Info.OfType("AssemblyToProcess", "GenericClass`1");
    }

    public Type GetTypeInfoGeneric()
    {
        return Info.OfType("AssemblyToProcess", "GenericClass`1<" +
            "mscorlib|System.Collections.Generic.IDictionary`2<" +
                "mscorlib|System.String," +
                "mscorlib|System.Int32>>");
    }

    public ConstructorInfo GetConstructorInfo()
    {
        return Info.OfConstructor("AssemblyToProcess", "GenericClass`1");
    }

    public ConstructorInfo GetConstructorInfoGeneric()
    {
        return Info.OfConstructor("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>");
    }

    public ConstructorInfo GetConstructorInfoTyped()
    {
        return Info.OfConstructor<GenericClass<int>>();
    }
}
