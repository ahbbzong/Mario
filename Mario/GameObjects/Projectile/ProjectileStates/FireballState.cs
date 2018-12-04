using Game1;
using Mario.AbstractClass;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Mario.ItemClasses;
using Mario.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Items
{
    public class FireballState : ProjectileState
    {
        int count;

        public FireballState(IProjectile fireball) : base(fireball)
        {
            count = 0;
            ProjectileSprite = SpriteFactory.Instance.CreateSprite(ProjectileFactory.Instance.GetSpriteDictionary[fireball.GetType()]);
        }
        public override void React()
        {
            Projectile.ProjectileState = new FireballDisappearState(Projectile);
        }
        public override void Update()
        {
            count++;
            if (count == 200)
            {
                GameObjectManager.Instance.GameObjectList.Remove(Projectile);
            }
        }
    }
}
