using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public class Coordinate
    {
        public double x;
        public double y;
        public Coordinate() { x = 0.0; y = 0.0; }
        public Coordinate(double x, double y)
        { this.x = x; this.y = y; }
    }
}
