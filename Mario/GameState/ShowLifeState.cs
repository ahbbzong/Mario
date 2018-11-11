using Game1;
using Mario.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class ShowLifeState : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.ShowLife;
            }
        }
        public ShowLifeState(AbstractGame game)
        {
            this.game = game;
        }

        public void GameOver()
        {
        }

        public void ContinueGame()
        {
            game.State = new PlayState(game);
        }
    }
}
