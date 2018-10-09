using Game1;
using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.EnemyCollisionHandler
{
    class EnemyPipeHandler : IEnemyMarioCollisionHandler
    {
        public EnemyPipeHandler()
        {

        }
        public void HandleCollision(IMario mario,IEnemy enemy, Direction result)
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
