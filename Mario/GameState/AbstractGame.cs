using Game1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameState
{
    public abstract class AbstractGame : Game
    {
        private GraphicsDeviceManager graphics;

        public GraphicsDeviceManager GraphicsManager
        {
            get
            {
                return graphics;
            }
            set
            {
                graphics = value;
            }
        }

        public IGameState State { get; set; }

      
    }
}
