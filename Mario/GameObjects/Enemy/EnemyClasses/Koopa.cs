using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.EnemyStates.GoombaStates;
using Mario.Enums;
using Mario.AbstractClass;

namespace Mario.EnemyClasses
{

    public class Koopa : Enemy
    {

		public Koopa(Vector2 location) : base(location)
		{
			enemyState = new LeftMovingKoopaState(this);
			Type = EnemyType.Koopa;
		}
    }
}
