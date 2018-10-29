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
            
                PoisitionAdjustment(mario, result, intersection);
            
        }
        public static void PoisitionAdjustment(IMario mario, Direction result, Rectangle intersection)
        {
            if (result.Equals(Direction.Down))
            {
                mario.Position += Vector2.UnitY * intersection.Height;
                mario.Physics.ResetGravity();
            }
               
            
        }
    }
}
