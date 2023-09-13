using Mono.Cecil;

public static class TypeFinder
{
    public static TypeDefinition Find<T>()
    {
        var location = typeof(T).Assembly.Location;

        return ModuleDefinition.ReadModule(location)
            .GetTypes()
            .First(_ => _.Name == typeof(T).Name);
    }
}