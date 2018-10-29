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
        Direction result;
        public EnemyEnemyCollisionHandler(IEnemy enemy, Rectangle intersection, Direction result)
        {
            this.intersection = intersection;
            this.enemy = enemy;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemy)
        {
                GoombaKoopaReact(enemy);
            if (!this.enemy.IsGoombaStomped())
            {
                CollisionCondition(enemy);
            }

        }
        public void GoombaKoopaReact(IEnemy enemy)
        {
            if (enemy.IsLeftStomped() && result.Equals(Direction.Right)
                || enemy.IsRightStomped() && result.Equals(Direction.Left))
            {
                this.enemy.Beflipped();
            }
        }
        public void NonStompedKoopaReact(IEnemy enemy)
        {
            if (!enemy.IsKoopaStomped()&& !enemy.IsRightStomped()&& result.Equals(Direction.Left))
            {
                enemy.Position -= Vector2.UnitX * intersection.Width;
                enemy.TurnLeft();
            }
            if (!enemy.IsKoopaStomped() && !enemy.IsLeftStomped() && result.Equals(Direction.Right))
            {
                enemy.Position += Vector2.UnitX * intersection.Width;
                enemy.TurnRight();
            }
        }
        private void CollisionCondition(IEnemy enemy)
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
                    NonStompedKoopaReact(enemy);
                    this.enemy.TurnRight();
                    break;
                case Direction.Right:
                    NonStompedKoopaReact(enemy);
                    this.enemy.TurnLeft();
                    break;
                case Direction.None:
                    enemy.IsLandFalse();
                    break;
            }
        }
    }
}
