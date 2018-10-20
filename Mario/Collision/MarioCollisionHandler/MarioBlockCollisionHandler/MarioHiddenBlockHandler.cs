using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler
{
    public class MarioHiddenBlockHandler : IMarioCollisionHandler
    {
        IBlock block;
        public MarioHiddenBlockHandler(IBlock block)
        {
            this.block = block;
        }
        public void HandleCollision(IMario mario, Direction result, Rectangle intersection)
        {
            if (!block.IsHiddenBlock())
            {
                PoisitionAdjustment(mario, result, intersection);
            }
        }
        public static void PoisitionAdjustment(IMario mario, Direction result, Rectangle intersection)
        {
            switch (result)
            {
                case Direction.Up:
                    mario.Getposition().Y -= intersection.Height;
                    mario.IsLandTrue();
                    break;
                case Direction.Down:
                    mario.Getposition().Y += intersection.Height;
                    mario.physics.ReverseYVelocity();
                    break;
                case Direction.Left:
                    mario.Getposition().X -= intersection.Width;
                    break;
                case Direction.Right:
                    mario.Getposition().X += intersection.Width;
                    break;
                case Direction.None:
                    mario.IsLandFlase();
                    break;

            }
        }
    }
}
