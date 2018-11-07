using Game1;

namespace Mario.MarioCommand

{

    public class MoveMarioDownCommand : MarioCommand
    {
        public MoveMarioDownCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.GoDown();
        }
    }
}
