using Game1;

namespace Mario.MarioCommand
{

    public class BeStarMarioCommand : ICommand
    {
        private Game1 myMario;
        public BeStarMarioCommand(Game1 mario)
        {
            myMario = mario;
        }
        public void Update()
        {
            myMario.mario.BeStarMario();
        }
    }
}
