using System.Reflection;

public class WithBlocks
{
    public WithBlocks() {}
    public WithBlocks(int _) {}

    int instanceField = 0;

    int InstanceMethod() => 0;
    int InstanceMethodWithParam(int i) => i;

    int InstanceProperty { get; set; }

    public ConstructorInfo GetOfConstructor_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor("AssemblyToProcess", "WithBlocks");
        }

        return info;
    }

    public ConstructorInfo GetOfConstructor_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor("AssemblyToProcess", "WithBlocks");

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructor_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor("AssemblyToProcess", "WithBlocks");
    }

    public ConstructorInfo GetOfConstructorTyped_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor<WithBlocks>();
        }

        return info;
    }

    public ConstructorInfo GetOfConstructorTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor<WithBlocks>();

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructorTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor<WithBlocks>();
    }

    public ConstructorInfo GetOfConstructorWithParam_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor("AssemblyToProcess", "WithBlocks", "Int32");
        }

        return info;
    }

    public ConstructorInfo GetOfConstructorWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor("AssemblyToProcess", "WithBlocks", "Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructorWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor("AssemblyToProcess", "WithBlocks", "Int32");
    }

    public ConstructorInfo GetOfConstructorTypedWithParam_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor<WithBlocks>("Int32");
        }

        return info;
    }

    public ConstructorInfo GetOfConstructorTypedWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor<WithBlocks>("Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructorTypedWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor<WithBlocks>("Int32");
    }

    public FieldInfo GetOfField_ForBlock()
    {
        FieldInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfField("AssemblyToProcess", "WithBlocks", nameof(instanceField));
        }

        return info;
    }

    public FieldInfo GetOfField_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfField("AssemblyToProcess", "WithBlocks", nameof(instanceField));

        InstanceMethodWithParam(i);

        return info;
    }

    public FieldInfo GetOfField_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfField("AssemblyToProcess", "WithBlocks", nameof(instanceField));
    }

    public FieldInfo GetOfFieldTyped_ForBlock()
    {
        FieldInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfField<WithBlocks>(nameof(instanceField));
        }

        return info;
    }

    public FieldInfo GetOfFieldTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfField<WithBlocks>(nameof(instanceField));

        InstanceMethodWithParam(i);

        return info;
    }

    public FieldInfo GetOfFieldTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfField<WithBlocks>(nameof(instanceField));
    }

    public MethodInfo GetOfMethod_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod("AssemblyToProcess", "WithBlocks", nameof(InstanceMethod));
        }

        return info;
    }

    public MethodInfo GetOfMethod_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod("AssemblyToProcess", "WithBlocks", nameof(InstanceMethod));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethod_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod("AssemblyToProcess", "WithBlocks", nameof(InstanceMethod));
    }

    public MethodInfo GetOfMethodTyped_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod<WithBlocks>(nameof(InstanceMethod));
        }

        return info;
    }

    public MethodInfo GetOfMethodTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod<WithBlocks>(nameof(InstanceMethod));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethodTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod<WithBlocks>(nameof(InstanceMethod));
    }

    public MethodInfo GetOfMethodWithParam_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod("AssemblyToProcess", "WithBlocks", nameof(InstanceMethodWithParam), "Int32");
        }

        return info;
    }

    public MethodInfo GetOfMethodWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod("AssemblyToProcess", "WithBlocks", nameof(InstanceMethodWithParam), "Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethodWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod("AssemblyToProcess", "WithBlocks", nameof(InstanceMethodWithParam), "Int32");
    }

    public MethodInfo GetOfMethodTypedWithParam_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod<WithBlocks>(nameof(InstanceMethodWithParam), "Int32");
        }

        return info;
    }

    public MethodInfo GetOfMethodTypedWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod<WithBlocks>(nameof(InstanceMethodWithParam), "Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethodTypedWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod<WithBlocks>(nameof(InstanceMethodWithParam), "Int32");
    }

    public MethodInfo GetOfPropertyGet_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertyGet("AssemblyToProcess", "WithBlocks", nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertyGet_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertyGet("AssemblyToProcess", "WithBlocks", nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertyGet_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertyGet("AssemblyToProcess", "WithBlocks", nameof(InstanceProperty));
    }

    public MethodInfo GetOfPropertyGetTyped_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertyGet<WithBlocks>(nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertyGetTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertyGet<WithBlocks>(nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertyGetTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertyGet<WithBlocks>(nameof(InstanceProperty));
    }

    public MethodInfo GetOfPropertySet_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertySet("AssemblyToProcess", "WithBlocks", nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertySet_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertySet("AssemblyToProcess", "WithBlocks", nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertySet_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertySet("AssemblyToProcess", "WithBlocks", nameof(InstanceProperty));
    }

    public MethodInfo GetOfPropertySetTyped_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertySet<WithBlocks>(nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertySetTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertySet<WithBlocks>(nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertySetTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertySet<WithBlocks>(nameof(InstanceProperty));
    }
}

public class WithBlocksGeneric<T>
{
    public WithBlocksGeneric() {}
    public WithBlocksGeneric(int _) {}

    int instanceField = 0;

    int InstanceMethod() => 0;
    int InstanceMethodWithParam(int i) => i;

    int InstanceProperty { get; set; }

    public ConstructorInfo GetOfConstructor_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor("AssemblyToProcess", "WithBlocksGeneric`1");
        }

        return info;
    }

    public ConstructorInfo GetOfConstructor_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor("AssemblyToProcess", "WithBlocksGeneric`1");

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructor_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor("AssemblyToProcess", "WithBlocksGeneric`1");
    }

    public ConstructorInfo GetOfConstructorTyped_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor<WithBlocksGeneric<int>>();
        }

        return info;
    }

    public ConstructorInfo GetOfConstructorTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor<WithBlocksGeneric<int>>();

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructorTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor<WithBlocksGeneric<int>>();
    }

    public ConstructorInfo GetOfConstructorWithParam_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor("AssemblyToProcess", "WithBlocksGeneric`1", "Int32");
        }

        return info;
    }

    public ConstructorInfo GetOfConstructorWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor("AssemblyToProcess", "WithBlocksGeneric`1", "Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructorWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor("AssemblyToProcess", "WithBlocksGeneric`1", "Int32");
    }

    public ConstructorInfo GetOfConstructorTypedWithParam_ForBlock()
    {
        ConstructorInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfConstructor<WithBlocksGeneric<int>>("Int32");
        }

        return info;
    }

    public ConstructorInfo GetOfConstructorTypedWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfConstructor<WithBlocksGeneric<int>>("Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public ConstructorInfo GetOfConstructorTypedWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfConstructor<WithBlocksGeneric<int>>("Int32");
    }

    public FieldInfo GetOfField_ForBlock()
    {
        FieldInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfField("AssemblyToProcess", "WithBlocksGeneric`1", nameof(instanceField));
        }

        return info;
    }

    public FieldInfo GetOfField_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfField("AssemblyToProcess", "WithBlocksGeneric`1", nameof(instanceField));

        InstanceMethodWithParam(i);

        return info;
    }

    public FieldInfo GetOfField_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfField("AssemblyToProcess", "WithBlocksGeneric`1", nameof(instanceField));
    }

    public FieldInfo GetOfFieldTyped_ForBlock()
    {
        FieldInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfField<WithBlocksGeneric<int>>(nameof(instanceField));
        }

        return info;
    }

    public FieldInfo GetOfFieldTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfField<WithBlocksGeneric<int>>(nameof(instanceField));

        InstanceMethodWithParam(i);

        return info;
    }

    public FieldInfo GetOfFieldTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfField<WithBlocksGeneric<int>>(nameof(instanceField));
    }

    public MethodInfo GetOfMethod_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceMethod));
        }

        return info;
    }

    public MethodInfo GetOfMethod_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceMethod));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethod_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceMethod));
    }

    public MethodInfo GetOfMethodTyped_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod<WithBlocksGeneric<int>>(nameof(InstanceMethod));
        }

        return info;
    }

    public MethodInfo GetOfMethodTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod<WithBlocksGeneric<int>>(nameof(InstanceMethod));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethodTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod<WithBlocksGeneric<int>>(nameof(InstanceMethod));
    }

    public MethodInfo GetOfMethodWithParam_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceMethodWithParam), "Int32");
        }

        return info;
    }

    public MethodInfo GetOfMethodWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceMethodWithParam), "Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethodWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceMethodWithParam), "Int32");
    }

    public MethodInfo GetOfMethodTypedWithParam_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfMethod<WithBlocksGeneric<int>>(nameof(InstanceMethodWithParam), "Int32");
        }

        return info;
    }

    public MethodInfo GetOfMethodTypedWithParam_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfMethod<WithBlocksGeneric<int>>(nameof(InstanceMethodWithParam), "Int32");

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfMethodTypedWithParam_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfMethod<WithBlocksGeneric<int>>(nameof(InstanceMethodWithParam), "Int32");
    }

    public MethodInfo GetOfPropertyGet_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertyGet("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertyGet_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertyGet("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertyGet_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertyGet("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceProperty));
    }

    public MethodInfo GetOfPropertyGetTyped_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertyGet<WithBlocksGeneric<int>>(nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertyGetTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertyGet<WithBlocksGeneric<int>>(nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertyGetTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertyGet<WithBlocksGeneric<int>>(nameof(InstanceProperty));
    }

    public MethodInfo GetOfPropertySet_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertySet("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertySet_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertySet("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertySet_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertySet("AssemblyToProcess", "WithBlocksGeneric`1", nameof(InstanceProperty));
    }

    public MethodInfo GetOfPropertySetTyped_ForBlock()
    {
        MethodInfo info = null;

        for (var i = 0; i < 1; ++i)
        {
            info = Info.OfPropertySet<WithBlocksGeneric<int>>(nameof(InstanceProperty));
        }

        return info;
    }

    public MethodInfo GetOfPropertySetTyped_SwitchBlock()
    {
        int i;
        switch (InstanceMethod())
        {
            case 0: i = 0; break;
            case 1: i = 1; break;
            default: i = -1; break;
        }

        var info = Info.OfPropertySet<WithBlocksGeneric<int>>(nameof(InstanceProperty));

        InstanceMethodWithParam(i);

        return info;
    }

    public MethodInfo GetOfPropertySetTyped_TryBlock()
    {
        try
        {
            InstanceMethod();
        }
        catch
        {
            throw;
        }

        return Info.OfPropertySet<WithBlocksGeneric<int>>(nameof(InstanceProperty));
    }
}
