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
    public class MarioEnemyCollisionHandler : IMarioEnemyCollisionHandler
    {
        public MarioEnemyCollisionHandler()
        {

        }
        public void HandleCollision(IMario mario ,IEnemy enemy ,Direction result, Rectangle intersection)
        {
            if (!enemy.IsStomped())
            {
                if (mario.IsNormalMario())
                {
                    mario.Dead();
                }
                if (mario.IsSuperMario() || mario.IsFireMario())
                {
                    mario.BeNormalMario();
                }
            }
            switch (result)
            {
                case Direction.Up:
                    mario.Getposition().Y -= intersection.Height; 
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
}
