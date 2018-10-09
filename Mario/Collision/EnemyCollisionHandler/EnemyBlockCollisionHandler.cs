using Game1;
using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.EnemyCollisionHandler
{
    public class EnemyBlockCollisionHandler : IEnemyCollisionHandler
    {
        IMario mario;
        public EnemyBlockCollisionHandler(IMario mario)
        {
            this.mario = mario;
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            switch (result)
            {
                case Direction.Up:

                    break;
                case Direction.Down:

                    break;
                case Direction.Left:

                    break;
                case Direction.Right:

                    break;
            }
        }

    }

}
