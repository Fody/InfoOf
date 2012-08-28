using System;
using System.Reflection;

public class InstanceClass
{
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



    static void MethodWithParams(string param1,int param2) { }
    public MethodInfo GetMethodWithParams()
    {
        return Info.OfMethod("AssemblyToProcess", "InstanceClass", "MethodWithParams","String, Int32");
    }


    void InstanceMethod() { }
    public MethodInfo GetInstanceMethod()
    {
        return Info.OfMethod("AssemblyToProcess", "InstanceClass", "InstanceMethod");
    }

    static void StaticMethod() { }
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
}