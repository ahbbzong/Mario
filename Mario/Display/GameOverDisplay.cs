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
            public GameOverDisplay()
            {
                lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
                backgroundSprite = BackgroundFactory.Instance.GetBackgroundObject("BlackGround", new Vector2(SpriteUtil.Zero, SpriteUtil.Zero));
                lifeTextSprite.Text = "Game Over";
        }
            public void Update()
            {

            }
            public void Draw(SpriteBatch spriteBatch)
            {
                backgroundSprite.Draw(spriteBatch);
                lifeTextSprite.Location = new Vector2(SpriteUtil.gameOverPositionX, SpriteUtil.gameOverPositionY);
                lifeTextSprite.Draw(spriteBatch);
            }
    }
}
