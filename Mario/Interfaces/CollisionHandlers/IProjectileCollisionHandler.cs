using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.CollisionHandlers;
using Mario.Enums;

namespace Game1
{
    public interface IProjectileCollisionHandler : ICollisionHandler
    {
        void HandleCollision(IProjectile projectile);
    }
}
