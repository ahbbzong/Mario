using Game1;
using Mario.AbstractClass;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Items
{
    public class FireballState : ProjectileState
    {


        public FireballState(IProjectile fireball) : base(fireball)
        {
            ProjectileSprite = ProjectileFactory.Instance.GetSpriteDictionary[ProjectileType.Fireball.ToString()];
        }
        public override void React()
        {
            Projectile.ProjectileState = new FireballDisappearState(Projectile);
        }
    }
}
