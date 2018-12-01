using Game1;
using Mario.AbstractClass;

namespace Mario.EnemyStates.GoombaStates
{
	public class FlippedMinibossState : EnemyState
    {
        public FlippedMinibossState(IEnemy enemy) :base(enemy)
        {
        }
        public override bool IsFlipped()
        {
            return true;
        }
        public override void Update()
        {
            Enemy.gravityManagement.Update();
        }
    }
}
