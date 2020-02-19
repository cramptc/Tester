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
}
