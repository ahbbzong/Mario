using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
    public interface IMarioCollisionHandler
    {
        void HandleCollision(IMario mario, Direction result);
    }
}
