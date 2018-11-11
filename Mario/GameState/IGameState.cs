using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public enum GameStates
    {
       ShowLife,GameOver,Play
    }
    public interface IGameState
    {
        GameStates Type { get; }
        void ContinueGame();
        void GameOver();

    }
}
