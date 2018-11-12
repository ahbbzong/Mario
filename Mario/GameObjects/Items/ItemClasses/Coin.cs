using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;
using Mario.Sound;

namespace Mario.ItemClasses
{
    public class Coin : Item
    {
        public Coin(Vector2 location):base(location)
        {
            MotionSound.MarioCoin.Play();

        }
        public override bool IsCoin()
        {
            return true;
        }
        public override void Update()
        {
            ItemSprite.Update();
            gravityManagement.Update();
         }

    }
}
