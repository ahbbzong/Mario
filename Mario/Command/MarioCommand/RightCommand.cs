using Game1;

namespace Mario.MarioCommand

{

    public class RightCommand : MarioCommand
    {
        public RightCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
			Mario.Right();
        }
    }
}
