using Game1;

namespace Mario.MarioCommand

{

    public class UpCommand : ICommand
    {
        private Game1 game;
        public UpCommand(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            game.mario.Up();
            
        }
    }
}
