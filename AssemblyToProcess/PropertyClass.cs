using System.Reflection;

public class PropertyClass
{
    string InstanceProperty { get; set; }
    public MethodInfo GetInstanceGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess","PropertyClass","InstanceProperty");
    }
    public MethodInfo GetInstanceSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "PropertyClass", "InstanceProperty");
    }

    static string StaticProperty { get; set; }
    public MethodInfo GetStaticGetProperty()
    {
        return Info.OfPropertyGet("AssemblyToProcess", "PropertyClass", "StaticProperty");
    }
    public MethodInfo GetStaticSetProperty()
    {
        return Info.OfPropertySet("AssemblyToProcess", "PropertyClass", "StaticProperty");
    }
}
