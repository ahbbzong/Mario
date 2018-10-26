using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.EnemyStates.GoombaStates;
using Mario.Enums;
using Mario.AbstractClass;

namespace Mario.EnemyClasses
{
    public class Goomba : Enemy
    {

        public Goomba(Vector2 location) : base(location)
        {
            EnemyState = new LeftMovingGoombaState(this);
			Velocity = -Vector2.UnitX;
            Type = EnemyType.Goomba;
        }

		
	}
}
