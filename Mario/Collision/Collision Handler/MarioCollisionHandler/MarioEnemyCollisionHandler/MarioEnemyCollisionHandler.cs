using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler
{
    public class MarioEnemyCollisionHandler : IMarioCollisionHandler
    {
        IEnemy enemy;
        public MarioEnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void PositionAdjustment(IMario mario, Direction result, Rectangle intersection)
        {
            switch (result)
            {
                case Direction.Up:
                    mario.Position -= new Vector2(0, intersection.Height);
                    mario.Physics.ReverseYVelocity();
                    break;
                case Direction.Down:
                    mario.Position += new Vector2(0, intersection.Height);
                    break;
                case Direction.Left:
                    mario.Position -= new Vector2(intersection.Width, 0);
                    break;
                case Direction.Right:
                    mario.Position += new Vector2(intersection.Width, 0);
                    break;
            }
            MarioReact(mario, result);
        }
        public void HandleCollision(IMario mario,Direction result, Rectangle intersection)
        {
            
            if (!enemy.IsGoombaStomped())
            {
                PositionAdjustment(mario, result, intersection);
            }
        }
        public void MarioReact(IMario mario,Direction result)
        {
            if ((!enemy.IsLeftStomped()&&result.Equals(Direction.Right)|| !enemy.IsRightStomped() && result.Equals(Direction.Left))
                && !enemy.IsFlipped()&&!enemy.IsGoombaStomped()&&!enemy.IsKoopaStomped())
            {
                MarioTakeDamage(mario);
            }
            
        }
        public void MarioTakeDamage(IMario mario)
        {
			mario.TakeDamage();
        }
    }
}
