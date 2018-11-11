using Game1;
using Mario.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class PlayState : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.Play;
            }
        }
        public PlayState(AbstractGame game)
        {
            this.game = game;
        }

        public void GameOver()
        {
            game.State = new GameOverState(game);
        }

        public void ContinueGame()
        {
            game.State = new ShowLifeState(game);
        }
    }
}
