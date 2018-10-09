using Game1;

namespace Mario.BlocksCommand
{

    public class QuitCommand : ICommand
    {
        private Game1 game;
        public QuitCommand(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            game.Exit();
        }
    }
}