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
    public interface IMarioEnemyCollisionHandler
    {
        void HandleCollision(IMario mario, IEnemy enemy, Direction result, Rectangle intersection);
    }
}
