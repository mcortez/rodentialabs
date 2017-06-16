using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRunner
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Offset(Point offset)
        {
            return this + offset;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
        public override bool Equals(object obj)
        {
            return (obj is Point) && (this == (Point)obj);
        }

        public static bool operator == (Point a, Point b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }
}
