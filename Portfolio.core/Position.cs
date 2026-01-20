using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Portfolio.core
{
    internal class Position
    {
        private int x, y; //immutable

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
        //no setter- I don't want changes.

        public bool Equals(Position other)
        {
            //checks current position with "other"
            if (!ReferenceEquals(null, other))
                //if (x.Equals(other.X) && y.Equals(other.Y)) {  return true; }
                return X.Equals(other.X) && Y.Equals(other.Y);
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Position other)
                return false;

            return X == other.X && Y == other.Y;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            string currentPosition;
            currentPosition = "X= "+x+", y= "+y;

            return currentPosition;
        }





        
    }
}
