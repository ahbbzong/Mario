using Game1;

namespace Mario.MarioCommand

{

	public class SprintAndFireProjectileMarioCommand : MarioCommand
    {
        int counter;
        bool fire;
        public SprintAndFireProjectileMarioCommand(IMario mario):base(mario)
        {
            counter = 0;
            fire = true;
        }
        public override void Execute()
        {
            Mario.Sprint();
            counter++;
            if (counter == 20&&!fire)
            {
                fire = true;
            }
            if (fire)
            {
                Mario.ThrowProjectile();
                counter = 0;
                fire = false;
            }
        }
    }
}
