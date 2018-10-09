using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class MagicMushroom : Item
    {
        public MagicMushroom(Vector2 location) : base(location)
        {
            ItemSprite = SpriteFactory.Instance.CreateMagicMushroomSprite();
            Type = GameObjectType.MagicMushroom;
        }
    }
}

