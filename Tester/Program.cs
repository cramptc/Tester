using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            TMetalHandler tm = new TMetalHandler();
            SynthHandler sy = new SynthHandler();
            Console.WriteLine("To Test Yourself on Transition Metals by colour and metal ion: Tb");
            Console.WriteLine("Transition Metals by Complex: Ta");
            Console.WriteLine("Synthetic routes by Knowing Conditions and Starting Materials: Sa");
            Console.WriteLine("Synthetic routes by Knowing Description: Sb");
            Console.WriteLine("Type 1 after the answer comes up and press enter to show you got it right " +
                "and the program will give you one of your worst few questions next, type nothing if you got it wrong and press enter");
            Console.WriteLine("When Done type l and press enter after an ansewr comes up to show what you answered well");
            while (true) {
                string decision = Console.ReadLine();
                if (decision == "Ta") { tm.TMetalsA(); }
                if (decision == "Tb") { tm.TMetalsB(); }
                if (decision == "Sa") { sy.TestSynthesisA(); }
                if (decision == "Sb") { sy.TestSynthesisB(); }
                else { Console.WriteLine("Retry none of those are options"); }
            }
        }
    }
}
