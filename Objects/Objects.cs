using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{

    public interface ITestable
    {
        int[] Score { get; set; }
        //int CompareTo(object other);
        //{
        //    if (other.Score[1] > this.Score[1]) { return 1; }
        //    if (other.Score[1] < this.Score[1]) { return -1; }
        //    if (other.Score[1] == this.Score[1]) { return 0; }
        //    return 0;
        //}
    }
    public interface IHandler
    {
        //List<object> CreateQuestions();
        void PrintOptions();
    }
    public class AlphaHandler : IHandler
    { 
        public Random rnd = new Random();
        public void PrintOptions()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("Ta: Guess COLOUR    and STATE      \tfrom \tION        and OXIDATION STATE");
            Console.WriteLine("Tb: Guess ION       and CHARGE     \tfrom \tCOLOUR     and METAL");
            Console.WriteLine("Sa: Guess MECHANISM and PRODUCT    \tfrom \tCONDITIONS and REAGENTS ");
            Console.WriteLine("Sb: Guess MECHANISM and CONDITIONS \tfrom \tREAGENTS   and PRODUCTS");
            Console.WriteLine("SaT: same as Sa, but choose only tagged questions.");
            Console.WriteLine("SbT: same as Sb, but choose only tagged questions.");
            Console.WriteLine("Qa: Guess TEST    \tfrom \tSPECIES ");
            Console.WriteLine("Qb: Guess SPECIES \tfrom \tTEST");

            Console.WriteLine("\n\nIf you answer correctly, type 1, otherwise press enter - " +
                "the program will give you one of your worst few questions next");
            Console.WriteLine("When finished type l (lowercase L) - you will see a breakdown by score.");
        }
        public int[] GetMark(string ans)
        {
            int[] mark = { 0, 0 };

            if (ans != "")
            {
                try
                {
                    Convert.ToInt16(ans);
                    if (Convert.ToInt16(ans) == 1) mark[0] = 1;
                    else mark[1] = 1;
                }
                catch (FormatException) { mark[1] = 1; };

            }
            else mark[1] = 1;

            return mark;

        }
    }
    public class Data :ITestable
    {
        int[] score = new int[2] { 0, 0 };
        public int[] Score { get { return score; } set { score[0] += value[0]; score[1] += value[1]; } }
    }
}
