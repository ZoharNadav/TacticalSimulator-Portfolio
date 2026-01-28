namespace Portfolio.core
{
    public enum TurnPhase
    {
        PlayerTurn, 
        EnemyTurn
    }
    public class PhaseManager
    {
        private int turnCounter = 1;
        private TurnPhase turnPhase = TurnPhase.PlayerTurn;
        private HashSet<Unit> moved = new HashSet<Unit>();
        private HashSet<Unit> attacked = new HashSet<Unit>();
        //no constructor because the game must start in turn 1, player phase. later consider constructor for turnPhase in cases of enemy start levels

        public int TurnCounter => turnCounter;
        public TurnPhase CurrentPhase => turnPhase;

        public bool CanMove(Unit unit)
        {
            return !moved.Contains(unit);
        } 

        public bool CanAttack(Unit unit)
        {
            return !attacked.Contains(unit);
        }

        public void RegisterMove(Unit unit)
        {
            moved.Add(unit);
        }

        public void RegisterAttack(Unit unit)
        {
            attacked.Add(unit);
        }

        private void AdvancePhase()
        {
            switch (turnPhase)
            {
                case TurnPhase.PlayerTurn:
                    turnPhase = TurnPhase.EnemyTurn;
                    break;
                case TurnPhase.EnemyTurn:
                    turnPhase = TurnPhase.PlayerTurn;
                    break;
            }
        }

        public void EndTurn()
        {
            attacked.Clear();
            moved.Clear();
            turnCounter++;
            AdvancePhase();
        }
    }
}
