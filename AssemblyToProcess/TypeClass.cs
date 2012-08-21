using System;

public class TypeClass
{
    public Type GetTypeInfo()
    {
        return Info.OfType("AssemblyToProcess","TypeClass");
    }
    public Type GetTypeInfoFromInternal()
    {
        return Info.OfType("AssemblyToReference", "InternalClass");
    }
}