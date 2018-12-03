using Mario.AbstractClass;
using Mario.EnemyClasses;
using Mario.EnemyStates.GoombaStates;
using Microsoft.Xna.Framework;

namespace Mario.GameObjects
{


    public class MiniBoss : Enemy
    {
		private int health = 3;
        private int delay = 0;
        public MiniBoss(Vector2 location) : base(location)
        {

            EnemyState = new ActiveMiniBossState(this);
        }

        private void ThrowGoomba()
        {
            EnemyState.ThrowGoomba();
        }
        public override void Update()
        {
            if (delay == 400)
            {
                ThrowGoomba();
                delay = 0;
            }
            delay++;
        }

        public override void MiniBossStompReact()
        {
            health--;
            if (health == 0)
            {
                EnemyState = new StompedMiniBossState(this);
            }
        }

    }
}