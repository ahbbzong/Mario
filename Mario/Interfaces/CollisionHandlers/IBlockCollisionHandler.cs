using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
   public interface IBlockCollisionHandler:ICollisionHandler
    {
        void HandleCollision(IBlock block, IMario mario, Direction result);
    }
}
