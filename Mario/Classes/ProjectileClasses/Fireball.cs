using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using Mario.Items;

namespace Mario.ItemClasses
{
    public class Fireball : Projectile
    {
        
        public Fireball(Vector2 location):base(location)
        {
            ProjectileSprite = ProjectileFactory.Instance.GetSpriteDictionary[ProjectileType.Fireball.ToString()];
            ProjectileState = new FireballState(this);
            Type = ProjectileType.Fireball;
            physics = new Physics(this);
        }
        public override void React()
        {
            ProjectileState.React();
        }
    }
}
