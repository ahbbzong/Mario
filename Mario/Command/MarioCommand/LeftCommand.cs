using Game1;

namespace Mario.MarioCommand

{

    public class LeftCommand : MarioCommand
    {
        public LeftCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
            Mario.Left();
        }
    }
}
