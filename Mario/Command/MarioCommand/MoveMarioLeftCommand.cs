using Game1;

namespace Mario.MarioCommand

{

    public class MoveMarioLeftCommand : MarioCommand
    {
        public MoveMarioLeftCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
            Mario.GoLeft();
        }
    }
}
