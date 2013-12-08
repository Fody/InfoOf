using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

public class MockAssemblyResolver : IAssemblyResolver
{
    public AssemblyDefinition Resolve(AssemblyNameReference name)
    {
        throw new NotImplementedException();
    }

    public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
    {
        throw new NotImplementedException();
    }

    public AssemblyDefinition Resolve(string fullName)
    {
        var firstOrDefault = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == fullName);
        if (firstOrDefault != null)
        {
            return AssemblyDefinition.ReadAssembly(firstOrDefault.CodeBase.Replace("file:///", ""));
        }
        Assembly assembly;
        try
        {
            assembly = Assembly.Load(fullName);
        }
        catch (FileLoadException)
        {
            return null;
        }
        var codeBase = assembly.CodeBase.Replace("file:///","");

        return AssemblyDefinition.ReadAssembly(codeBase);
    }

    public AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
    {
        throw new NotImplementedException();
    }
}