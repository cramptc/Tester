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
}
