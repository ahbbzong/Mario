using Game1;
using System.Timers;

namespace Mario.MarioCommand

{

    public class ThrowFireballCommand : MarioCommand
    {
        private int counter;
        public ThrowFireballCommand(IMario mario):base(mario)
        {
            counter = 0;
        }
        public override void Execute()
        {
            Mario.ThrowFireball();
        }
    }
}
