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

namespace Mario.HeadUpDesign
{
    class ScoreBarFlyingOut
    {
        public static void CreateNewScoreAnimation(IGameObject gameObject, int scoreToDisplay)
        {
            Rectangle objectBox = gameObject.Box;
            Vector2 location = new Vector2(objectBox.X, objectBox.Y);
            ITextSprite scoreTextSprite;
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.Text = "" + scoreToDisplay;
            scoreTextSprite.IsFlying = true;
            scoreTextSprite.Location = location;
            scoreTextSprite.InitialY = (int)location.Y;
            GameObjectManager.Instance.DrawAndUpdateBars.Add(scoreTextSprite);
            System.Console.WriteLine("create the bar");
            System.Console.WriteLine(GameObjectManager.Instance.DrawAndUpdateBars.Count);
        }
        public static void Update()
        {
            foreach (ITextSprite TextBars in GameObjectManager.Instance.DrawAndUpdateBars)
            {
                System.Console.WriteLine("UPDATE");
                int difference = (int)TextBars.InitialY - (int)TextBars.Location.Y;
                System.Console.WriteLine(difference);
                if (TextBars.IsFlying && difference < ScoreUtil.FlyingBar)
                {
                    TextBars.Location = new Vector2(TextBars.Location.X, TextBars.Location.Y - 1);
                }
                else
                 {
                    TextBars.IsFlying = false;
                 }
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (ITextSprite TextBars in GameObjectManager.Instance.DrawAndUpdateBars)
            if (TextBars.IsFlying)
            {
                TextBars.Draw(spriteBatch);
            }
        }
    }
}
