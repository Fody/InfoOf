using System;
using System.Reflection;
using Xunit;

partial class IntegrationTests
{
    [Fact]
    public void WithBlocks_GetOfConstructor_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructor_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructor_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructor_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructor_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructor_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructor_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfConstructorTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfConstructorTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo info = instance.GetOfConstructorTypedWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfField_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfField_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfField_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfFieldTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfFieldTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfFieldTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfField_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfField_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfField_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfField_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfFieldTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfFieldTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfFieldTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo info = instance.GetOfFieldTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethod_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethod_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethod_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethod_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethod_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethod_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethod_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfMethodTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodTypedWithParam_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodTypedWithParam_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfMethodTypedWithParam_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfMethodTypedWithParam_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertyGet_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertyGet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertyGet_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertyGetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertyGetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertyGetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertyGet_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertyGet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertyGet_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGet_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertyGetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertyGetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertyGetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertyGetTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertySet_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertySet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertySet_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertySetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertySetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocks_GetOfPropertySetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocks");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertySet_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertySet_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertySet_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySet_TryBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertySetTyped_ForBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_ForBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertySetTyped_SwitchBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_SwitchBlock();
        Assert.NotNull(info);
    }

    [Fact]
    public void WithBlocksGeneric_GetOfPropertySetTyped_TryBlock()
    {
        var type = assembly.GetType("WithBlocksGeneric`1").MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo info = instance.GetOfPropertySetTyped_TryBlock();
        Assert.NotNull(info);
    }
}
