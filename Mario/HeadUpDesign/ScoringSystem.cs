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

namespace Mario.HeadUpDesign
{
    public class ScoringSystem
    {
       

        private int score = 0;
        public int Score { get { return score; } }
        //fixing the combo parts
        //private ScoringComboManager comboManager;
        private List<IGameObject> FlagParts;
        private List<ITextSprite> DrawAndUpdateBars;
        private static ScoringSystem instance = new ScoringSystem();
        public static ScoringSystem Instance { get { return instance; } }
        public ScoringSystem()
        {
            FlagParts = new List<IGameObject>();
            DrawAndUpdateBars = new List<ITextSprite>();
        }
        public void RegisterMario(IMario mario)
        {
           // this.comboManager = new ScoringComboManager(mario);
        }
        public IGameObject RegisterPole(IGameObject pole)
        {
            this.FlagParts.Add(pole);
            return pole;
        }
        public void ResetScore()
        {
            score = 0;
        }

        public void AddPointsForBreakingBlock()
        {
            score += ScoreUtil.BreakingBlockScore;
        }
        public void AddPointsForCollectingItem(IGameObject item)
        {
            score += ScoreUtil.ItemCollectedScore;
            CreateNewScoreAnimation(item, ScoreUtil.ItemCollectedScore);
        }
        public void AddPointsForCoin()
        {
            score += ScoreUtil.CoinCollectedScore;
        }
        public void AddPointsForRestTime()
        {
            score += ScoreUtil.SecondBonusScore;
            //wating for sounds here
           // SoundManager.Instance.PlayCoinSound();
        }
        public void AddPointsForStompingEnemy(IGameObject enemy)
        {
            int scoreToAdd = 500;
            score += scoreToAdd;
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyBelowBlockHit(IGameObject enemy)
        {
            int scoreToAdd = ScoreUtil.EnemyBelowBlockHitScore;
            score += scoreToAdd;
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFireballGoombaHit(IGameObject goomba)
        {
            int scoreToAdd = ScoreUtil.SpecialGoombaHitScore;
            score += scoreToAdd;
            CreateNewScoreAnimation(goomba, scoreToAdd);
        }
        public void AddPointsForFireballKoopaHit(IGameObject koopa)
        {
            int scoreToAdd = ScoreUtil.SpecialKoopaHitScore;
            score += scoreToAdd;
            CreateNewScoreAnimation(koopa, scoreToAdd);
        }
        public void AddPointsForInitiatingShell(IGameObject enemy)
        {
            int scoreToAdd = 500;
            score += scoreToAdd;
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyHitByShell(IGameObject enemy)
        {
            int scoreToAdd = 500;
            score += scoreToAdd;
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFinalPole(Rectangle marioDestination)
        {
            int scoreToAdd = ScoreUtil.OffTheFlagFifthScore;
            if (marioDestination.Y < 100)//hard code in, need to fix the magic number here
            {
                scoreToAdd = ScoreUtil.OffTheFlagHighestScore;
            }
            else if (marioDestination.Y <300)
            {
                scoreToAdd = ScoreUtil.OffTheFlagSecondScore;
            }
            else if (marioDestination.Y < 500)
            {
                scoreToAdd = ScoreUtil.OffTheFlagThirdScore;
            }
            else if (marioDestination.Y < 700)
            {
                scoreToAdd = ScoreUtil.OffTheFlagFourthScore;
            }
            score += scoreToAdd;
            //pass in the rectangle for the score! add it later
            //second params
            CreateNewScoreAnimation(marioDestination, GameObjectManager.Instance.Mario.Box, scoreToAdd);
        }

        public void SetMarioAirbourneToFalse()
        {
           // comboManager.IsMarioAirbourne = false;
        }
        public void SetMarioEnemyHitThisIterationToFalse()
        {
           // comboManager.HitEnemyAlreadyThisIteration = false;
        }

        private void CreateNewScoreAnimation(IGameObject gameObject, int scoreToDisplay)
        {
            Rectangle objectBox = gameObject.Box;
            Vector2 location = new Vector2(objectBox.X, objectBox.Y);
            //create the score board, fly up a little, disappear
            ITextSprite scoreTextSprite;
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.Text = ""+scoreToDisplay;
            scoreTextSprite.IsFlying = true;
            DrawAndUpdateBars.Add(scoreTextSprite);
        }
        private void CreateNewScoreAnimation(Rectangle marioDestination, Rectangle poleDestination, int scoreToDisplay)
        {
            //create the score board, fly up, disappear
            
        }
        public void Update()
        {
            foreach (ITextSprite TextBars in DrawAndUpdateBars)
            {
                int difference = (int)TextBars.InitialY - (int)TextBars.Location.Y;
                if (TextBars.IsFlying && difference < 10)
                {
                    TextBars.Location = new Vector2(TextBars.Location.X, TextBars.Location.Y - 1);
                }
                else if (difference > 10 || !TextBars.IsFlying)
                {
                    DrawAndUpdateBars.Remove(TextBars);
                    DrawAndUpdateBars.Sort();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ITextSprite TextBars in DrawAndUpdateBars)
            {
                TextBars.Draw(spriteBatch);
            }
        }
    }
}
