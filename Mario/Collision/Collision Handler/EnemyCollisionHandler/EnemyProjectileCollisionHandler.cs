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
        IProjectile projectile;
        public EnemyProjectileCollisionHandler(IProjectile projectile)
        {
            this.projectile = projectile;
        }
        public void HandleCollision(IEnemy enemy, Direction result)
        {
            if(enemy.IsKoopa() && !enemy.IsFlipped()){
                enemy.Beflipped();
            }
            if (enemy.IsGoomba() && !enemy.IsStomped())
            {
                enemy.Beflipped();
            }
        }
    }

}
