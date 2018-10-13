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
     public abstract class AnimatedSprite : ISprite
    {
        protected Texture2D SpriteSheet { get; set; }
        protected int SpriteWidth { get; set; }
        protected int SpriteHeight { get; set; }
        protected int Rows { get; set; }
        protected int Columns { get; set; }
        protected int CurrentFrame { get; set; }
        protected int TotalFrame { get; set; }
        protected int Delay { get; set; }

        protected AnimatedSprite(Texture2D spriteSheet, int rows, int columns)
        {
            SpriteSheet = spriteSheet;
            SpriteWidth = spriteSheet.Width;
            SpriteHeight = spriteSheet.Height;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrame = rows * columns;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = SpriteSheet.Width / Columns;
            int height = SpriteSheet.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(SpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
		public virtual int Width => SpriteWidth / Columns;
		public virtual int Height => SpriteHeight / Rows;
		public virtual void Update()
        {
            Delay++;
            if (Delay == 5)
            {
                Delay = 0;
                CurrentFrame++;
            }
            if (CurrentFrame == TotalFrame)
            {
                CurrentFrame = 0;
            }
        }
    }
}