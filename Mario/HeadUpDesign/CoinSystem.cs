using Mario.HeadUpDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.HeadUpDesign
{
    public class CoinSystem
    {
        private static readonly CoinSystem instance = new CoinSystem();
        public static CoinSystem Instance { get { return instance; } }
        private int coins = ScoreUtil.ZeroCoin;
        public int Coins { get { return coins; } }
        private const int maxCoin = ScoreUtil.MaxCoin;
        public void AddCoin()
        {
            if (coins < maxCoin)
            {
                coins++;
            }
            else if (coins == maxCoin)
            {
                coins = ScoreUtil.ZeroCoin;
                LifeCounter.Instance.IncreaseLife();
               // SoundManager.Instance.Play1UpSound();
            }
            ScoringSystem.Instance.AddPointsForCoin();
            //SoundManager.Instance.PlayCoinSound();
        }

        public void ResetCoin()
        {
            coins = ScoreUtil.ZeroCoin;
        }
    }
}
