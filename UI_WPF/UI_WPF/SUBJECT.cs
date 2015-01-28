using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public class SUBJECT
    {
        public int place, digit;
        public Coordinate coordinate;

        public SUBJECT(int p, int d, Coordinate c)
        {
            place = p; digit = d; coordinate = c;
        }
    }
}
