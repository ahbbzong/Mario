using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class BlackScreen
    {
        private Texture2D Mario { get; set; }
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        private int counter;
        public BlackScreen()
        {
            Mario = Game1.Instance.Content.Load<Texture2D>("normalMarioRightIdle");
            counter = 0;
        }
        public void Update()
        {
            counter++;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (counter < 30)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, Mario.Width, Mario.Height);
                Rectangle destinationRectangle = new Rectangle(500, 500, Mario.Width, Mario.Height);

                spriteBatch.Draw(Mario, destinationRectangle, sourceRectangle, Color.White);
            }
        }

    }
}
