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

        public static void PrintOptions()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("Ta: Guess COLOUR    and STATE      \tfrom \tION        and OXIDATION STATE");
            Console.WriteLine("Tb: Guess ION       and CHARGE     \tfrom \tCOLOUR     and METAL");
            Console.WriteLine("Sa: Guess MECHANISM and PRODUCT    \tfrom \tCONDITIONS and REAGENTS ");
            Console.WriteLine("Sb: Guess MECHANISM and CONDITIONS \tfrom \tREAGENTS   and PRODUCTS");
            Console.WriteLine("Qa: Guess TEST    \tfrom \tSPECIES ");
            Console.WriteLine("Qb: Guess SPECIES \tfrom \tTEST");

            Console.WriteLine("SaT: same as Sa, but choose only tagged questions.");
            Console.WriteLine("SbT: same as Sb, but choose only tagged questions.");

            Console.WriteLine("\n\nIf you answer correctly, type 1, otherwise press enter - " +
                "the program will give you one of your worst few questions next");
            Console.WriteLine("When finished type l (lowercase L) - you will see a breakdown by score.");
        }

        static void Main(string[] args)
        {
            TMetalHandler tm = new TMetalHandler();
            SynthHandler sy = new SynthHandler();
            QTestHandler qa = new QTestHandler();

            PrintOptions();

            while (true)
            {

                switch(Console.ReadLine()){
                    case "Ta":
                        tm.TMetalsA();
                        break;
                    case "Tb":
                        tm.TMetalsB();
                        break;
                    case "Sa":
                        sy.TestSynthesisA();
                        break;
                    case "Sb":
                        sy.TestSynthesisB();
                        break;
                    case "SaT":
                        sy.TestSynthesisA(sy.GetTags());
                        break;
                    case "SbT":
                        sy.TestSynthesisB(sy.GetTags());
                        break;
                    case "Qa":
                        qa.QTestA();
                        break;
                    case "Qb":
                        qa.QTestB();
                        break;
                    default:
                        Console.WriteLine("Sorry, not a recognised option. Please try again.");
                        break;

                }

            }
        }
       
    }
}
