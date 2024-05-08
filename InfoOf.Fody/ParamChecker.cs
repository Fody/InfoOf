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

            return definitions.OrderBy(_ => _.Parameters.Count).First();
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

    public static List<string> GetParameters(this string parameters) =>
        parameters
            .Aggregate(
                (0, "", Array.Empty<string>()),
                (acc, c) => (acc.Item1, c) switch
                {
                    (0, ',') => (0, "", [.. acc.Item3, acc.Item2]),
                    (_, '<') => (acc.Item1 + 1, $"{acc.Item2}{c}", acc.Item3),
                    (_, '>') => (acc.Item1 - 1, $"{acc.Item2}{c}", acc.Item3),
                    (_, ' ') => acc,
                    (_, _) => (acc.Item1, $"{acc.Item2}{c}", acc.Item3)
                },
                acc => acc.Item2 switch
                {
                    "" => acc.Item3,
                    _ => [.. acc.Item3, acc.Item2]
                })
            .Select(_ => _.Trim())
            .ToList();
}