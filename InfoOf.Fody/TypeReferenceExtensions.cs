using Mono.Cecil;

public static class TypeReferenceExtensions
{
    public static bool IsNamed(this TypeReference type, string typeName)
    {
        var fullName = type.FullName;
        if (typeName == fullName)
        {
            return true;
        }
        if (typeName == type.Name)
        {
            return true;
        }
        var dotIndex = fullName.IndexOf('.');
        if (dotIndex > 0)
        {
            dotIndex++;
            var nameWithoutNamespace = fullName.Substring(dotIndex, fullName.Length - dotIndex);
            if (typeName == nameWithoutNamespace)
            {
                return true;
            }
        }
        return false;
    }
}