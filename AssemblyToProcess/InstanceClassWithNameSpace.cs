using System.Reflection;

namespace MyNamespace
{
    public class InstanceClassWithNameSpace
    {
        string field;
        public FieldInfo GetField()
        {
            return Info.OfField("AssemblyToProcess", "MyNamespace.InstanceClassWithNameSpace", "field");
        }
        public void Method()
        {
        }

        public MethodInfo GetInstanceMethod()
        {
            return Info.OfMethod("AssemblyToProcess", "MyNamespace.InstanceClassWithNameSpace", "Method");
        }


        public string InstanceProperty { get; set; }

        public MethodInfo GetGetProperty()
        {
            return Info.OfPropertyGet("AssemblyToProcess", "MyNamespace.InstanceClassWithNameSpace", "InstanceProperty");
        }

        public MethodInfo GetSetProperty()
        {
            return Info.OfPropertySet("AssemblyToProcess", "MyNamespace.InstanceClassWithNameSpace", "InstanceProperty");
        }
    }
}