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
using Mario.ItemClasses;

namespace Mario.HeadUpDesign
{
    class HeadsUpDisplayBoard
    {
        public bool IsEnable { get; set; } = true;
        ITextSprite marioTitleTextSprite;
        ITextSprite scoreTextSprite;
        ITextSprite coinTextSprite;
        ITextSprite worldTitleTextSprite;
        ITextSprite worldTextSprite;
        ITextSprite timeTitleTextSprite;
        ITextSprite timeTextSprite;
        private const int distance = 12;
        private const int distanceOfSecRowText = 4 * distance;
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
            timeTextSprite.Text = fixText("" + Timer.Time, timeLength);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int marioTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5);
            marioTitleTextSprite.Location = new Vector2(marioTitleTextX, distance);
            marioTitleTextSprite.Draw(spriteBatch);

            int scoreTextX = marioTitleTextX;
            scoreTextSprite.Location = new Vector2(scoreTextX, distanceOfSecRowText);
            scoreTextSprite.Draw(spriteBatch);

            int coinTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText*6;
            coinTextSprite.Location = new Vector2(coinTextX, distanceOfSecRowText);


            ISprite CoinSprite = SpriteFactory.Instance.CreateSprite(ItemFactory.Instance.GetSpriteDictionary[typeof(Coin)]);
            coinTextSprite.Draw(spriteBatch);
            Vector2 coinSpriteLocation = new Vector2(coinTextSprite.Location.X - 32, coinTextSprite.Location.Y);
            CoinSprite.Draw(spriteBatch, coinSpriteLocation);


            int worldTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText * 12;
            worldTitleTextSprite.Location = new Vector2(worldTitleTextX, distance);
            worldTitleTextSprite.Draw(spriteBatch);

            int worldTextX = worldTitleTextX;
            worldTextSprite.Location = new Vector2(worldTextX, distanceOfSecRowText);
            worldTextSprite.Draw(spriteBatch);

            int timeTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (450 * 2 / 5) + distanceOfSecRowText * 18;
            timeTitleTextSprite.Location = new Vector2(timeTitleTextX, distance);
            timeTitleTextSprite.Draw(spriteBatch);

            int timeTextX = timeTitleTextX;
            timeTextSprite.Location = new Vector2(timeTextX, distanceOfSecRowText);
            timeTextSprite.Draw(spriteBatch);
        }

        public void Update()
        {
            scoreTextSprite.Text = fixText("" + ScoringSystem.Instance.Score, scoreLength);
            coinTextSprite.Text = "*" + fixText("" + CoinSystem.Instance.Coins, coinLength);
            timeTextSprite.Text = fixText("" + Timer.Time, timeLength);
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