using Game1;
using Mario.AbstractClass;
using Mario.GameObjects;

namespace Mario.EnemyStates.GoombaStates
{
	public class StompedMinibossState : EnemyState
    {

        private int MiniBossDamage = 1;
        public StompedMinibossState(IEnemy enemy) :base(enemy)
        {
            if (enemy is MiniBoss)
            {
                MiniBossDamage++;
                if (MiniBossDamage == 3)
                {
                    enemy.BeStomped();
                }
            }
        }
       
        public override void Update()
        {
            Enemy.gravityManagement.Update();
        }
    }
}
