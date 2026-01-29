using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.core
{
    internal class CombatService
    {
        private readonly Grid grid;
        private readonly PhaseManager phaseManager;

        public CombatService(Grid grid, PhaseManager phaseManager)
        {
            this.grid = grid;
            this.phaseManager = phaseManager;
        }

        public bool Attack(Unit attacker, Unit defender)
        {
            if (!phaseManager.CanAttack(attacker)) return false;

            defender.TakeDamage(defender.CalcDamageTaken(attacker.Atk));
            if (defender.CurrentHp == 0) grid.ClearUnit(defender);
            phaseManager.RegisterAttack(attacker);
            return true;
        }

        /*
        - private readonly Grid, PhaseManager
        - constructor

        Methods:
        - To do: I want a method to determine if there is an enemy and check what enemy it is.
        - Attack(Unit) {if phaseManager.CanAttack() 
        	defender.TakeDamage(defender.CalcDamageTaken(unit.GetAttack)) if defender.GetCurrentHp==0
	        Death()}
        - Death(Unit) {grid.ClearUnit(unit)}
        */
    }

}
