using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class Fireball : Projectile
    {
        public Fireball(Vector2 location):base(location)
        {
            ProjectileSprite = ProjectileFactory.Instance.GetSpriteDictionary[ProjectileType.Fireball.ToString()];
            Type = ProjectileType.Fireball;
        }


    }
}
