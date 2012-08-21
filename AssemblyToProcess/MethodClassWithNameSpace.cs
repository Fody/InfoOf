using System.Reflection;

namespace MyNamespace
{
    public class MethodClassWithNameSpace
    {
        public void Method()
        {
        }

        public MethodInfo GetInstanceMethod()
        {
            return Info.OfMethod("AssemblyToProcess","MyNamespace.MethodClassWithNameSpace","Method");
        }
    }
}