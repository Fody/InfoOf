using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;


[TestFixture]
public class IntegrationTests
{
    Assembly assembly;
    List<string> warnings = new List<string>();
    public IntegrationTests()
    {

        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        var assemblyPath = Path.GetFullPath(@"..\..\..\AssemblyToProcess\bin\Debug\AssemblyToProcess.dll");
#if (!DEBUG)

        assemblyPath = assemblyPath.Replace("Debug", "Release");
#endif

        var newAssembly = assemblyPath.Replace(".dll", "2.dll");
        File.Copy(assemblyPath, newAssembly, true);

        var moduleDefinition = ModuleDefinition.ReadModule(newAssembly);
        var weavingTask = new ModuleWeaver
                              {
                                  ModuleDefinition = moduleDefinition,
                                  AssemblyResolver = new MockAssemblyResolver(),
                                  LogWarning =s => warnings.Add(s)
                              };

        weavingTask.Execute();
        moduleDefinition.Write(newAssembly);

        assembly = Assembly.LoadFile(newAssembly);
    }

    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        return AppDomain.CurrentDomain.GetAssemblies().First(x => x.GetName().Name == args.Name);
    }

    [Test]
    public void InstancePropertyGet()
    {
        var type = assembly.GetType("PropertyClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void InstancePropertySet()
    {
        var type = assembly.GetType("PropertyClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.IsNotNull(methodInfo);
    }
    [Test]
    public void StaticPropertyGet()
    {
        var type = assembly.GetType("PropertyClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void StaticPropertySet()
    {
        var type = assembly.GetType("PropertyClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.IsNotNull(methodInfo);
    }
    [Test]
    public void PropertyGetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.PropertyClassWithNamespace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void PropertySetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.PropertyClassWithNamespace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void InstanceField()
    {
        var type = assembly.GetType("FieldClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void StaticField()
    {
        var type = assembly.GetType("FieldClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void FieldClassWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.FieldClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void InstanceMethod()
    {
        var type = assembly.GetType("MethodClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.IsNotNull(methodInfo);
    }
    [Test]
    public void StaticMethod()
    {
        var type = assembly.GetType("MethodClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.IsNotNull(methodInfo);
    }
    [Test]
    public void MethodWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.MethodClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void TypeInfo()
    {
        var type = assembly.GetType("TypeClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfo();
        Assert.IsNotNull(typeinfo);
    }
    [Test]
    public void TypeInfoFromInternal()
    {
        var type = assembly.GetType("TypeClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfoFromInternal();
        Assert.IsNotNull(typeinfo);
    }

#if(DEBUG)
    [Test]
    public void PeVerify()
    {
        Verifier.Verify(assembly.CodeBase.Remove(0, 8));
    }
#endif

}