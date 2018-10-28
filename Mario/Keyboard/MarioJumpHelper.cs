using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    public class MarioJumpHelper
    {

        private bool wTimerIsOn;
        private int delay;
        private bool wLetGo;

        public MarioJumpHelper()
        {
            wTimerIsOn = true;
            wLetGo = true;
            delay = ControllerUtil.jumpDelay;
        }

        public void HandleRequest(IMario mario,Dictionary<Keys, ICommand> controllerMappings)
        {
            if (wTimerIsOn && !wLetGo)
            {

                controllerMappings[Keys.Z].Execute();

            }
            else
            {
                if (!mario.IsUp() && wLetGo)
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
                if (delay == ControllerUtil.jumpMaxDelay)
                {
                    wTimerIsOn = false;
                    delay = ControllerUtil.jumpDelay;
                }
            }
        }
    }
}
