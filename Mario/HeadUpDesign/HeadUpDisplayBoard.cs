using Mario.HeadUpDesign;
using Mario.Sprite;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Game1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Mario.Factory;

namespace Mario.HeadUpDesign
{
    class HeadsUpDisplayBoard //: IDisplayPanel
    {
        public bool IsEnable { get; set; } = true;
        ITextSprite marioTitleTextSprite;
        ITextSprite scoreTextSprite;
        ITextSprite coinTextSprite;
        ITextSprite worldTitleTextSprite;
        ITextSprite worldTextSprite;
        ITextSprite timeTitleTextSprite;
        ITextSprite timeTextSprite;
        private const int distance = 10;
        private const int distanceOfSecRowText = 2 * distance;
        private const int scoreLength = 6;
        private const int coinLength = 2;
        private const int timeLength = 3;

        public HeadsUpDisplayBoard()
        {


            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.Text = "MARIO";
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.Text = fixText("" + 0, scoreLength);
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.Text = "*" + fixText("" + 0, coinLength);
            worldTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTitleTextSprite.Text = "WORLD";
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.Text = "1-1";
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.Text = "TIME";
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.Text = fixText("" + DateTime.Now, timeLength);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int marioTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5);
            marioTitleTextSprite.Draw(spriteBatch, new Vector2(marioTitleTextX, distance));

            int scoreTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText*6;
            scoreTextSprite.Draw(spriteBatch, new Vector2(scoreTextX, distanceOfSecRowText));

            int coinTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText*12;
            coinTextSprite.Draw(spriteBatch, new Vector2(coinTextX, distanceOfSecRowText));

            int worldTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText*18;
            worldTitleTextSprite.Draw(spriteBatch, new Vector2(worldTitleTextX, distance));

            int worldTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText * 24;
            worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, distanceOfSecRowText));

            int timeTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText * 30;
            timeTitleTextSprite.Draw(spriteBatch, new Vector2(timeTitleTextX, distance));

            int timeTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText * 34;
            timeTextSprite.Draw(spriteBatch, new Vector2(timeTextX, distanceOfSecRowText));
        }

        public void Update()
        {
           
        }

        private static String fixText(String str, int length)
        {
            while (str.Length < length)
            {
                str = "0" + str;
            }

            return str;
        }

    }

}