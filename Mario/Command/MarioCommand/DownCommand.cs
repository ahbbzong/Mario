using Game1;

namespace Mario.MarioCommand

{

    public class DownCommand : ICommand
    {
        private Game1 myMario;
        public DownCommand(Game1 mario)
        {
            myMario = mario;
        }
        public void Update()
        {
            myMario.mario.Down();
        }
    }
}
