using Game1;

namespace Mario.MarioCommand
{

    public class BeFireMarioCommand : ICommand
    {
        private Game1 game;
        public BeFireMarioCommand(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            game.mario.BeFireMario();
        }
    }
}
