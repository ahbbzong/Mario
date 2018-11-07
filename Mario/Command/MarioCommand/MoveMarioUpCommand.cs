using Game1;

namespace Mario.MarioCommand

{

    public class MoveMarioUpCommand : MarioCommand
    {
        public MoveMarioUpCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.GoUp();
            
        }
    }
}
