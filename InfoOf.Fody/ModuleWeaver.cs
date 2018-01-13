using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;

public partial class ModuleWeaver:BaseModuleWeaver
{
    List<TypeDefinition> allTypes;

    public override void Execute()
    {
        allTypes = ModuleDefinition.GetTypes().ToList();
        FindReferences();
        ProcessMethods();
        CleanReferences();
    }
}