using System;
using System.Reflection;

/// <summary>
/// Used as a type safe abstraction for injecting InfoOf IL into an assembly.
/// </summary>
public static class Info
{
    static Exception BuildException()
    {
        return new();
    }

    /// <summary>
    /// Inject a MethodOf.
    /// </summary>
    public static MethodInfo OfMethod(string assemblyName, string typeName, string methodName, string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf.
    /// </summary>
    public static MethodInfo OfMethod(string assemblyName, string typeName, string methodName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf.
    /// </summary>
    public static MethodInfo OfMethod<T>(string methodName, string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf.
    /// </summary>
    public static MethodInfo OfMethod<T>(string methodName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a ConstructorOf.
    /// </summary>
    public static ConstructorInfo OfConstructor(string assemblyName, string typeName, string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a ConstructorOf.
    /// </summary>
    public static ConstructorInfo OfConstructor(string assemblyName, string typeName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a ConstructorOf.
    /// </summary>
    public static ConstructorInfo OfConstructor<T>(string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a ConstructorOf.
    /// </summary>
    public static ConstructorInfo OfConstructor<T>()
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a TypeOf.
    /// </summary>
    public static Type OfType(string assemblyName, string typeName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a FieldOf.
    /// </summary>
    public static FieldInfo OfField(string assemblyName, string typeName, string fieldName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a FieldOf.
    /// </summary>
    public static FieldInfo OfField<T>(string fieldName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for a property get.
    /// </summary>
    public static MethodInfo OfPropertyGet(string assemblyName, string typeName, string propertyName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for a property get.
    /// </summary>
    public static MethodInfo OfPropertyGet<T>(string propertyName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for a property set.
    /// </summary>
    public static MethodInfo OfPropertySet(string assemblyName, string typeName, string propertyName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for a property set.
    /// </summary>
    public static MethodInfo OfPropertySet<T>(string propertyName)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for an indexer get.
    /// </summary>
    public static MethodInfo OfIndexerGet(string assemblyName, string typeName, string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for an indexer get.
    /// </summary>
    public static MethodInfo OfIndexerGet<T>(string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for an indexer set.
    /// </summary>
    public static MethodInfo OfIndexerSet(string assemblyName, string typeName, string parameters)
    {
        throw BuildException();
    }

    /// <summary>
    /// Inject a MethodOf for an indexer set.
    /// </summary>
    public static MethodInfo OfIndexerSet<T>(string parameters)
    {
        throw BuildException();
    }
}