using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.GoombaSprite
{
    public class StompedKoopaSprite : StaticSprite
    {
        int counter;


        public StompedKoopaSprite(Texture2D stompedKoopaSheet) : base(stompedKoopaSheet)
        {
            counter = 0;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if(counter<10)
            spriteBatch.Draw(SpriteSheet, new Rectangle((int)location.X, (int)location.Y, SpriteWidth, SpriteHeight), Color.White);
        }
        public override void Update()
        {
            counter++;
            if (counter > 10)
            {
                counter = 10;
            }
        }

    }
}
