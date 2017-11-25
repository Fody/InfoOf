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
    string afterAssemblyPath;
    string beforeAssemblyPath;

    public IntegrationTests()
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        beforeAssemblyPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "AssemblyToProcess.dll");

        afterAssemblyPath = beforeAssemblyPath.Replace(".dll", "2.dll");
        File.Copy(beforeAssemblyPath, afterAssemblyPath, true);

        using (var moduleDefinition = ModuleDefinition.ReadModule(beforeAssemblyPath))
        {
            var weavingTask = new ModuleWeaver
            {
                ModuleDefinition = moduleDefinition,
                AssemblyResolver = new MockAssemblyResolver(),
                LogWarning = s => warnings.Add(s)
            };

            weavingTask.Execute();
            moduleDefinition.Write(afterAssemblyPath);
        }

        assembly = Assembly.LoadFile(afterAssemblyPath);
    }

    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        return AppDomain.CurrentDomain.GetAssemblies().First(x => x.GetName().Name == args.Name);
    }

    [Test]
    public void GenericPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetPropertyGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetPropertyGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericStaticPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericStaticPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetPropertyGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericStaticPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericStaticPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetPropertyGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void GenericFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceFieldGeneric();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void GenericStaticField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void GenericStaticFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticFieldGeneric();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void GetSystemGeneric()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSystemGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethodGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericStaticMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericStaticMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethodGeneric();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void GenericTypeInfo()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfo();
        Assert.IsNotNull(typeinfo);
    }

    [Test]
    public void GenericTypeInfoGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfoGeneric();
        Assert.That(typeinfo, Is.Not.Null);

        var genericParams = typeinfo.GenericTypeArguments;
        Assert.That(genericParams, Is.Not.Null.Or.Empty);
        Assert.That(genericParams[0], Is.EqualTo(typeof(IDictionary<string, int>)));
    }

    [Test]
    public void InstancePropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void InstancePropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void StaticPropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void StaticPropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void PropertyGetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetGetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void PropertySetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSetProperty();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void InstanceField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void StaticField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void FieldClassWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic)Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetField();
        Assert.IsNotNull(fieldInfo);
    }

    [Test]
    public void InstanceMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void InstanceMethodWithParams()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithParams();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void StaticMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void MethodWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic)Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.IsNotNull(methodInfo);
    }

    [Test]
    public void TypeInfo()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfo();
        Assert.IsNotNull(typeinfo);
    }

    [Test]
    public void TypeInfoFromInternal()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfoFromInternal();
        Assert.IsNotNull(typeinfo);
    }

    [Test]
    public void InstanceConstructor()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        Assert.IsNotNull(constructorInfo);
    }

    [Test]
    public void InstanceConstructorWithParam()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic)Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithParam();
        Assert.IsNotNull(constructorInfo);
    }

    [Test]
    public void GenericConstructor()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        Assert.IsNotNull(constructorInfo);
    }

    [Test]
    public void GenericConstructorGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic)Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoGeneric();
        Assert.IsNotNull(constructorInfo);
    }

    [Test]
    public void PeVerify()
    {
        Verifier.Verify(beforeAssemblyPath, afterAssemblyPath);
    }
}