using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.AbstractClass
{
     public abstract class StaticSprite : ISprite
    {
        protected Texture2D SpriteSheet { get; set; }
        protected int SpriteWidth { get; set; }
        protected int SpriteHeight { get; set; }
        protected StaticSprite(Texture2D spriteSheet)
        {
            SpriteSheet = spriteSheet;
            SpriteWidth = spriteSheet.Width;
            SpriteHeight = spriteSheet.Height;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(SpriteSheet, new Rectangle((int)location.X, (int)location.Y, SpriteWidth, SpriteHeight), Color.White);
        }
		public virtual int Width => SpriteWidth;
		public virtual int Height => SpriteHeight;
		public virtual void Update()
        {
            //Need to be overriden.
        }
    }
}
