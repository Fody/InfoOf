using Fody;

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