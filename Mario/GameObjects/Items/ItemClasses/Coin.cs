using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class Coin : Item
    {
        public Coin(Vector2 location):base(location)
        {
        }
        public override bool IsCoin()
        {
            return true;
        }
        public override void Update()
        {
            ItemSprite.Update();
            if (!IsLand)
            {
                Physics.Update();
            }

        }

    }
}
