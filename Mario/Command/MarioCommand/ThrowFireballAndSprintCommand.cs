using Game1;
using Mario.Enums;
using Mario.Sound;
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
            MotionEffect.Instance.EffectPlay(MotionType.marioFireball);
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
