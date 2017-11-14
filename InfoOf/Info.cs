using System;
using System.Reflection;

public static class Info
{
    static Exception BuildException()
    {
        return new Exception();
    }

    public static MethodInfo OfMethod(string assemblyName, string typeName, string methodName, string parameters)
    {
        throw BuildException();
    }

    public static MethodInfo OfMethod(string assemblyName, string typeName, string methodName)
    {
        throw BuildException();
    }

    public static ConstructorInfo OfConstructor(string assemblyName, string typeName, string parameters)
    {
        throw BuildException();
    }

    public static ConstructorInfo OfConstructor(string assemblyName, string typeName)
    {
        throw BuildException();
    }

    public static Type OfType(string assemblyName, string typeName)
    {
        throw BuildException();
    }

    public static FieldInfo OfField(string assemblyName, string typeName, string fieldName)
    {
        throw BuildException();
    }

    public static MethodInfo OfPropertyGet(string assemblyName, string typeName, string propertyName)
    {
        throw BuildException();
    }

    public static MethodInfo OfPropertySet(string assemblyName, string typeName, string propertyName)
    {
        throw BuildException();
    }
}