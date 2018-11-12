using Game1;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Display
{
  public  class GameOverDisplay: IDisplay
    {
      
            IGameObject backgroundSprite;
            private int counter;
            public GameOverDisplay()
            {
                counter = 0;
                backgroundSprite = BackgroundFactory.Instance.GetBackgroundObject("BlackGround", new Vector2(0, 0));
            }
            public void Update()
            {
                counter++;
            }
            public void Draw(SpriteBatch spriteBatch)
            {
                if (counter < 100)
                {
                    backgroundSprite.Draw(spriteBatch);
                }
            }
    }
}
