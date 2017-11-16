using System;
using System.Reflection;

public class GenericClass<T>
{
    string instanceField;

    public FieldInfo GetInstanceField()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1", "instanceField");
    }

    static string staticField;

    public FieldInfo GetStaticField()
    {
        return Info.OfField("AssemblyToProcess", "GenericClass`1", "staticField");
    }

    string InstanceProperty { get; set; }

    public MethodInfo GetInstanceGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "GenericClass`1", "InstanceProperty");
    }

    public MethodInfo GetInstanceSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1", "InstanceProperty");
    }

    static string StaticProperty { get; set; }

    public MethodInfo GetStaticGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "GenericClass`1", "StaticProperty");
    }

    public MethodInfo GetStaticSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "GenericClass`1", "StaticProperty");
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

    public MethodInfo GetStaticMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "GenericClass`1", "StaticMethod");
    }

    public Type GetTypeInfo()
    {
        return Info.OfType("AssemblyToProcess", "GenericClass`1");
    }

    public Type GetGenericTypeInfo()
    {
        return Info.OfType("AssemblyToProcess", "GenericClass`1<" +
            "mscorlib|System.Collections.Generic.IDictionary`2<" +
                "mscorlib|System.String," +
                "mscorlib|System.Int32>>");
    }
}
