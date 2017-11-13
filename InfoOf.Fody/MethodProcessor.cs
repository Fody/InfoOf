using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

public partial class ModuleWeaver
{

    void ProcessMethod(MethodDefinition method)
    {
        var actions = new List<Action<ILProcessor>>();
        foreach (var instruction in method.Body.Instructions)
        {
            if (instruction.OpCode == OpCodes.Call)
            {
                var methodReference = instruction.Operand as MethodReference;
                if (methodReference == null)
                {
                    continue;
                }
                if (methodReference.DeclaringType.Name != "Info")
                {
                    continue;
                }
                var copy = instruction;
                if (methodReference.Name == "OfMethod")
                {
                    actions.Add(x => HandleOfMethod(copy,x,methodReference));
                    continue;
                }
                if (methodReference.Name == "OfField")
                {
                    actions.Add(x => HandleOfField(copy,x));
                    continue;
                }
                if (methodReference.Name == "OfType")
                {
                    actions.Add(x => HandleOfType(copy,x));
                    continue;
                }
                if (methodReference.Name == "OfPropertyGet")
                {
                    actions.Add(x => HandleOfPropertyGet(copy,x));
                    continue;
                }
                if (methodReference.Name == "OfPropertySet")
                {
                    actions.Add(x => HandleOfPropertySet(copy,x));
                }
            }
        }
        if (actions.Count == 0)
        {
            return;
        }
        method.Body.SimplifyMacros();
        foreach (var action in actions)
        {
            action(method.Body.GetILProcessor());
        }
        method.Body.OptimizeMacros();
    }

    TypeDefinition GetTypeDefinition(string assemblyName, string typeName)
    {
        ModuleDefinition moduleDefinition;
        if (assemblyName == ModuleDefinition.Assembly.Name.Name)
        {
            moduleDefinition = ModuleDefinition;
        }
        else
        {
            var assemblyDefinition = AssemblyResolver.Resolve(new AssemblyNameReference(assemblyName, null));
            if (assemblyDefinition == null)
            {
                throw new WeavingException($"Could not find assembly named '{assemblyName}'.");
            }
            moduleDefinition = assemblyDefinition.MainModule;
        }

        var typeDefinition = moduleDefinition.GetTypes().FirstOrDefault(x => x.FullName == typeName);
        if (typeDefinition != null)
        {
            return typeDefinition;
        }

        var exportedType = moduleDefinition.ExportedTypes
            .FirstOrDefault(x => x.FullName == typeName);
        if (exportedType != null)
        {
            return exportedType.Resolve();
        }
        throw new WeavingException($"Could not find type named '{typeName}'.");
    }


    string GetLdString(Instruction previous)
    {
        if (previous.OpCode != OpCodes.Ldstr)
        {
            LogError("Expected a string");
        }
        return (string) previous.Operand;
    }
}