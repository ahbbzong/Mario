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
    public class EnemyEnemyCollisionHandler : IEnemyCollisionHandler
    {
        Rectangle intersection;
        IEnemy enemy;


		public EnemyEnemyCollisionHandler(IEnemy enemy,Rectangle intersection)
        {
            this.intersection = intersection;
            this.enemy = enemy;
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            if(enemy.IsKoopa()&&!enemy.IsFlipped()||
                enemy.IsGoomba()
                || this.enemy.IsKoopa() && !this.enemy.IsFlipped()
                ||this.enemy.IsGoomba())
            switch (result)
            {
                case Direction.Up:
                    enemy.Getposition().Y -= intersection.Height;
						
                    break;
                case Direction.Down:
						enemy.IsLandTrue();
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
