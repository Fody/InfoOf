using System;
using System.Collections.Generic;

public class WeavingException : Exception
{
    public WeavingException(string message)
        : base(message)
    {

    }
}

public class TypeSpec
{
    public string AssemblyName;

    public List<TypeSpec> Nested;

    public List<TypeSpec> GenericParameters;

    public string Name;
}