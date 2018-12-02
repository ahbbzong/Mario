using Game1;
using Mario.AbstractClass;
using Mario.GameObjects;

namespace Mario.EnemyStates.GoombaStates
{
	public class StompedMiniBossState : EnemyState
    {
        public int MiniBossDamage = 0;
        
        public StompedMiniBossState(IEnemy enemy) :base(enemy)
        {
        }

        public override void MiniBossStompReact()
        {
                MiniBossDamage++;
                if (MiniBossDamage == 3)
                     Enemy.BeStomped();

        }
      
        public override void Update()
        {
            Enemy.gravityManagement.Update();
        }
    }
}
