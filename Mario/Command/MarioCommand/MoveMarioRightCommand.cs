using Game1;

namespace Mario.MarioCommand

{

    public class MoveRightMarioCommand : MarioCommand
    {
        public MoveRightMarioCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
			Mario.GoRight();
        }
    }
}
