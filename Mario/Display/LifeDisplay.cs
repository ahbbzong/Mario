using Game1;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
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
   public class LifeDisplay : IDisplay
    {
        ISprite marioSprite;
        IGameObject backgroundSprite;
        ITextSprite lifeTextSprite;
      
        private int counter;
        public LifeDisplay()
        {
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            lifeTextSprite.Text = "X ";
            lifeTextSprite.Text += LifeCounter.Instance.LifeRemains().ToString();
            counter = 0;
            backgroundSprite = BackgroundFactory.Instance.GetBackgroundObject("BlackGround", new Vector2(0, 0));
            marioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[typeof(NormalMarioPowerupState)][typeof(RightIdleMarioMovementState)]);
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
                lifeTextSprite.Draw(spriteBatch, new Vector2(550, 500));
                marioSprite.Draw(spriteBatch, new Microsoft.Xna.Framework.Vector2(500, 500));
            }
           
        }
    }
}
