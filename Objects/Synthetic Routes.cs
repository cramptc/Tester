using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Synthesis : ITestable, IComparable<Synthesis>
    {
        int[] score = new int[2] { 0, 0 };
        public string _function;
        public string _conditions;
        public string _reagents;
        public string _mechanism;
        public string _result;

        public Synthesis(string function, string conditions, string reagents, string result)
        {
            _result = result;
            _function = function;
            _reagents = reagents;
            _conditions = conditions;
            //_mechanism = mechanism
        }

        public int[] Score { get { return score; } set { score[0] += value[0]; score[1] += value[1]; } }
        public int CompareTo(Synthesis other)
        {
            if (other.Score[1] - other.Score[0] > this.Score[1] - this.Score[0]) { return 1; }
            if (other.Score[1] - other.Score[0] < this.Score[1] - this.Score[0]) { return -1; }
            if (other.Score[1] - other.Score[0] == this.Score[1] - this.Score[0]) { return 0; }
            return 0;
        }
    }
    public class SynthHandler : IHandler
    {
        Random rnd = new Random();
        public List<Synthesis> CreateQuestions() {
            List<Synthesis> synth = new List<Synthesis>();
            synth.Add(new Synthesis("", "", "",""));
            synth.Add(new Synthesis("(FRS)","UV Light","X2 + Alkane", "Haloalkane"));
            synth.Add(new Synthesis("Hydrogenation","Nickel Catalyst, 150 C","Hydrogen + Alkene","Alkane"));
            synth.Add(new Synthesis("(EA) Hydration", "Phosphoric Acid, Reflux or Heat", "Alkene + Water", "Alcohol"));
            synth.Add(new Synthesis("(EA) Halogenation", "", "X2 / HX", "Haloalkane"));
            synth.Add(new Synthesis("Polymerisation", "Peroxide Initiator + High Pressure", "Alkene + Alkene", "Addition Polymer"));
            synth.Add(new Synthesis("(NS) Hydrolysis", "Solvent of 50:50 ethanol:water, reflux", " Strong Hydroxide + Haloalkane", "Alcohol"));
            synth.Add(new Synthesis("(NS) Hydrolysis", "Silver Nitrate sln (AgNO3)", "Haloalkane + Water"," Alcohol"));
            synth.Add(new Synthesis("(FRS) Ozone depletion", "UV Light", "O3 + CFC","O2 + Cl radical"));
            synth.Add(new Synthesis("(Elimination) Dehydration","Sulfuric/Phosphoric Acid, 200 C"," Alcohol","Alkene"));
            synth.Add(new Synthesis("Hydrolysis", "Acid+Water(reagents),Reflux", "Nitrile", "Carboxylic Acid + Ammonium"));
            synth.Add(new Synthesis("Nitration", "conc. Nitric Acid(Reagent) + conc. Sulfuric Acid, 55 C", "Benzene", "Nitrobenzene + Water"));
            synth.Add(new Synthesis("Hydrogenation", "Ni/Pt/Pd", "Hydrogen+Nitrile", "Amine"));
            synth.Add(new Synthesis("Reduction/Hydrogenation", "Ethanol", "Haloalkane + CN- ion (eg NaCN)", "Nitrile"));
            return synth;
        }
        public void TestSynthesisA()
        {
            List<Synthesis> synth = new List<Synthesis> { };
            Synthesis Last = new Synthesis("", "", "", "");
            while (true)
            {
                int[] mark = new int[2] { 0, 0 };
                synth.Sort();
                Synthesis Question = synth[rnd.Next(5)];
                while (Question._function == Last._function) { Question = synth[rnd.Next(5)]; }
                Console.WriteLine(Question._conditions + "   and   " + Question._reagents);
                Console.ReadLine();
                Console.WriteLine(Question._function + "  gives: " + Question._result);
                string ans = Console.ReadLine();
                if (ans == "l") { break; }
                if (ans != "") { if (Convert.ToInt16(ans) == 1) { mark[0] = 1; } }
                else { mark[1] = 1; }
                Question.Score = mark;
                Last = Question;
                Console.WriteLine();
            }
            synth.Sort();
            foreach (Synthesis i in synth) { Console.WriteLine(i._function + "                  Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();
        }
        public void TestSynthesisB()
        {
            List<Synthesis> synth = new List<Synthesis> { };
            Synthesis Last = new Synthesis("", "", "", "");
            while (true)
            {
                int[] mark = new int[2] { 0, 0 };
                synth.Sort();
                Synthesis Question = synth[rnd.Next(5)];
                while (Question._function == Last._function) { Question = synth[rnd.Next(5)]; }
                Console.WriteLine("What do you need to make " + Question._reagents + " become  " + Question._result);
                Console.ReadLine();
                Console.WriteLine(Question._function + "   " + Question._conditions);
                string ans = Console.ReadLine();
                if (ans == "l") { break; }
                if (ans != "") { if (Convert.ToInt16(ans) == 1) { mark[0] = 1; } }
                else { mark[1] = 1; }
                Question.Score = mark;
                Last = Question;
                Console.WriteLine();
            }
            synth.Sort();
            foreach (Synthesis i in synth) { Console.WriteLine(i._function + "                  Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();
        }
    }
}
