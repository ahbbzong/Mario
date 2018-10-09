using Game1;

namespace Mario.MarioCommand

{

    public class BeSuperMarioCommand : ICommand
    {
        private Game1 myMario;
        public BeSuperMarioCommand(Game1 mario)
        {
            myMario = mario;
        }
        public void Update()
        {
            myMario.mario.BeSuperMario();

        }
    }
}
