using System.Linq;

public partial class ModuleWeaver
{
    public void ProcessMethods()
    {
        foreach (var type in allTypes)
        {
            foreach (var method in type.Methods.Where(x=>x.HasBody))
            {
                ProcessMethod(method);
            }
        }
    }
}