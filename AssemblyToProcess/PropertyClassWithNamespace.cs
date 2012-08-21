using System.Reflection;

namespace MyNamespace
{
    public class PropertyClassWithNamespace
    {
        public string InstanceProperty { get; set; }

        public MethodInfo GetGetProperty()
        {
            return Info.OfPropertyGet("AssemblyToProcess","MyNamespace.PropertyClassWithNamespace","InstanceProperty");
        }

        public MethodInfo GetSetProperty()
        {
            return Info.OfPropertySet("AssemblyToProcess", "MyNamespace.PropertyClassWithNamespace", "InstanceProperty");
        }
    }
}