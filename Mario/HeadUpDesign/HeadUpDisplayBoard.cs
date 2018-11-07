using Mario.HeadUpDesign;
using Mario.Sprite;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;
using System;
using Game1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

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


            //need to move somewhere else
            TextSpriteFactory.Instance.LoadAllTextures(Game1.Instance.Content);

            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.Text = "MARIO";
            //scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            /*scoreTextSprite.Text = fixText("" + ScoringSystem.Instance.Score, scoreLength);
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.Text = "*" + fixText("" + CoinSystem.Instance.Coins, coinLength);
            */worldTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
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