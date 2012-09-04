using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

public static class ParamChecker
{
    public static List<MethodDefinition> FindMethodDefinitions(this TypeDefinition typeDefinition, string methodName, List<string> parameters)
    {
        if (parameters == null)
        {
            return typeDefinition
                .Methods
                .Where(method => method.Name == methodName)
                .ToList();
        }
        return typeDefinition
            .Methods
            .Where(method => method.Name == methodName &&
                             method.HasSameParams(parameters))
            .ToList();
    }

    public static bool HasSameParams(this MethodDefinition method, List<string> parameters)
    {
        if (method.Parameters.Count != parameters.Count)
        {
            return false;
        }
        for (var index = 0; index < method.Parameters.Count; index++)
        {
            var parameterDefinition = method.Parameters[index];
            var parameterType = parameterDefinition.ParameterType;
            var parameterName = parameters[index];
            if (!parameterType.IsNamed(parameterName))
            {
                return false;
            }
        }
        return true;
    }
}