using Game1;
using Mario.Enums;
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
            if (result.Equals(Direction.Left) || result.Equals(Direction.Right))
            {
                fireball.Getposition().Y += locationOffset;
            }
            if (result.Equals(Direction.Up) || result.Equals(Direction.Down))
            {

            }
        }
    }
}
