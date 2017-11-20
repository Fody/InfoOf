using System;
using System.Reflection;

public class GenericClass<T>
{
    string instanceField;

    public FieldInfo GetInstanceField()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1", "instanceField");
    }

    public FieldInfo GetInstanceFieldGeneric()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "instanceField");
    }

    static string staticField;

    public FieldInfo GetStaticField()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1", "staticField");
    }

    public FieldInfo GetStaticFieldGeneric()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "staticField");
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

    public MethodInfo GetInstanceSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1", "InstanceProperty");
    }

    public MethodInfo GetInstanceSetPropertyGeneric()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "InstanceProperty");
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

    public MethodInfo GetStaticSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1", "StaticProperty");
    }

    public MethodInfo GetStaticSetPropertyGeneric()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "StaticProperty");
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

    public MethodInfo GetStaticMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1", "StaticMethod");
    }

    public MethodInfo GetStaticMethodGeneric()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1<mscorlib|System.Int32>", "StaticMethod");
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
}
