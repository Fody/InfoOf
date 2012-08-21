using System.Reflection;

public class GenericClass<T>{
}
public class FieldClass
{
    string instanceField;
    public FieldInfo GetInstanceField()
    {
        return Info.OfField("AssemblyToProcess","FieldClass","instanceField");
    }
    static string staticField;
    public FieldInfo GetStaticField()
    {
        return Info.OfField("AssemblyToProcess", "FieldClass", "staticField");
    }
}