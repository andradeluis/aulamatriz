using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Modules
{
    public class CustomAttributes : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public CustomAttributes() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            
        }
    }

    [Developer("Joan Smith", "1")]
    public class Data { }

    [Developer("Joan Smith", "1", Reviewed = true)]
    public class Business { }

    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperAttribute : Attribute
    {
        // Private fields.
        private string name;
        private string level;
        private bool reviewed;

        // This constructor defines two required parameters: name and level.

        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }

        // Define Name property.
        // This is a read-only attribute.

        public virtual string Name
        {
            get { return name; }
        }

        // Define Level property.
        // This is a read-only attribute.

        public virtual string Level
        {
            get { return level; }
        }

        // Define Reviewed property.
        // This is a read/write attribute.

        public virtual bool Reviewed
        {
            get { return reviewed; }
            set { reviewed = value; }
        }
    }
}
