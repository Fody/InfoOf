using System.Linq;

public partial class ModuleWeaver
{
    public void CleanReferences()
    {
        var referenceToRemove = ModuleDefinition.AssemblyReferences.FirstOrDefault(x => x.Name == "InfoOf");
        if (referenceToRemove == null)
        {
            LogInfo("\tNo reference to 'InfoOf.dll' found. References not modified.");
            return;
        }

        ModuleDefinition.AssemblyReferences.Remove(referenceToRemove);
        LogInfo("\tRemoving reference to 'InfoOf.dll'.");
    }
}