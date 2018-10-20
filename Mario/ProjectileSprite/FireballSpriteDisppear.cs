using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Items
{
   public class FireballSpriteDisppear : AnimatedSprite
    {
        
      
        public FireballSpriteDisppear(Texture2D fireballSheet, int rows, int columns) : base(fireballSheet, rows,columns)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        { 
        }

    }
}
