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
        public FireballEnemyCollisionHandler()
        {
        }
        public void HandleCollision(IProjectile fireball)
        {
            GameObjectManager.Instance.GameObjectListsByType[typeof(IProjectile)].Remove(fireball);
        }
    }
}
