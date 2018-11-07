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
        Rectangle intersection;
        public MarioHiddenBlockHandler( Rectangle intersection)
        {
            this.intersection = intersection;
        }
        public void HandleCollision(IMario mario, Direction result)
        {
            PoisitionAdjustment(mario, result, intersection);
        }
        public static void PoisitionAdjustment(IMario marioParam, Direction result, Rectangle intersection)
        {
            if (result==Direction.Down)
            {
                marioParam.Position += Vector2.UnitY * intersection.Height;
                marioParam.Physics.ResetGravity();
            }
        }
    }
}
