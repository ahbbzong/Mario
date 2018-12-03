using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using Microsoft.Xna.Framework;
namespace Mario.EnemyStates.GoombaStates
{
	public class LeftMiniBossState : EnemyState
    {
        int delay;
        public LeftMiniBossState(IEnemy enemy):base(enemy)
        {
            delay = 0;
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new StompedMiniBossState(Enemy);

        }

        public override void Update()
        {
            EnemySprite.Update();
            if (!Enemy.Island)
            {
                Enemy.gravityManagement.Update();
            }

            if (delay == 200)
            {
               // GameObjectManager.Instance.GameObjectList.Add(new Goomba(Enemy.Position));
                delay = 0;
            }
            delay++;
        }
      



    }
}
