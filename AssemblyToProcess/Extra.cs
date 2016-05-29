using System.Reflection;
// ReSharper disable UnusedMember.Local

public class Extra
{

    public MethodInfo GetSystemGeneric()
    {
        return Info.OfMethod("mscorlib",
            "System.Tuple",
            "Create",
            "T1");
    }

}