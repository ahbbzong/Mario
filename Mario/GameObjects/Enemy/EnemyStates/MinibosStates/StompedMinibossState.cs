using Game1;
using Mario.AbstractClass;
using Mario.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.EnemyStates.GoombaStates
{
	public class StompedMiniBossState : EnemyState
    {
        int count = EnemyUtil.goombaAppear;
        public StompedMiniBossState(IEnemy enemy) :base(enemy)
        {
        }

        public override void Update()
        {
            count++;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (count < EnemyUtil.goombaDisappear)
            {
                EnemySprite.Draw(spriteBatch, location);
            }
            else
            {
                GameObjectManager.Instance.GameObjectList.Remove(Enemy);
            }
        }
    }
}
