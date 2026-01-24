using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.core
{
    public class Unit
    {
        int maxHp, currentHp, atk, def, range, movement;

        public Unit(int maxHp, int atk, int def, int range, int movement)
        {
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.atk = atk;
            this.def = def;
            this.range = range;
            this.movement = movement;
        }

        public int MaxHp { get { return maxHp; } }
        public int CurrentHp {  get { return currentHp; } }
        public int Atk { get { return atk; } }
        public int Def { get { return def; } }
        public int Range {  get { return range; } }
        public int Movement { get { return movement; } }

        public int CalcDamageTaken(int incomingAttack)
        {
            int damage = incomingAttack - def;
            if (damage < 0)
                damage = 0;
            return damage;
        }

        public void TakeDamage(int incomingAttack)
        {
            currentHp -= CalcDamageTaken(incomingAttack);
            if (currentHp < 0)
                currentHp = 0;
        }
    }
}
