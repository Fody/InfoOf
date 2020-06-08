using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;

public static class ParamChecker
{
    public static MethodDefinition FindMethodDefinitions(this TypeDefinition typeDefinition, string methodName, List<string> parameters)
    {
        if (parameters != null && parameters.Any())
        {
            var definitions = typeDefinition
                .Methods
                .Where(method => method.Name == methodName &&
                                 method.HasSameParams(parameters))
                .ToList();
            if (definitions.Count == 0)
            {
                throw new WeavingException($"Could not find method named '{methodName}'.");
            }

            if (definitions.Count > 1)
            {
                throw new WeavingException($"More than one method named '{methodName}' found.");
            }
            return definitions.First();
        }
        else
        {
            var definitions = typeDefinition
                .Methods
                .Where(method => method.Name == methodName)
                .ToList();
            if (definitions.Count == 0)
            {
                throw new WeavingException($"Could not find method named '{methodName}'.");
            }

            return definitions.OrderBy(x => x.Parameters.Count).First();
        }
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