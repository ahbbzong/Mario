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
        Direction result;
		public EnemyBlockCollisionHandler(IBlock block,Rectangle intersection, Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemy)
        {
            IsOnLand(enemy, result);
            switch (result)
                {
                    case Direction.Up:
                        enemy.Position -= new Vector2(0,intersection.Height);
                        EnemyBumpedBlockReact(enemy);
                        break;
                    case Direction.Down:
                        enemy.Position += new Vector2(0, intersection.Height);
                        break;
                    case Direction.Left:
                        enemy.Position -= new Vector2(intersection.Width, 0);
                        enemy.TurnLeft();
                        break;
                    case Direction.Right:
                        enemy.Position += new Vector2(intersection.Width, 0);
                        enemy.TurnRight();
                        break;
                   
                }
            
        }
        public void EnemyBumpedBlockReact(IEnemy enemy)
        {
            if (block.IsBumpedBlockState() || block.IsBumpedBreakBlock())
            {
                enemy.Beflipped();
            }
        }
        public void IsOnLand(IEnemy enemy,Direction result)
        {
            if(result.Equals(Direction.Left)|| result.Equals(Direction.Right)|| result.Equals(Direction.Up))
            {
                enemy.IsLandTrue();
            }
            else if(result.Equals(Direction.None))
            {
                enemy.IsLandFalse();
            }
        }

    }

}
