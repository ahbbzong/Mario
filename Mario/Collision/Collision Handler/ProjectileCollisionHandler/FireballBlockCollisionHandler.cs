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
                        fireball.Position -= Vector2.UnitY*intersection.Height;
                        fireball.IsLandTrue();
                        break;
                    case Direction.Down:
                        fireball.Position += Vector2.UnitY*intersection.Height;
                        fireball.IsLandTrue();
                        break;
                    case Direction.Left:
                        fireball.Position += Vector2.UnitX*locationOffset;
                        fireball.IsLandTrue();
                        break;
                    case Direction.Right:
                        fireball.Position += Vector2.UnitX*locationOffset;
                        fireball.IsLandTrue();
                        break;
                    case Direction.None:
                        fireball.IsLandFalse();
                        break;
                }
            }
        }
    }
}
