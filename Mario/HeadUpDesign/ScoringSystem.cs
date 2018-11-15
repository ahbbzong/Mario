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
        private MultiplerForScore multilperForScore;
        private List<IGameObject> FlagParts;
        //private ITextSprite textSpriteDrawUpdate;
        private static ScoringSystem instance = new ScoringSystem();
        public static ScoringSystem Instance { get { return instance; } }
        private ScoringSystem()
        {
            FlagParts = new List<IGameObject>();
           multilperForScore = new MultiplerForScore();
        }
        public IGameObject RegisterPole(IGameObject pole)
        {
            this.FlagParts.Add(pole);
            return pole;
        }
        public void ResetScore()
        {
            score = ScoreUtil.ZeroScore;
        }

        public void AddPointsForBreakingBlock()
        {
            score += ScoreUtil.BreakingBlockScore;
        }
        public void AddPointsForCollectingItem(IGameObject item)
        {
            score += ScoreUtil.ItemCollectedScore;
            ScoreBarFlyingOut.CreateNewScoreAnimation(item, ScoreUtil.ItemCollectedScore);
        }
        public void AddPointsForCoin()
        {
            score += ScoreUtil.CoinCollectedScore;
        }
        public void AddPointsForRestTime()
        {
            score += ScoreUtil.SecondBonusScore;
        }
        public void AddPointsForStompingEnemy(IGameObject enemy)
        {
            int scoreToAdd = multilperForScore.DetermineStompSequence();
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyBelowBlockHit(IGameObject enemy)
        {
            int scoreToAdd = ScoreUtil.EnemyBelowBlockHitScore;
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFireballGoombaHit(IGameObject goomba)
        {
            int scoreToAdd = ScoreUtil.SpecialGoombaHitScore;
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(goomba, scoreToAdd);
        }
        public void AddPointsForFireballKoopaHit(IGameObject koopa)
        {
            int scoreToAdd = ScoreUtil.SpecialKoopaHitScore;
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(koopa, scoreToAdd);
        }
        public void AddPointsForInitiatingShell(IGameObject enemy)
        {
            int scoreToAdd = multilperForScore.DetermineShellInitializationSequence(enemy);
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyHitByShell(IGameObject enemy)
        {
            int scoreToAdd = multilperForScore.DetermineShellHitSequence(enemy);
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFinalPole(Rectangle marioDestination)
        {
            int scoreToAdd = ScoreUtil.OffTheFlagFifthScore;
            if (marioDestination.Y < ScoreUtil.FlagFirst)//hard code in, need to fix the magic number here
            {
                scoreToAdd = ScoreUtil.OffTheFlagHighestScore;
            }
            else if (marioDestination.Y <ScoreUtil.FlagSecond)
            {
                scoreToAdd = ScoreUtil.OffTheFlagSecondScore;
            }
            else if (marioDestination.Y < ScoreUtil.FlagThird)
            {
                scoreToAdd = ScoreUtil.OffTheFlagThirdScore;
            }
            else if (marioDestination.Y < ScoreUtil.FlagForth)
            {
                scoreToAdd = ScoreUtil.OffTheFlagFourthScore;
            }
            score += scoreToAdd;
            ScoreBarFlyingOut.CreateNewScoreAnimation(GameObjectManager.Instance.Mario,scoreToAdd);
        }
        
        public void SetMarioEnemyHitThisIterationToFalse()
        {
           multilperForScore.HitEnemyAlreadyThisIteration = false;
        }
    }
}
