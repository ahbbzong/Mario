using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.BlockSprite
{
    public class HiddenBlockSprite : StaticSprite
    {

        public HiddenBlockSprite(Texture2D hiddenBlockSheet) : base(hiddenBlockSheet)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //No need for Draw
        }
    }
}
