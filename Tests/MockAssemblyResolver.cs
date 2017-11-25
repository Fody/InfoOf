using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

public class MockAssemblyResolver : IAssemblyResolver
{
    public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
    {
        return Resolve(name);
    }

    public AssemblyDefinition Resolve(AssemblyNameReference name)
    {
        var firstOrDefault = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == name.Name);
        if (firstOrDefault != null)
        {
            return AssemblyDefinition.ReadAssembly(firstOrDefault.CodeBase.Replace("file:///", ""));
        }
        Assembly assembly;
        try
        {
            assembly = Assembly.Load(name.FullName);
        }
        catch (FileLoadException)
        {
            return null;
        }
        var codeBase = assembly.CodeBase.Replace("file:///","");

        return AssemblyDefinition.ReadAssembly(codeBase);
    }

    public void Dispose()
    {
    }
}