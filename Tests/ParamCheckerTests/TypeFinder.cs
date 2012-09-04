using System.Linq;
using Mono.Cecil;

public static class TypeFinder
{
    public static TypeDefinition Find<T>()
    {
        var location = typeof(T).Assembly.CodeBase;
        location = location.Replace("file:///", "");

        return ModuleDefinition.ReadModule(location).GetTypes().First(x => x.Name == typeof(T).Name);
    }
}