using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public class BLOB : Coordinate
    {
        public double radius;

        public BLOB(Coordinate c, double radius)
        {
            this.radius = radius;
            this.x = c.x;
            this.y = c.y;
        }
    }
}
