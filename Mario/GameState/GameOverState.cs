using Game1;
using Mario.GameState;
using Mario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class GameOverState : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.GameOver;
            }
        }
        public GameOverState(AbstractGame game)
        {
            MotionSound.GameOver.Play();
            this.game = game;
        }

        public void GameOver()
        {

        }

        public void ContinueGame()
        {
            
        }
    }
}
