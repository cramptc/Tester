using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Complex : ITestable, IComparable<Complex>
    {
        public int _oxstate;
        public string _name;
        public string _state;
        public string _colour;
        public int _charge;
        public string _metal;
        int[] score = new int[2] { 0, 0 };
        public Complex(int oxs, string metal, string name, string state, string colour, int charge)
        {
            _metal = metal;
            _oxstate = oxs;
            _name = name;
            _state = state;
            _colour = colour;
            _charge = charge;
        }
        public int[] Score { get { return score; } set { score[0] += value[0]; score[1] += value[1]; } }
        public int CompareTo(Complex other)
        {
            if (other.Score[1] - other.Score[0] > this.Score[1] - this.Score[0]) { return 1; }
            if (other.Score[1] - other.Score[0] < this.Score[1] - this.Score[0]) { return -1; }
            if (other.Score[1] - other.Score[0] == this.Score[1] - this.Score[0]) { return 0; }
            return 0;
        }
    }
    public class TMetalHandler:IHandler
    {
        Random rnd = new Random();
        public List<Complex> CreateQuestions()
        {
            List<Complex> cmplx = new List<Complex> { };
            cmplx.Add(new Complex(2, "Fe", "Fe", "aq", "Pale Green", 2));
            cmplx.Add(new Complex(2, "Fe", "Fe(OH)2", "s", "Dirty Green", 0));
            cmplx.Add(new Complex(3, "Fe", "Fe", "aq", "Yellow", 3));
            cmplx.Add(new Complex(3, "Fe", "Fe(OH)3", "s", "Red/Brown", 0));
            cmplx.Add(new Complex(3, "Fe", "FeSCN", "aq", "Blood Red", 2));
            //cmplx.Add(new Complex(0, "Cu", "Cu", "s", "Brown", 0));
            //cmplx.Add(new Complex(1, "Cu", "CuI", "s", "White", 0));
            //cmplx.Add(new Complex(1, "Cu", "CuCl", "s", "White", 0));
            //cmplx.Add(new Complex(1, "Cu", "(Cu)2(SO4)", "s", "White", 0));
            cmplx.Add(new Complex(2, "Cu", "Cu", "aq", "Blue", 2));
            cmplx.Add(new Complex(2, "Cu", "CuCl4", "aq", "Yellow/Green(Equilibrium)", -2));
            cmplx.Add(new Complex(2, "Cu", "Cu(NH3)4", "aq", "Deep Blue", 2));
            cmplx.Add(new Complex(2, "Cu", "Cu(OH)2", "s", "Pale Blue", 0));
            cmplx.Add(new Complex(3, "Cr", "Cr", "aq", "Green", 3));
            cmplx.Add(new Complex(3, "Cr", "Cr(OH)6", "aq", "Deep Green", -3));
            cmplx.Add(new Complex(3, "Cr", "Cr(NH3)6", "aq", "Violet", 3));
            cmplx.Add(new Complex(3, "Cr", "Cr(OH)3", "aq", "Pale Green", 0));
            cmplx.Add(new Complex(6, "Cr", "Cr2O7", "aq", "Orange", -2));
            cmplx.Add(new Complex(2, "Co", "Co", "aq", "Pink", 2));
            cmplx.Add(new Complex(2, "Co", "Co(NH3)6", "aq", "Pale Yellow", 2));
            cmplx.Add(new Complex(2, "Co", "CoCl4", "aq", "Deep Blue", -2));
            cmplx.Add(new Complex(6, "Mn", "MnO4", "aq", "Green", -2));
            cmplx.Add(new Complex(7, "Mn", "MnO4", "aq", "Purple", -1));
            cmplx.Add(new Complex(2, "Mn", "Mn", "aq", "Pale Pink", 2));
            cmplx.Add(new Complex(2, "Mn", "Mn(OH)2", "aq", "Pale Brown", 2));
            return cmplx;
        }

        public void TMetalsA()
        {
            List < Complex > cmplx = CreateQuestions();
            Complex Last = new Complex(0, "", "", "", "", 0);
            while (true)
            {
                int[] mark = new int[2] { 0, 0 };
                cmplx.Sort();
                Complex Question = cmplx[rnd.Next(5)];
                while (Question._name == Last._name) { Question = cmplx[rnd.Next(5)]; }
                Console.WriteLine(Question._name + " Oxidation State: " + Question._oxstate + " Charge: " + Question._charge);
                Console.ReadLine();
                Console.WriteLine(Question._colour + "  " + Question._state);
                string ans = Console.ReadLine();
                if (ans == "l") { break; }
                if (ans != "") { if (Convert.ToInt16(ans) == 1) { mark[0] = 1; } }
                else { mark[1] = 1; }
                Question.Score = mark;
                Last = Question;
                Console.WriteLine();
            }
            cmplx.Sort();
            foreach (Complex i in cmplx) { Console.WriteLine(i._name + "  " + i._oxstate + "                  Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();

        }

        public void TMetalsB()
        {
            List<Complex> cmplx = CreateQuestions();
            Complex Last = new Complex(0, "", "", "", "", 0);
            while (true)
            {
                int[] mark = new int[2] { 0, 0 };
                cmplx.Sort();
                Complex Question = cmplx[rnd.Next(5)];
                while (Question._name == Last._name) { Question = cmplx[rnd.Next(5)]; }
                Console.WriteLine(Question._colour + " " + Question._state + "   " + Question._metal);
                Console.ReadLine();
                Console.WriteLine(Question._name + "  " + Question._charge);
                string ans = Console.ReadLine();
                if (ans == "l") { break; }
                if (ans != "") { if (Convert.ToInt16(ans) == 1) { mark[0] = 1; } }
                else { mark[1] = 1; }
                Question.Score = mark;
                Console.WriteLine();
                Last = Question;
            }
            cmplx.Sort();
            foreach (Complex i in cmplx) { Console.WriteLine(i._name + "  " + i._oxstate + "                  Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();

        }
    }
}
