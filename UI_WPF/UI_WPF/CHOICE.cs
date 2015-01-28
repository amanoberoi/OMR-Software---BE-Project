using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public class CHOICE
    {
        public int question_no;
        public int choice;
        public Coordinate coordinate;

        public CHOICE(int q, int c, Coordinate co)
        { question_no = q; choice = c; coordinate = co; }
    }
}
