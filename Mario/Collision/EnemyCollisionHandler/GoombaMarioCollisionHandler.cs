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
    public class GoombaMarioCollisionHandler: IEnemyCollisionHandler
    {
        IMario mario;
        public GoombaMarioCollisionHandler(IMario mario)
        {
            this.mario = mario;
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            if (mario.IsStarMario() || result.Equals(Direction.Up))
            {
                enemy.BeStomped();
            }
            if (enemy.IsStomped() && result.Equals(Direction.Right))
            {

            }
            if (enemy.IsStomped() && result.Equals(Direction.Left))
            {

            }
        }
     
	}
}
