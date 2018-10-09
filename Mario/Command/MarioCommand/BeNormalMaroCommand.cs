using Game1;

namespace Mario.MarioCommand

{

    public class BeNormalMarioCommand : ICommand
    {
        private Game1 myMario;
        public BeNormalMarioCommand(Game1 mario)
        {
            myMario = mario;
        }
        public void Update()
        {
            myMario.mario.BeNormalMario();

        }
    }
}
