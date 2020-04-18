#define CONDITION1
#define CONDITION2
using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Diagnostics;

namespace AppProject.Modules
{
    public class ConditionalExampleAttribute : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public ConditionalExampleAttribute() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            Console.WriteLine("Calling Method1");
            Method1(3);
            Console.WriteLine("Calling Method2");
            Method2();

            Console.WriteLine("Using the Debug class");
            Debug.Listeners.Add(new ConsoleTraceListener());
            Debug.WriteLine("DEBUG is defined");
        }

        [Conditional("CONDITION1")]
        public static void Method1(int x)
        {
            Console.WriteLine("CONDITION1 is defined");
        }

        [Conditional("CONDITION1"), Conditional("CONDITION2")]
        public static void Method2()
        {
            Console.WriteLine("CONDITION1 or CONDITION2 is defined");
        }
    }
}

