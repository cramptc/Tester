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
        //I'm fairly sure the _ naming standard is for non public variables, but whatever.
        public string _function;
        public string _conditions;
        public string _reagents;
        public string _mechanism;
        public string _result;

        public int _tag;

        public Synthesis(string function, string conditions, string reagents, string result, int tag)
        {
            _result = result;
            _function = function;
            _reagents = reagents;
            _conditions = conditions;
            _tag = tag;

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

    public class SynthHandler : AlphaHandler
    {

        public List<Synthesis> CreateQuestions(List<int> tags)
        {
            List<Synthesis> synth = new List<Synthesis>
            {
                //              Reaction                                Conditions                                             Reagents                         Products                              Tag
                new Synthesis("(FRS) Halogenation",             "UV Light",                                               "X2 + Alkane",                        "Haloalkane",                         1),

                new Synthesis("Hydrogenation",                  "Nickel Catalyst, 150 C",                                 "Hydrogen + Alkene",                  "Alkane",                             2),
                new Synthesis("(EA) Hydration",                 "Phosphoric Acid, Reflux or Heat",                        "Alkene + Water",                     "Alcohol",                            2),
                new Synthesis("(EA) Halogenation",              "",                                                       "X2 / HX + Alkene",                   "Haloalkane",                         2),
                new Synthesis("Polymerisation",                 "Peroxide Initiator, High Pressure",                      "Alkene + Alkene",                    "Addition Polymer",                   2),

                new Synthesis("(NS) Hydrolysis",                "",                                                       "NaOH + Haloalkane",                  "Alcohol",                            3),
                new Synthesis("(NS) Hydrolysis",                "Silver Nitrate sln (AgNO3)",                             "Haloalkane + Water",                 "Alcohol",                            3),
                new Synthesis("(FRS) Ozone depletion",          "UV Light",                                               "O3 + CFC",                           "O2 + Cl radical",                    3),

                new Synthesis("(Elimination) Dehydration",      "Sulfuric/Phosphoric Acid, 200 C",                        "Alcohol",                            "Alkene",                             4),
                new Synthesis("Substitution w/ Halide ions",    "",                                                       "Alcohol + NaX + H2SO4",              "Halogenoalkane",                     4),
                new Synthesis("Oxidation (primary Alcohol)",    "K2Cr2O7, H2SO4, Distil/Reflux",                          "Primary Alcohol",                    "Aldehyde/Carboxylic acid",           4),
                new Synthesis("Oxidation (secondary Alcohol)",  "K2Cr2O7, H2SO4, heat",                                   "Secondary Alcohol",                  "Ketone",                             4),

                new Synthesis("Hydrolysis",                     "Acid+Water(reagents),Reflux",                            "Nitrile + Dilute Acid",              "Carboxylic Acid + Ammonium",         5),
                new Synthesis("Hydrogenation",                  "Nickel Catalyst",                                        "Hydrogen + Nitrile",                 "Amine",                              5),
                new Synthesis("(NS) Nitriles from Haloalkanes", "Ethanol",                                                "Haloalkane + KCN (or other CN-)",    "Nitrile",                            5),
                new Synthesis("(NA) Nitriles from Carbonyls",   "Acidic",                                                 "Carbonyl + HCN (NaCN/H+)",           "Hydroxynitrile",                     5),

                new Synthesis("(ES) Nitration",                 "conc. Nitric Acid(Reagent) + conc. Sulfuric Acid, 55 C", "Benzene",                            "Nitrobenzene + Water",               6),
                new Synthesis("Arene Hydrogenation",            "Nickel Catalyst",                                        "Benzene, H2",                        "Cycloalkane",                        6),
                new Synthesis("(ES) Arene Halogenation",        "FeX3 or AlX3 Catalyst",                                  "Benzene, X2",                        "Halogenobenzene",                    6),
                new Synthesis("(ES) FC Alkylation",             "FeX3 or AlX3 catalyst",                                  "Benzene + Halogenoalkane",           "Benzene w/ Alkane side chain",       6),
                new Synthesis("(ES) FC Alcylation",             "FeX3 or AlX3 catalyst",                                  "Benzene + Acyl Chloride",            "Benzene w/ Acyl side chain",         6),

                new Synthesis("Neutralisation",                 "Alkaline (OH-)",                                         "Phenol + NaOH",                      "Phenoxide Salt + H2O",               7),
                new Synthesis("Phenol + Carbonates",            "Any",                                                    "Phenol + Carbonate",                 "No reaction",                        7),
                new Synthesis("(ES) Phenol Halogenation",       "RTP",                                                    "Phenol + X2",                        "2,4,6, tri halogeno phenol",         7),
                new Synthesis("(ES) Phenol Nitration",          "RTP",                                                    "Phenol + HNO3 (dilute)",             "2/4 nitro phenol",                   7),
                new Synthesis("(ES) Phenol Tri-nitration",      "Conc. Acid",                                             "Phenol + HNO3 (conc)",               "2,4,6, tri nitro phenol",            7),
                new Synthesis("Esterification",                 "",                                                       "Phenol + Acyl Chloride",             "Ester + HCl",                        7),

                new Synthesis("Oxidation (Aldehydes)",          "K2Cr2O7, H2SO4",                                         "Aldehyde",                           "Carboxylic Acid",                    8),
                new Synthesis("(NA) Reduction (Aldehydes)",     "NaBH4, Aqueous work up",                                 "Aldehyde + NaBH4",                   "Primary Alcohol",                    8),
                new Synthesis("(NA) Reduction (Ketones)",       "NaBH4, Aqueous work up",                                 "Ketone + NaBH4",                     "Secondary Alcohol",                  8),
                new Synthesis("Brady's Test",                   "2,4-DNPH in acidifed methanol",                          "Carbonyl + Brady's reagent",         "2,4 Dinitrophnyl-hydrazone",         8),
                new Synthesis("Tollen's Test",                  "Ammoniacal AgNO3",                                       "Aldehyde + Tollen's reagent",        "Ag + Carboxylate salt",              8)

            };


            List<Synthesis> ToRemove = new List<Synthesis>();

            if (tags != null)
            {
                foreach (Synthesis s in synth) if (!tags.Contains(s._tag)) ToRemove.Add(s);
                foreach (Synthesis s in ToRemove) synth.Remove(s);
            }


            return synth;
        }


        public void TestSynthesisA(List<int> tags = null)
        {
            List<Synthesis> synth = CreateQuestions(tags);
            Synthesis Last = new Synthesis("", "", "", "", 0);
            while (true)
            {
                synth.Sort();
                Synthesis Question = synth[rnd.Next(Math.Min(5, synth.Count()))];
                while (Question._function == Last._function) Question = synth[rnd.Next(Math.Min(5, synth.Count()))]; 
                Console.WriteLine("Conditions: " + Question._conditions + ", Reagents: " + Question._reagents);
                Console.ReadLine();
                Console.WriteLine("Mechanism Name: " + Question._function + ", Products: " + Question._result);

                string ans = Console.ReadLine();
                if (ans == "l") break;
                Question.Score = GetMark(ans);

                Last = Question;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            }
            synth.Sort();
            foreach (Synthesis i in synth) { Console.WriteLine(i._function + "\t\t\t\t\t Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();
            PrintOptions();
        }

        public void TestSynthesisB(List<int> tags = null)
        {
            List<Synthesis> synth = CreateQuestions(tags);
            Synthesis Last = new Synthesis("", "", "", "", 0);
            while (true)
            {
                synth.Sort();
                Synthesis Question = synth[rnd.Next(Math.Min(5, synth.Count()))];
                while (Question._function == Last._function) Question = synth[rnd.Next(Math.Min(5, synth.Count()))];
                Console.WriteLine("Name the mechanism and conditions for " + Question._reagents + " ---> " + Question._result);
                Console.ReadLine();
                Console.WriteLine("Mechanism Name: " + Question._function + ", Conditions:  " + Question._conditions);
               
                string ans = Console.ReadLine();
                if (ans == "l") break;
                Question.Score = GetMark(ans);

                Last = Question;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            }

            synth.Sort();
            foreach (Synthesis i in synth) { Console.WriteLine(i._function + "\t\t\t\t\t Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.ReadLine();
            PrintOptions();
        }

        public List<int> GetTags()
        {
            List<int> tags = new List<int>();

            //I cba with input validation, how stupid can the user be????
            Console.WriteLine("Please type a list of tags you'd like to use, separated by commas (,). Options:");
            Console.WriteLine("1 - Alkanes\n2 - Alkenes\n3 - Haloalkanes\n4 - Alcohols\n5 - Nitriles\n6 - Benzene/Arenes\n7 - Phenol");

            string[] inp = Console.ReadLine().Split(',');


            foreach (string s in inp) tags.Add(int.Parse(s));
            if(tags.Count() == 1 && tags[0] == 1)
            {
                Console.WriteLine("Sorry, there is literally only 1 synthesis in your chosen tag. Please choose more.");
                tags = GetTags();
            }
            return tags;
        }

    }
}