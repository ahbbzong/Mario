using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
   public interface IEnemyCollisionHandler 
    {
        void HandleCollision(IEnemy enemy, Direction result);
    }
}
