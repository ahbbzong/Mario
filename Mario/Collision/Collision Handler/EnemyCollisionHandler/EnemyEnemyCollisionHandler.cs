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
            if (enemy.IsKoopa() && enemy.IsStomped()&&enemy.IsMoving&&!result.Equals(Direction.None))
            {
                this.enemy.Beflipped();
            }
            if (!enemy.IsFlipped())
            {
                switch (result)
                {
                    case Direction.Up:
                        enemy.Position -= Vector2.UnitY * intersection.Height;
                        break;
                    case Direction.Down:
                        enemy.IsLandTrue();
                        enemy.Position += Vector2.UnitY * intersection.Height;
                        break;
                    case Direction.Left:
                        enemy.Position -= Vector2.UnitX * intersection.Width;
                        enemy.TurnLeft();
                        this.enemy.TurnRight();
                        break;
                    case Direction.Right:
                        enemy.Position += Vector2.UnitX * intersection.Width;
                        enemy.TurnRight();
                        this.enemy.TurnLeft();
                        break;
                    case Direction.None:
                        enemy.IsLandFalse();
                        break;
                }
            }
        }

    }

}
