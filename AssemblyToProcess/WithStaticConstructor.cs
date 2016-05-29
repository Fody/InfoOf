using System.Reflection;

public class WithStaticConstructor
{
    static readonly MethodInfo Method = Info.OfMethod(
            "mscorlib",
            "System.Tuple",
            "Create",
            "T1");

}