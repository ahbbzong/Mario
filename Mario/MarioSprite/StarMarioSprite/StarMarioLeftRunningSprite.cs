﻿using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.StarMarioSprite
{
    public class StarMarioLeftRunningSprite : AnimatedSprite
    {


        public StarMarioLeftRunningSprite(Texture2D leftRunningSheet, int rows, int columns) : base(leftRunningSheet, rows, columns)
        {

        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = SpriteSheet.Width / Columns;
            int height = SpriteSheet.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(SpriteSheet, destinationRectangle, sourceRectangle, Color.Blue);
        }
    }
}
