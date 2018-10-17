using Game1;

namespace Mario.MarioCommand

{

    public class ThrowFireballCommand : MarioCommand
    {
        public ThrowFireballCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
            Mario.ThrowFireball();
        }
    }
}
