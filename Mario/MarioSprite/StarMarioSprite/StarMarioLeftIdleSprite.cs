using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.StarMarioSprite
{

    public class StarMarioLeftIdleSprite : StaticSprite
    {
     

        public StarMarioLeftIdleSprite(Texture2D leftIdleSheet) : base(leftIdleSheet)
        {
           
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(SpriteSheet, new Rectangle((int)location.X, (int)location.Y, SpriteWidth, SpriteHeight), Color.Blue);
        }

    }

} 
