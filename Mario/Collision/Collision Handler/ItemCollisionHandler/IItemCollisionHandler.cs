using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
    public interface IItemCollisionHandler: ICollisionHandler
    {
        void HandleCollision(IItem item);
    }
}
