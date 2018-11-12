using Game1;

namespace Mario.BlocksCommand
{

    public class ResetCommand : ICommand
    {
        private Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
            LifeCounter.Instance.ResetLife();
        }


    }
}