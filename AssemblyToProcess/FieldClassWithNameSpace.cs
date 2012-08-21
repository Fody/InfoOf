using System.Reflection;

namespace MyNamespace
{
    public class FieldClassWithNameSpace
    {
        string field;
        public FieldInfo GetField()
        {
            return Info.OfField("AssemblyToProcess","MyNamespace.FieldClassWithNameSpace","field");
        }
    }
}