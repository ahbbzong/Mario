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
        public void HandleCollision(IEnemy enemyParam)
        {
                GoombaKoopaReact(enemyParam);
            if (!enemy.IsGoombaStomped())
            {
                CollisionCondition(enemyParam);
            }

        }
        private void GoombaKoopaReact(IEnemy enemyParam)
        {
            if (enemyParam.IsLeftStomped() && result.Equals(Direction.Right)
                || enemyParam.IsRightStomped() && result.Equals(Direction.Left))
            {
                enemy.Beflipped();
            }
        }
        private void NonStompedKoopaReact(IEnemy enemyParam)
        {
            if (!enemyParam.IsKoopaStomped()&& !enemyParam.IsRightStomped()&& result.Equals(Direction.Left))
            {
                enemyParam.Position -= Vector2.UnitX * intersection.Width;
                enemyParam.TurnLeft();
            }
            if (!enemyParam.IsKoopaStomped() && !enemyParam.IsLeftStomped() && result.Equals(Direction.Right))
            {
                enemyParam.Position += Vector2.UnitX * intersection.Width;
                enemyParam.TurnRight();
            }
        }
        private void CollisionCondition(IEnemy enemyParam)
        {
            switch (result)
            {
                case Direction.Up:
                    enemyParam.Position -= Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Down:
                    enemyParam.IsLandTrue();
                    enemyParam.Position += Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Left:
                    NonStompedKoopaReact(enemyParam);
                    enemy.TurnRight();
                    break;
                case Direction.Right:
                    NonStompedKoopaReact(enemyParam);
                    enemy.TurnLeft();
                    break;
                case Direction.None:
                    enemyParam.IsLandFalse();
                    break;
            }
        }
    }
}
