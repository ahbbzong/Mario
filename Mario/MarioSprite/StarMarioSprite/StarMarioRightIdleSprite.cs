using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.StarMarioSprite
{


    public class StarMarioRightIdleSprite : StaticSprite
    {

  

        public StarMarioRightIdleSprite(Texture2D rightIdleSheet):base(rightIdleSheet)
        {


        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(SpriteSheet, new Rectangle((int)location.X, (int)location.Y, SpriteWidth, SpriteHeight), Color.Blue);
        }

    }
}
