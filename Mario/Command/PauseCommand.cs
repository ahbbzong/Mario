using Game1;

namespace Mario.BlocksCommand
{

    public class PauseCommand : ICommand
    {
        private Game1 game;
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.isPause)
            {
                game.isPause = false;
            }
            else
            {
                game.isPause = true;
            }
        }

        
    }
}