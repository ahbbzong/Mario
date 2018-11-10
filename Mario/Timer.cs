using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Timers;
using Mario.HeadUpDesign;

namespace Mario
{
    static class Timer
    {
        public static int MarioLife { get; set; } = 3;

        public static int Time { get; set; } = 0;
        public static int HighestScore { get; set; } = 0;

        private static int counter = 0;
        private static bool isTimeTicking = false;
        private static int maxTime = 300;

        public static void UpdateHighestScore()
        {
            if (ScoringSystem.Instance.Score > HighestScore)
            {
                HighestScore = ScoringSystem.Instance.Score;
            }
        }

        public static void ResetTimer()
        {
            Time = maxTime;
            isTimeTicking = false;
        }

        public static void ClearTimer()
        {
            Time = 0;
            isTimeTicking = false;
        }

        public static void StartTimer()
        {
            isTimeTicking = true;
        }

        public static void StopTimer()
        {
            isTimeTicking = false;
        }

        public static void tick(GameTime gameTime)
        {
            if (isTimeTicking)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter >= 1000)
                {
                    Time--;
                    counter = 0;
                }
                if (Time == 0)
                {
                    GameObjectManager.Instance.Mario.BeDead();
                    isTimeTicking = false;
                }
            }
        }
    }
}
