using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Complex : Data, IComparable<Complex>
    {
        public int _oxstate;
        public string _name;
        public string _state;
        public string _colour;
        public int _charge;
        public string _metal;

        public Complex(int oxs, string metal, string name, string state, string colour, int charge)
        {
            _metal = metal;
            _oxstate = oxs;
            _name = name;
            _state = state;
            _colour = colour;
            _charge = charge;

        }

        public int CompareTo(Complex other)
        {
            if (other.Score[1] - other.Score[0] > this.Score[1] - this.Score[0]) { return 1; }
            if (other.Score[1] - other.Score[0] < this.Score[1] - this.Score[0]) { return -1; }
            if (other.Score[1] - other.Score[0] == this.Score[1] - this.Score[0]) { return 0; }
            return 0;
        }
    }
    public class TMetalHandler : AlphaHandler { 
        public List<Complex> CreateQuestions()
        {
            List<Complex> cmplx = new List<Complex>
            {
                //         Oxs  Metal  Ion Name     State     Colour                        Charge
                new Complex(2, "Fe", "Fe",          "aq",   "Pale Green",                    2),
                new Complex(2, "Fe", "Fe(OH)2",     "s",    "Dirty Green",                   0),
                new Complex(3, "Fe", "Fe",          "aq",   "Yellow",                        3),
                new Complex(3, "Fe", "Fe(OH)3",     "s",    "Brown",                         0),
                new Complex(3, "Fe", "FeSCN",       "aq",   "Blood Red",                     2),
                new Complex(2, "Cu", "Cu",          "aq",   "Blue",                          2),
                new Complex(2, "Cu", "CuCl4",       "aq",   "Yellow/Green(Equilibrium)",    -2),
                new Complex(2, "Cu", "Cu(NH3)4",    "aq",   "Deep Blue",                     2),
                new Complex(2, "Cu", "Cu(OH)2",     "s",    "Pale Blue",                     0),
                new Complex(3, "Cr", "Cr",          "aq",   "Green",                         3),
                new Complex(3, "Cr", "Cr(OH)6",     "aq",   "Green",                        -3),
                new Complex(3, "Cr", "Cr(NH3)6",    "aq",   "Purple",                        3),
                new Complex(3, "Cr", "Cr(OH)3",     "s",    "Green",                         0),
                new Complex(6, "Cr", "Cr2O7",       "aq",   "Orange",                       -2),
                new Complex(2, "Co", "Co",          "aq",   "Pink",                          2),
                new Complex(2, "Co", "Co(NH3)6",    "aq",   "Pale Yellow",                   2),
                new Complex(2, "Co", "CoCl4",       "aq",   "Deep Blue",                    -2),
                new Complex(7, "Mn", "MnO4",        "aq",   "Purple",                       -1),
                new Complex(2, "Mn", "Mn",          "aq",   "Pale Pink",                     2),
                new Complex(2, "Mn", "Mn(OH)2",     "s",    "Pale Pink --> Brown",           0),
                new Complex(4, "Mn", "MnO2",        "s",    "Black",                         0)
            };
            //cmplx.Add(new Complex(0, "Cu", "Cu", "s", "Brown", 0));
            //cmplx.Add(new Complex(1, "Cu", "CuI", "s", "White", 0));
            //cmplx.Add(new Complex(1, "Cu", "CuCl", "s", "White", 0));
            //cmplx.Add(new Complex(1, "Cu", "(Cu)2(SO4)", "s", "White", 0));
            return cmplx;
        }

        public void TMetalsA()
        {
            List < Complex > cmplx = CreateQuestions();
            Complex Last = new Complex(0, "", "", "", "", 0);
            while (true)
            {
                cmplx.Sort();
                Complex Question = cmplx[rnd.Next(5)];
                while (Question._name == Last._name) { Question = cmplx[rnd.Next(5)]; }
                Console.WriteLine("Ion: \t\t\t" + Question._name + "\nOxidation State: \t" + Question._oxstate + "\nCharge: \t\t" + Question._charge);
                Console.ReadLine();
                Console.WriteLine("Colour: \t\t" + Question._colour + "\nState: \t\t\t" + Question._state);

                string ans = Console.ReadLine();
                if (ans == "l") break;
                Question.Score = GetMark(ans);

                Last = Question;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n"); ;
            }
            cmplx.Sort();
            foreach (Complex i in cmplx) { Console.WriteLine(i._name + "  " + i._oxstate + "\t\t\t\t\t Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.WriteLine("\nPress enter to return to main menu.");
            Console.ReadLine();
            PrintOptions();

        }

        public void TMetalsB()
        {
            List<Complex> cmplx = CreateQuestions();
            Complex Last = new Complex(0, "", "", "", "", 0);
            while (true)
            {
                cmplx.Sort();
                Complex Question = cmplx[rnd.Next(5)];
                while (Question._name == Last._name) { Question = cmplx[rnd.Next(5)]; }
                Console.WriteLine("Colour: \t\t" + Question._colour + "\nState: \t\t\t" + Question._state + "\nMetal: \t\t\t" + Question._metal);
                Console.ReadLine();
                Console.WriteLine("Ion: \t\t\t" + Question._name + "\nCharge: \t\t" + Question._charge);

                string ans = Console.ReadLine();
                if (ans == "l") break;
                Question.Score = GetMark(ans);

                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
                Last = Question;
            }
            cmplx.Sort();
            foreach (Complex i in cmplx) { Console.WriteLine(i._name + "  " + i._oxstate + "\t\t\t\t\t Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();
            PrintOptions();

        }
    }
}
