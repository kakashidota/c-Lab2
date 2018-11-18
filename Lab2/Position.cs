using System;
using System.Collections.Generic;
using System.Text;


namespace Lab2
{
    public class Position
    {
        private double x;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value <= 0)
                {
                    x = 0;
                }
                else
                {
                    x = value;
                }
            }
        }
        private double y;
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value <= 0)
                {
                    y = 0;
                }
                else
                {
                    y = value;
                }
            }
        }

        public Position(Double x, Double y)
        {
            X = x;
            Y = y;
        }
        public Position()
        {
            X = 0;
            Y = 0;
        }

        // Methods
        public Position Clone()
        {
            return new Position(X, Y);
        }
        public bool Equals(Position p)
        {
            if (p.X == X && p.Y == Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            string s = "(" + X + "," + Y + ")";
            return s;
        }
        public double Length()
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }

        // Operators
        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Position operator -(Position p1, Position p2)
        {
            Double newX = p1.X - p2.X < 0 ? 0 : p1.X - p2.X;
            Double newY = p1.Y - p2.Y < 0 ? 0 : p1.Y - p2.Y;
            return new Position(newX, newY);
        }
        public static Position operator *(Position p1, Position p2)
        {
            return new Position(p1.X * p2.X, p1.Y * p2.Y);
        }
        public static double operator %(Position p1, Position p2)
        {
            double newX = Convert.ToDouble(Math.Pow((float)(p1.X - p2.X), 2));
            double newY = Convert.ToDouble(Math.Pow((float)(p1.Y - p2.Y), 2));
            return Math.Sqrt(newX + newY);
        }
    }
}
