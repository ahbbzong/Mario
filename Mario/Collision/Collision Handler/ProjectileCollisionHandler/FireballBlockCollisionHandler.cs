using Game1;
using Mario.BlocksClasses;
using Mario.Enums;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.FireballCollisionHandler
{
    public class FireballBlockCollisionHandler : IProjectileCollisionHandler
    {
        IBlock block;
        Rectangle intersection;
        Direction result;
        public FireballBlockCollisionHandler(IBlock block, Rectangle intersection,Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IProjectile fireball)
        {
            if (!(block is HiddenBlock))
            {
                IsOnLand(fireball);
                FireballAdjustment(fireball);
            }
        }
        public void FireballAdjustment(IProjectile fireball)
        {
            switch (result)
            {
                case Direction.Up:
                    fireball.Position -= Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Down:
                    fireball.Position += Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Left:
                    GameObjectManager.Instance.GameObjectListsByType[typeof(IProjectile)].Remove(fireball);
                    break;
                case Direction.Right:
                    GameObjectManager.Instance.GameObjectListsByType[typeof(IProjectile)].Remove(fireball);
                    break;
            }
        }
        public void IsOnLand(IProjectile fireball)
        {
            if (result==Direction.Left || result==Direction.Right || result==Direction.Up)
            {
                fireball.IsLandTrue();
            }
            else if (result==Direction.None)
            {
                fireball.IsLandFalse();
            }
        }
    }
    
}
