using Game1;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.HeadUpDesign
{
    public class ScoringSystem
    {
        private const int BreakingBlockScore = 50;
        private const int ItemCollectedScore = 500;
        private const int CoinCollectedScore = 100;
        private const int SecondBonusScore = 10;
        private const int EnemyBelowBlockHitScore = 100;
        private const int SpecialGoombaHitScore = 100;
        private const int SpecialKoopaHitScore = 200;
        private const int OffTheFlagHighestScore = 5000;
        private const int OffTheFlagSecondScore = 2000;
        private const int OffTheFlagThirdScore = 800;
        private const int OffTheFlagFourthScore = 400;
        private const int OffTheFlagFifthScore = 100;
        private const int FlagFirstCutoff = 1;
        private const int FlagSecondCutoff = 3;
        private const int FlagThridCutoff = 4;
        private const int FlagFourthCutoff = 5;

        private int score = 0;
        public int Score { get { return score; } }
        //fixing the combo parts
        //private ScoringComboManager comboManager;
        private List<IGameObject> FlagParts;

        private static ScoringSystem instance = new ScoringSystem();
        public static ScoringSystem Instance { get { return instance; } }
        private ScoringSystem()
        {
            this.FlagParts = new List<IGameObject>();
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
            score += BreakingBlockScore;
        }
        public void AddPointsForCollectingItem(IGameObject item)
        {
            score += ItemCollectedScore;
            CreateNewScoreAnimation(item, ItemCollectedScore);
        }
        public void AddPointsForCoin()
        {
            score += CoinCollectedScore;
        }
        public void AddPointsForRestTime()
        {
            score += SecondBonusScore;
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
            int scoreToAdd = EnemyBelowBlockHitScore;
            score += scoreToAdd;
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForSpecialGoombaHit(IGameObject goomba)
        {
            int scoreToAdd = SpecialGoombaHitScore;
            score += scoreToAdd;
            CreateNewScoreAnimation(goomba, scoreToAdd);
        }
        public void AddPointsForSpecialKoopaHit(IGameObject koopa)
        {
            int scoreToAdd = SpecialKoopaHitScore;
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
            int scoreToAdd = OffTheFlagFifthScore;
            if (marioDestination.Y < 100)//hard code in, need to fix the magic number here
            {
                scoreToAdd = OffTheFlagHighestScore;
            }
            else if (marioDestination.Y <300)
            {
                scoreToAdd = OffTheFlagSecondScore;
            }
            else if (marioDestination.Y < 500)
            {
                scoreToAdd = OffTheFlagThirdScore;
            }
            else if (marioDestination.Y < 700)
            {
                scoreToAdd = OffTheFlagFourthScore;
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

        private static void CreateNewScoreAnimation(IGameObject gameObject, int scoreToDisplay)
        {
            Rectangle objectBox = gameObject.Box;
            Vector2 location = new Vector2(objectBox.X, objectBox.Y);
            //create the score board, fly up a little, disappear
            
        }
        private static void CreateNewScoreAnimation(Rectangle marioDestination, Rectangle poleDestination, int scoreToDisplay)
        {
            //create the score board, fly up, disappear
            
        }
    }
}
