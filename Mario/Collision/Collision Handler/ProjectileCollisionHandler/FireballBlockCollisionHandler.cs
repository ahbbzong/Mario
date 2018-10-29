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
        public FireballBlockCollisionHandler(IBlock block, Rectangle intersection,Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IProjectile fireball)
        {
            if (!block.IsHiddenBlock())
            {
                IsOnLand(fireball);
                FireballAdjustment(fireball);
            }
        }
        public void FireballAdjustment(IProjectile fireball)
        {
            switch (result)
            {
                case Direction.Up:
                    fireball.Position -= Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Down:
                    fireball.Position += Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Left:
                    fireball.Position += Vector2.UnitY * LocationOffset.Until;
                    break;
                case Direction.Right:
                    fireball.Position += Vector2.UnitY * LocationOffset.Until;
                    break;
            }
        }
        public void IsOnLand(IProjectile fireball)
        {
            if (result.Equals(Direction.Left) || result.Equals(Direction.Right) || result.Equals(Direction.Up))
            {
                fireball.IsLandTrue();
            }
            else if (result.Equals(Direction.None))
            {
                fireball.IsLandFalse();
            }
        }
    }
    
}
