using Game1;

namespace Mario.MarioCommand

{

    public class LeftCommand : ICommand
    {
        private Game1 game;
        public LeftCommand(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            game.mario.Left();
        }
    }
}
