using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.EnemyCollisionHandler
{
    public class EnemyBlockCollisionHandler : IEnemyCollisionHandler
    {
        IBlock block;
        Rectangle intersection;

		public EnemyBlockCollisionHandler(IBlock block,Rectangle intersection)
        {
            this.block = block;
            this.intersection = intersection;
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            if(enemy.IsKoopa()&&!enemy.IsFlipped()||enemy.IsGoomba())
            switch (result)
            {
                case Direction.Up:
                    enemy.Getposition().Y -= intersection.Height;
                        enemy.IsLandTrue();

                        break;
                case Direction.Down:
						enemy.Getposition().Y += intersection.Height;
                    break;
                case Direction.Left:
                    enemy.Getposition().X -= intersection.Width;
                      
                            enemy.TurnLeft();
                       
                    break;
                case Direction.Right:
                    enemy.Getposition().X += intersection.Width;
                      enemy.TurnRight();
                        break;
                case Direction.None:
                        enemy.IsLandFalse();
                        break;
            }
        }

    }

}
