using Game1;
using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.FireballCollisionHandler
{
    public class FireballEnemyCollisionHandler : IProjectileCollisionHandler
    {
        IEnemy enemy;
        private int locationOffset;
        public FireballEnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
            locationOffset = 9999;
        }
        public void HandleCollision(IProjectile fireball)
        {
            fireball.Getposition().Y += locationOffset;
        }
    }
}
