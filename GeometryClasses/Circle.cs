using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClasses
{
    internal class Circle: IShape
    {
        Point2D p;
        double r;
        public Circle(Point2D p, double r)
        {
            this.p = p;
            this.r = r;
        }
        public Point2D getP() => p;
        public double getR() => r;
        public void setP(Point2D p) => this.p = p;
        public void setR(double r) => this.r = r;
        public double square() => Math.PI * r * r;
        public double length() => 2 * Math.PI * r;
        public IShape shift(Point2D a)
        {
            this.p = a.add(p) as Point2D;
            return this;
        }
        public IShape rot(double phi) => this;

        public IShape symAxis(int i)
        {
            p.symAxis(i); return this;
        }

        public  bool cross(IShape i) => i.cross(this);
        public String toString() => "Center: " + p.toString()    + ", Radius: " + r;
    }
}
