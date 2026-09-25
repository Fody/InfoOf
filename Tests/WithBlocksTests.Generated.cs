using System;
using System.Reflection;

partial class IntegrationTests
{
    [Test]
    public async Task WithBlocks_GetOfConstructor_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructor_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructor_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructor_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructor_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructor_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructor_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructor_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfConstructorTypedWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfConstructorTypedWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfField_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfField_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfField_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfField_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfFieldTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfFieldTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfFieldTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfFieldTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfField_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfField_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfField_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfField_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfFieldTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfFieldTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfFieldTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfFieldTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethod_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethod_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethod_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethod_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethod_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethod_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethod_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethod_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfMethodTypedWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfMethodTypedWithParam_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGet_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGet_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGet_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertyGetTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGet_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGet_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGet_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertyGetTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySet_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySet_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySet_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocks_GetOfPropertySetTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySet_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySet_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySet_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_UsingBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_ForBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_SwitchBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_TryBlock();
        await Assert.That(info).IsNotNull();
    }

    [Test]
    public async Task WithBlocksGeneric_GetOfPropertySetTyped_UsingBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_UsingBlock();
        await Assert.That(info).IsNotNull();
    }
}
