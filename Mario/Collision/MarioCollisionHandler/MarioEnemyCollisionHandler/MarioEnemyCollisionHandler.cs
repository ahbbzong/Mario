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
        public void HandleCollision(IMario mario,Direction result, Rectangle intersection)
        {
            MarioState(mario);
            if (enemy.IsKoopa() && !enemy.IsFlipped() || enemy.IsGoomba() && !enemy.IsStomped())
            {
                switch (result)
                {
                    case Direction.Up:
                        mario.Getposition().Y -= intersection.Height;
                        mario.physics.ReverseYVelocity();
                        break;
                    case Direction.Down:
                        mario.Getposition().Y += intersection.Height;
                        break;
                    case Direction.Left:
                        mario.Getposition().X -= intersection.Width;
                        break;
                    case Direction.Right:
                        mario.Getposition().X += intersection.Width;
                        break;
                }
            }
        }
        public void MarioState(IMario mario)
        {
            if (!enemy.IsStomped()&&!enemy.IsFlipped())
            {
                if (mario.IsNormalMario())
                {
                    mario.Dead();
                }
                if (mario.IsSuperMario() || mario.IsFireMario())
                {
                    mario.BeNormal();
                }
            }
        }
    }
}
