using System.Text;
using Mono.Cecil;

public static class MethodNameGenerator
{
    public static string FullName(this MethodDefinition methodDefinition)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(methodDefinition.DeclaringType.FullName);
        stringBuilder.Append(".");
        stringBuilder.Append(methodDefinition.Name);
        methodDefinition.MethodSignatureFullName(stringBuilder);
        return stringBuilder.ToString();
    }
    public static void MethodSignatureFullName(this IMethodSignature self, StringBuilder builder)
    {
        builder.Append("(");
        if (self.HasParameters)
        {
            var parameters = self.Parameters;
            for (var i = 0; i < parameters.Count; i++)
            {
                var definition = parameters[i];
                if (i > 0)
                {
                    builder.Append(",");
                }
                if (definition.ParameterType.IsSentinel)
                {
                    builder.Append("...,");
                }
                builder.Append(definition.ParameterType.FullName);
            }
        }
        builder.Append(")");
    }

 

 

}