using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.EnemyCollisionHandler
{
    public class EnemyProjectileCollisionHandler : IEnemyCollisionHandler
    {
        public EnemyProjectileCollisionHandler()
		{
        }
        public void HandleCollision(IEnemy enemy)
        {
            enemy.Beflipped();
        }
    }
}
