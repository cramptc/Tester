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
}
