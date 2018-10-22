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
		readonly IBlock block;
        Rectangle intersection;
        Vector2 speed;
		public EnemyBlockCollisionHandler(IBlock block,Rectangle intersection)
        {
            this.block = block;
            this.intersection = intersection;
            speed = new Vector2(20.0f, 20.0f);
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            if(!enemy.IsFlipped())
            switch (result)
            {
                case Direction.Up:
						enemy.Position -= Vector2.UnitY * intersection.Height;
                        if (block.IsBumpedBlockState() || block.IsBumpedBreakBlock())
                        {
                            enemy.Beflipped();
                        }
						enemy.IsLandTrue();
                        break;
						
                case Direction.Down:
						enemy.Position += Vector2.UnitY*intersection.Height;
                    break;
                case Direction.Left:
                    enemy.Position -= Vector2.UnitX*intersection.Width;
                      
                            enemy.TurnLeft();
                       
                    break;
                case Direction.Right:
                    enemy.Position  += Vector2.UnitX*intersection.Width;
                      
                            enemy.TurnRight();
                           
                        break;
                case Direction.None:
                        enemy.IsLandFalse();
                        break;
            }
        }

    }

}
