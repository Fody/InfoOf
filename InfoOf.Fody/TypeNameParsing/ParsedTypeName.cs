using System.Collections.Generic;
using System.Linq;

public class ParsedTypeName
{
    public string Assembly;
    public string TypeName ;
    public IReadOnlyList<ParsedTypeName> GenericParameters;

    public override string ToString()
    {
        if (GenericParameters == null)
        {
            return TypeName;
        }

        return $"{TypeName}<{string.Join(", ", GenericParameters.Select(p => p.ToString()))}>";
    }
}