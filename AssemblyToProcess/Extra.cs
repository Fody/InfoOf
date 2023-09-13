using System.Reflection;
// ReSharper disable UnusedMember.Local

public class Extra
{
    public MethodInfo GetSystemGeneric()
    {
#if (NET452)
        return Info.OfMethod("mscorlib",
            "System.Tuple",
            "Create",
            "T1");
#else
        return Info.OfMethod("System.Runtime",
            "System.Tuple",
            "Create",
            "T1");
#endif
    }

    public FieldInfo GetListField()
    {
        return Info.OfField<List<int>>("_version");
    }

    public MethodInfo GetListMethod()
    {
        return Info.OfMethod<List<int>>("Add");
    }

    public MethodInfo GetListProperty()
    {
        return Info.OfPropertyGet<List<int>>("Count");
    }
}