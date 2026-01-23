using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.core
{
    internal class Grid
    {
        private readonly int width=0, height;
        private Dictionary<Position, Unit> field;

        public Grid(int widthSize, int heightSize)
        {
            width = widthSize;
            height = heightSize;
            field = new Dictionary<Position, Unit>();
        }

        public bool IsInsideGrid(Position position)
        {
            if (0<=position.X && position.X<width && 0<=position.Y && position.Y<height)
                return true;
            return false;
        }

        public bool IsOccupied(Position position)
        {
            if (!IsInsideGrid(position))
                return true; //outside == ocupied == can't place
            return field.ContainsKey(position);
        }

        public bool Place(Position position, Unit unit)
        {
            if (!IsOccupied(position))
            {
                field[position] = unit;
                return true;
            }
            else
                return false;
        }


    }
}
