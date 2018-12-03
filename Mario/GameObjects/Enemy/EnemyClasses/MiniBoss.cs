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
         
        }

        private void ThrowGoomba()
        {
            GameObjectManager.Instance.GameObjectList.Add(new Goomba(EnemyLocation));
        }
        public override void Update()
        {
            if (delay == 5)
            {
                ThrowGoomba();
                delay = 0;
            }
            delay++;
        }
    }
}