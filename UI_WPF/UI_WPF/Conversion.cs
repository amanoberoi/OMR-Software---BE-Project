using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLRead
{
    public static class Conversion
    {
        public static double PixeltoCM(double Pixel)
        {
            double cm = 0.0;
            cm = Pixel / 200 * 2.54;
            return cm;
        }
        public static double CMtoPixel(double CM)
        {
            double pixel = 0.0;
            pixel = CM * 200 / 2.54;
            return pixel;
        }
        public static double PixeltoCM(string Pixel)
        { return PixeltoCM(Convert.ToDouble(Pixel)); }

        public static double CMtoPixel(string CM)
        { return CMtoPixel(Convert.ToDouble(CM)); }

        
    }
}
