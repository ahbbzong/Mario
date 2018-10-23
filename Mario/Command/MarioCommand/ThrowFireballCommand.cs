using Game1;
using System.Timers;

namespace Mario.MarioCommand

{

    public class ThrowFireballCommand : MarioCommand
    {
        int counter;
        public ThrowFireballCommand(IMario mario):base(mario)
        {
            counter = 0;
        }
        public override void Execute()
        {
            counter++;
            if (counter == 3)
            {
                Mario.ThrowFireball();
                counter = 0;
            }
        }
    }
}
