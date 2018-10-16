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
    public class EnemyItemCollisionHandler : IEnemyCollisionHandler
    {
        IItem item;
        Rectangle intersection;
        public EnemyItemCollisionHandler(IItem item, Rectangle intersection)
        {
            this.item = item;
            this.intersection = intersection;
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            switch (result)
            {
                case Direction.Up:
                    enemy.Getposition().Y -= intersection.Height;
                    break;
                case Direction.Down:
                    enemy.Getposition().Y += intersection.Height;
                    break;
                case Direction.Left:
                    enemy.Getposition().X -= intersection.Width;
                    break;
                case Direction.Right:
                    enemy.Getposition().X += intersection.Width;
                    break;
            }
        }
    }

}
