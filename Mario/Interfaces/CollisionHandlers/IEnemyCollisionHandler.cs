using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
   public interface IEnemyCollisionHandler :ICollisionHandler
    {
        void HandleCollision(IEnemy enemy, Direction result);
    }
}
