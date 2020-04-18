using AppProject.Core.Module;
using AppProject.Core.Print;
using System;

namespace AppProject.Modules
{
    public class ObsoleteExampleAttribute : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public ObsoleteExampleAttribute() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            ThisClass test = new ThisClass();
        }
    }

    [Obsolete("ThisClass is obsolete. Use ThisClass2 instead.")]
    public class ThisClass
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class MyAttributeForClassAndStructOnly : Attribute
    {
    }

    public class Foo
    {
        // if the below attribute was uncommented, it would cause a compiler error
        //[MyAttributeForClassAndStructOnly]
        public Foo()
        { }
    }
}

