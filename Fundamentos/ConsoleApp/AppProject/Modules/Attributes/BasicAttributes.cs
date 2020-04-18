using AppProject.Core.Module;
using AppProject.Core.Print;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicAttributes : ModulesNestedBase, IModule
    {

        public BasicAttributes() : base(new ConsolePrinter(),new Collection<IModule>() { new ConditionalExampleAttribute() })
        {
            
        }
    }
}
