using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class BrickParticleLeft : Item
    {
        public BrickParticleLeft(Vector2 location):base(location)
        {
        }
      
        public override void Update()
        {
            ItemSprite.Update();
            gravityManagement.Update();
            Position -= Vector2.UnitX * 5;
        }

    }
}
