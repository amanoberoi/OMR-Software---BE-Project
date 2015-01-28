using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public class QPCODE
    {
         public int place, digit;
        public Coordinate coordinate;

        public QPCODE(int p, int d, Coordinate c)
        {
            place = p; digit = d; coordinate = c;
        }
    }
}
