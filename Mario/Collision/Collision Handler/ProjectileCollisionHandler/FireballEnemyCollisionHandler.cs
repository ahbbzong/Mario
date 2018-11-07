using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.FireballCollisionHandler
{
    public class FireballEnemyCollisionHandler : IProjectileCollisionHandler
    {
		readonly IEnemy enemy;
        public FireballEnemyCollisionHandler(IEnemy enemyParam)
        {
            this.enemy = enemyParam;
        }
        public void HandleCollision(IProjectile fireball)
        {
            fireball.Position += Vector2.UnitY * LocationOffset.Until;
        }
    }
}
