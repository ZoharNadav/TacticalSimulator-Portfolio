using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.core
{
    public class Grid
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

        public bool ClearPosition(Position position)
        {
            if (field.ContainsKey(position))
            {
                return field.Remove(position);
            }
            else { return false; }
        }

        public bool ClearUnit(Unit unit)
        {
            foreach (var pair in field)
            {
                if(pair.Value == unit)
                {
                    field.Remove(pair.Key);
                    return true;
                }
            }
            return false;

            /*
             * starting code: leave for now, delete later post testing
            Position? unitLocation = null;
            foreach (Position position in field.Keys)
            {
                if (field.GetValueOrDefault(position) == unit)
                {
                    unitLocation = position;
                }
            }
            if (unitLocation != null)
            {
                field.Remove(unitLocation);
                return true;
            }
            else
                return false;
            */
        }

        public Unit GetOccupant(Position position)
        {
            if (field.TryGetValue(position, out Unit? unit))
                return unit;
            else
                throw new KeyNotFoundException($"no unit found at position {position}.");
        }
    }
}
