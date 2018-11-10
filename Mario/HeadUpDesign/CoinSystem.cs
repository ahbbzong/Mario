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
        private static CoinSystem instance = new CoinSystem();
        public static CoinSystem Instance { get { return instance; } }
        private int coins = 0;
        public int Coins { get { return coins; } }
        private const int maxCoin = 99;
        public void AddCoin()
        {
            if (coins < maxCoin)
            {
                coins++;
            }
            else if (coins == maxCoin)
            {
                coins = 0;
                GameObjectManager.Instance.Mario.Lives++;
               // SoundManager.Instance.Play1UpSound();
            }
            ScoringSystem.Instance.AddPointsForCoin();
            //SoundManager.Instance.PlayCoinSound();
        }

        public void ResetCoin()
        {
            coins = 0;
        }
    }
}
