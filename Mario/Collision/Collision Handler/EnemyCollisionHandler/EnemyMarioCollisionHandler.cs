using Game1;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.EnemyCollisionHandler
{
    public class EnemyMarioCollisionHandler: IEnemyCollisionHandler
    {
        IMario mario;
        Direction result;
        public EnemyMarioCollisionHandler(IMario mario, Direction result)
        {
            this.mario = mario;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemy)
        {
            if (mario.IsStarMario()&&!result.Equals(Direction.None))
            {
                enemy.Beflipped();
            }
            if (result.Equals(Direction.Up))
            {
                enemy.BeStomped();
            }
            if (enemy.IsKoopaStomped() && result.Equals(Direction.Right))
            {
                enemy.TurnLeft();
            }
            else if(enemy.IsKoopaStomped() && result.Equals(Direction.Left))
            {
                enemy.TurnRight();
            }

        }
     
	}
}
