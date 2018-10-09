using Game1;

namespace Mario.MarioCommand

{

    public class RightCommand : ICommand
    {
        private Game1 game;
        public RightCommand(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            game.mario.Right();
        }
    }
}
