using Game1;

namespace Mario.MarioCommand

{

    public class DeadCommand : ICommand
    {
        private Game1 game;
        public DeadCommand(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            game.mario.Dead();

        }
    }
}
