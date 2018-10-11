using Game1;

namespace Mario.MarioCommand

{

    public class UpCommand : MarioCommand
    {
        public UpCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.Up();
            
        }
    }
}
