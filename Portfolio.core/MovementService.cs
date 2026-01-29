using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.core
{
    internal class MovementService
    {
        private readonly Grid grid;
        private readonly PhaseManager phaseManager;

        public MovementService(Grid grid, PhaseManager phaseManager)
        {
            this.grid = grid;
            this.phaseManager = phaseManager;
        }

        public bool Move(Unit unit, Position targetLocation)
        {
            if (!phaseManager.CanMove(unit)) return false;
            if (!grid.IsOccupied(targetLocation)) return false;
            //check if road is clear

            //Add to Grid a GetPosition(Unit) {gives the position of a unit. remember to test.}
            //Position currentLocation = grid.GetPosition(unit);
            //grid.ClearPosition(currentLocation);
            //grid.Place(targetLocation, unit);
            phaseManager.RegisterMove(unit);
            return true;
        }

        /*
        - private readonly Grid, PhaseManager
        - constructor

        Methods:
        - Move() {if phaseManager.CanMove() && grid.!IsOccupied grid.ClearPosition(), grid.Place()}
        - To do: I want a method to determine if the road is blocked off by an enemy.
        */

    }
}
