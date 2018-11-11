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
        public static int Time { get; set; } = 300;
        public static int HighestScore { get; set; } = 0;

        private static int counter = 0;
        private static bool timeRunning = false;
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
            timeRunning = false;
        }

        public static void CleanTimer()
        {
            Time = 0;
            timeRunning = false;
        }

        public static void StartTimer()
        {
            timeRunning = true;
        }

        public static void StopTimer()
        {
            timeRunning = false;
        }

        public static void TimerCheckingTime(GameTime gameTime)
        {
            if (timeRunning)
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
                    timeRunning = false;
                }
            }
        }
    }
}
