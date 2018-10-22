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
        Vector2 speed;
        public EnemyMarioCollisionHandler(IMario mario)
        {
            this.mario = mario;
            speed = new Vector2(20.0f, 20.0f);
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            if (mario.IsStarMario() || result.Equals(Direction.Up))
            {
                enemy.BeStomped();
            }
            if (enemy.IsKoopa()&&enemy.IsStomped()&& result.Equals(Direction.Right))
            {
                enemy.TurnLeft();
            }
            else if(enemy.IsKoopa()&&enemy.IsStomped() && result.Equals(Direction.Left))
            {
                enemy.TurnRight();
            }
            
        }
     
	}
}
