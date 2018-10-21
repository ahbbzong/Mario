using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mario.XMLRead;
using Microsoft.Xna.Framework.Input;

namespace Spaghetti
{
    public class MarioJumpHandler
    {

        private bool wTimerIsOn;
        private int delay;
        private bool wLetGo;

        public MarioJumpHandler()
        {
            wTimerIsOn = false;
            wLetGo = true;
            delay = 10;
        }

        public void HandleRequest( ItemManager itemManager, Dictionary<Keys, ICommand> controllerMappings)
        {
            if (wTimerIsOn && !wLetGo)
            {

                controllerMappings[Keys.W].Execute();

            }
            else
            {
                if (!game.PlayerList[MarioUtil.marioPlayerPos].IsMovingUp() && wLetGo)
                {
                    wLetGo = false;
                    wTimerIsOn = true;
                }
            }

        }

        public void CheckWLetGo(Keys[] pressedKeys)
        {
            if (!pressedKeys.Contains(Keys.W))
            {
                wLetGo = true;
            }
        }

        public void UpdateTimer()
        {
            if (wTimerIsOn)
            {
                delay++;
                if (delay == 30)
                {
                    wTimerIsOn = false;
                    delay = 0;
                }
            }
        }
    }
}
