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
            enemyState = new MovingGoombaState(this);
            Type = EnemyType.Goomba;
        }
    }
}
