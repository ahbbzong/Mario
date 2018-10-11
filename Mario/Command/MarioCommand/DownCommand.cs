using Game1;

namespace Mario.MarioCommand

{

    public class DownCommand : MarioCommand
    {
        public DownCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.Down();
        }
    }
}
