using Game1;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.Sprite;
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
        ITextSprite lifeTextSprite;
        IGameObject backgroundSprite;
            private int counter;
            public GameOverDisplay()
            {
                lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
                counter = 0;
                backgroundSprite = BackgroundFactory.Instance.GetBackgroundObject("BlackGround", new Vector2(0, 0));
                lifeTextSprite.Text = "Game Over";
        }
            public void Update()
            {
                counter++;
            }
            public void Draw(SpriteBatch spriteBatch)
            {
               
                backgroundSprite.Draw(spriteBatch);
                lifeTextSprite.Draw(spriteBatch, new Vector2(600, 500));
                
            
            }
    }
}
