using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class QTests : Data, IComparable<QTests>
    {
        public string _species;
        public string _test;
        public string _obsevations;
        public string _notes;
        public int CompareTo(QTests other)
        {
            if (other.Score[1] - other.Score[0] > this.Score[1] - this.Score[0]) { return 1; }
            if (other.Score[1] - other.Score[0] < this.Score[1] - this.Score[0]) { return -1; }
            if (other.Score[1] - other.Score[0] == this.Score[1] - this.Score[0]) { return 0; }
            return 0;
        }

        public QTests(string species, string test, string observe, string notes) { _species = species; _test = test; _obsevations = observe; _notes = notes; }
    }
    public class QTestHandler : AlphaHandler
    {
        public List<QTests> CreateQuestions()
        {
            List<QTests> qtests = new List<QTests>
            {
                new QTests("Cl-","Add nitric Acid (removes CO3- ions as AgCO3 forms white ppt), Add silver nitrate","White ppt forms","Soluble in dillute NH3"),
            new QTests("Br-", "Add nitric Acid (removes CO3- ions as AgCO3 forms white ppt), Add silver nitrate", "Cream ppt forms", "Soluble in Conc NH3"),
            new QTests("I-", "Add nitric Acid (removes CO3- ions as AgCO3 forms white ppt), Add silver nitrate", "Yellow ppt forms", "Insoluble in Conc NH3"),
            new QTests("CO3 2-", "Add Strong Acid to sample, Collect the gas produced, Test gas for CO2", "Effervescence, Cloudy Limewater", ""),
            new QTests("SO4 2-","Add dilute hydrohloric acid and barium sulphate","White ppt forms",""),
            new QTests("NH4+","Add sodium hydroxide and boil, test the gas produced with red litmus paper","Turns red litmus paper blue","Smells Pungent")
            };
            return qtests;
        }
        public void QTestA()
        {
            List<QTests> qtest = CreateQuestions();
            QTests Last = new QTests("","","","");
            while (true)
            {
                qtest.Sort();
                QTests Question = qtest[rnd.Next(5)];
                while (Question._species == Last._species) { Question = qtest[rnd.Next(5)]; }
                Console.WriteLine("Species: \t\t\t" + Question._species);
                Console.ReadLine();
                Console.WriteLine("Test: \t\t" + Question._test + "\nObservations: \t\t\t" + Question._obsevations+"\nNotes: \t\t\t"+Question._notes);

                string ans = Console.ReadLine();
                if (ans == "l") break;
                Question.Score = GetMark(ans);

                Last = Question;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n"); ;
            }
            qtest.Sort();
            foreach (QTests i in qtest) { Console.WriteLine(i._species + "\t\t\t\t\t Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.WriteLine("\nPress enter to return to main menu.");
            Console.ReadLine();
            PrintOptions();

        }
        public void QTestB()
        {
            List<QTests> qtest = CreateQuestions();
            QTests Last = new QTests("", "", "", "");
            while (true)
            {
                qtest.Sort();
                QTests Question = qtest[rnd.Next(5)];
                while (Question._species == Last._species) { Question = qtest[rnd.Next(5)]; }
                Console.WriteLine("Test: \t\t\t" + Question._test+"\nObservations: \t\t\t"+Question._obsevations);
                Console.ReadLine();
                Console.WriteLine("Species: \t\t" + Question._species + "\nNotes: \t\t\t" + Question._notes);

                string ans = Console.ReadLine();
                if (ans == "l") break;
                Question.Score = GetMark(ans);

                Last = Question;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n"); ;
            }
            qtest.Sort();
            foreach (QTests i in qtest) { Console.WriteLine(i._species + "\t\t\t\t\t Correct: " + i.Score[0] + " Wrong: " + i.Score[1]); }
            Console.WriteLine("\nPress enter to return to main menu.");
            Console.ReadLine();
            PrintOptions();

        }

    }
}
