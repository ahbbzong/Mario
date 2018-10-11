using Game1;
using Mario.MarioCommand;
namespace Mario.MarioCommand

{

    public class DeadCommand : MarioCommand
    {
        public DeadCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.Dead();

        }
    }
}
