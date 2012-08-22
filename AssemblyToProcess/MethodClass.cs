using System;
using System.Reflection;


public class MethodClass
{
    void InstanceMethod(){}
    static void StaticMethod(){}
    public MethodInfo GetInstanceMethod()
    {
        return Info.OfMethod("AssemblyToProcess","MethodClass","InstanceMethod");
    }
    public MethodInfo GetStaticMethod()
    {
        return Info.OfMethod("AssemblyToProcess","MethodClass","StaticMethod");
    }
    public MethodInfo WithGenericParamMethod<T,K>(Action<T> action)
    {
        return Info.OfMethod("AssemblyToProcess","MethodClass","StaticMethod");
    }
    public MethodInfo WithGenericParamMethod<T>(Action<T> action)
    {
        return Info.OfMethod("AssemblyToProcess","MethodClass","StaticMethod");
    }
}
