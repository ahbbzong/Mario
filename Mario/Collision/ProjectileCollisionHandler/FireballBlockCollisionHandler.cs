using Game1;
using Mario.Enums;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.FireballCollisionHandler
{
    public class FireballBlockCollisionHandler : IProjectileCollisionHandler
    {
        IBlock block;
        Rectangle intersection;
        Direction result;
        private int locationOffset;
        public FireballBlockCollisionHandler(IBlock block, Rectangle intersection,Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
            locationOffset = 9999;
        }
    public void HandleCollision(IProjectile fireball)
        {
            if (!block.IsHiddenBlock())
            {
                switch (result)
                {
                    case Direction.Up:
                        fireball.Getposition().Y -= intersection.Height;
                        fireball.IsLandTrue();
                        break;
                    case Direction.Down:
                        fireball.Getposition().Y += intersection.Height;
                        fireball.IsLandTrue();
                        break;
                    case Direction.Left:
                        fireball.Getposition().Y += locationOffset;
                        break;
                    case Direction.Right:
                        fireball.Getposition().X += locationOffset;
                        fireball.Getposition().Y += locationOffset;
                        break;
                    case Direction.None:
                        fireball.IsLandFalse();
                        break;
                }
            }
        }
    }
}
