﻿using Game1;
using System.Timers;

namespace Mario.MarioCommand

{

    public class ThrowFireballAndSprintCommand : MarioCommand
    {
        int counter;
        bool fire;
        public ThrowFireballAndSprintCommand(IMario mario):base(mario)
        {
            counter = 0;
            fire = true;
        }
        public override void Execute()
        {
            Mario.Sprint();
            counter++;
            if (counter == 20&&!fire)
            {
                fire = true;
            }
            if (fire)
            {
                Mario.ThrowFireball();
                counter = 0;
                fire = false;
            }
        }
    }
}
