using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionVykreslovani
{
    public static class Extensions
    {
        public static float Distance(this Point point, Point other) {
            
            return (float)Math.Sqrt(Math.Pow(Math.Abs(point.X - other.X), 2) + 
                Math.Pow(Math.Abs(point.Y - other.Y), 2));

        }
    }
}
