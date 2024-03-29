public partial class ModuleWeaver
{
    public void CleanReferences()
    {
        var referenceToRemove = ModuleDefinition.AssemblyReferences.FirstOrDefault(_ => _.Name == "InfoOf");
        if (referenceToRemove == null)
        {
            WriteInfo("\tNo reference to 'InfoOf.dll' found. References not modified.");
            return;
        }

        ModuleDefinition.AssemblyReferences.Remove(referenceToRemove);
        WriteInfo("\tRemoving reference to 'InfoOf.dll'.");
    }
}