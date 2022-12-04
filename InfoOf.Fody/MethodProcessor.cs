using System;
using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

public partial class ModuleWeaver
{
    void ProcessMethod(MethodDefinition method)
    {
        var actions = new List<Action<ILProcessor>>();
        foreach (var instruction in method.Body.Instructions
            .Where(i => i.OpCode == OpCodes.Call))
        {
            if (instruction.Operand is not MethodReference methodReference)
            {
                continue;
            }

            if (methodReference.DeclaringType.FullName != "Info")
            {
                continue;
            }

            var copy = instruction;
            switch (methodReference.Name)
            {
                case "OfMethod":
                    actions.Add(x => HandleOfMethod(copy, x, methodReference));
                    break;
                case "OfField":
                    actions.Add(x => HandleOfField(copy, x, methodReference));
                    break;
                case "OfType":
                    actions.Add(x => HandleOfType(copy, x));
                    break;
                case "OfPropertyGet":
                    actions.Add(x => HandleOfPropertyGet(copy, x, methodReference));
                    break;
                case "OfPropertySet":
                    actions.Add(x => HandleOfPropertySet(copy, x, methodReference));
                    break;
                case "OfConstructor":
                    actions.Add(x => HandleOfConstructor(copy, x, methodReference));
                    break;
                case "OfIndexerGet":
                    actions.Add(x => HandleOfIndexerGet(copy, x, methodReference));
                    break;
                case "OfIndexerSet":
                    actions.Add(x => HandleOfIndexerSet(copy, x, methodReference));
                    break;
            }
        }

        if (actions.Count == 0)
        {
            return;
        }

        using var ilProcessor = new ILProcessor(method.Body);

        foreach (var action in actions)
        {
            action(ilProcessor);
        }
    }

    TypeReference GetTypeReference(string assemblyName, string typeName)
    {
        var parsedTypeName = TypeNameParser.Parse(typeName);
        parsedTypeName.Assembly = assemblyName;
        return GetTypeReference(parsedTypeName);
    }

    TypeReference GetTypeReference(ParsedTypeName parsedTypeName)
    {
        ModuleDefinition moduleDefinition;

        var assemblyName = parsedTypeName.Assembly;
        var typeName = parsedTypeName.TypeName;

        if (assemblyName == ModuleDefinition.Assembly.Name.Name)
        {
            moduleDefinition = ModuleDefinition;
        }
        else
        {
            var assemblyDefinition = ModuleDefinition.AssemblyResolver.Resolve(new AssemblyNameReference(assemblyName, null));
            if (assemblyDefinition == null)
            {
                throw new WeavingException($"Could not find assembly named '{assemblyName}'.");
            }

            moduleDefinition = assemblyDefinition.MainModule;
        }

        var typeDefinition = moduleDefinition.GetTypes().FirstOrDefault(x => x.FullName == typeName);
        if (typeDefinition != null)
        {
            return MakeGeneric(typeDefinition);
        }

        var exportedType = moduleDefinition.ExportedTypes
            .FirstOrDefault(x => x.FullName == typeName)?.Resolve();
        if (exportedType != null)
        {
            return MakeGeneric(exportedType);
        }

        throw new WeavingException($"Could not find type named '{typeName}'.");

        TypeReference MakeGeneric(TypeReference typeReference)
        {
            if (typeReference.HasGenericParameters && parsedTypeName.GenericParameters != null)
            {
                if (typeReference.GenericParameters.Count != parsedTypeName.GenericParameters.Count)
                {
                    throw new WeavingException($"Supplied generic parameter arity of {parsedTypeName.GenericParameters.Count} does not match expected arity of {typeReference.GenericParameters.Count} for {parsedTypeName.TypeName}");
                }

                return ModuleDefinition.ImportReference(
                    typeReference.MakeGenericInstanceType(
                        parsedTypeName.GenericParameters
                            .Select(GetTypeReference)
                            .ToArray()));
            }

            return ModuleDefinition.ImportReference(typeReference);
        }
    }

    string GetLdString(Instruction previous)
    {
        if (previous.OpCode != OpCodes.Ldstr)
        {
            WriteError("Expected a string");
        }

        return (string) previous.Operand;
    }
}