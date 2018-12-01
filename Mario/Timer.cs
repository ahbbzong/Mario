using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Timers;
using Mario.HeadUpDesign;
using Game1;

namespace Mario
{
    static class Timer
    {
      
        public static int Time { get; set; } = TimerUtil.MaxTimer;
        private static int counter = TimerUtil.Zero;
        private static bool timeRunning = false;
        private static readonly int maxTime = TimerUtil.MaxTimer;
        public static int TimeRecord { get; set; } = TimerUtil.Zero;
        public static void ResetTimer()
        {
            Time = maxTime;
            timeRunning = false;
        }

        public static void CleanTimer()
        {
            Time = TimerUtil.Zero;
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
            TimeRecord = Time;
                if (timeRunning)
                {
                    counter += gameTime.ElapsedGameTime.Milliseconds;
                    if (counter >= TimerUtil.Thousand)
                    {
                        Time--;
                        counter = TimerUtil.Zero;
                    }
                    if (Time == TimerUtil.Zero && (!GameObjectManager.Instance.Mario.IsAtEnd()))
                    {
                        GameObjectManager.Instance.Mario.BeDead();
                        timeRunning = false;
                    }
                }
        }
        public static void UndergroundTimer(GameTime gameTime)
        {
            if (timeRunning)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter >= TimerUtil.Ten)
                {
                    Time--;
                    counter = TimerUtil.Zero;
                }
                if (Time == TimerUtil.Zero && (!GameObjectManager.Instance.Mario.IsAtEnd()))
                {
                    GameObjectManager.Instance.Mario.Position -= new Vector2(CollisionUtil.marioOffesetX, CollisionUtil.marioOffsetY);
                    Time = TimeRecord;
                }
            }
        }
        public static void ExtendTime()
        {
            if(Time<TimerUtil.MaxTimer)
                Time += TimerUtil.CoinExtentTime;
        }
    }
}
