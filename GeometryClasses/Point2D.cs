using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClasses
{
    internal class Point2D : Point
    {
        public Point2D() : base(2) { }

        public Point2D(double[] x): base(2,x) { }

        public Point2D rot(Point2D p, double phi) {
            double pX = p.x[0], pY = p.x[1];
            p.x[0] = pX * Math.Cos(phi) - pY * Math.Sin(phi);
            p.x[1] = pX * Math.Sin(phi) + pY * Math.Cos(phi);
            return p;
        }

        public Point2D rot(double phi) => rot(this, phi);
    }
}
