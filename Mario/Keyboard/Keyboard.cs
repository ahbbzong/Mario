using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Mario.MarioCommand;
using Mario.BlocksCommand;
using Game1;
using System.Linq;

namespace Mario
{
    public class Keyboards : IController
    {
        private Dictionary<Keys, ICommand> keyboardMap;
        private Keys previous;
        public Keyboards()
        {
        }

        public void Initialize(IMario mario)
        {
            keyboardMap = new Dictionary<Keys, ICommand>();
            keyboardMap.Add(Keys.Z, new UpCommand(mario));
            keyboardMap.Add(Keys.Down, new DownCommand(mario));
            keyboardMap.Add(Keys.Left, new LeftCommand(mario));
            keyboardMap.Add(Keys.Right, new RightCommand(mario));
            keyboardMap.Add(Keys.Y, new BeNormalMarioCommand(mario));
            keyboardMap.Add(Keys.U, new BeSuperMarioCommand(mario));
            keyboardMap.Add(Keys.I, new BeFireMarioCommand(mario));
            keyboardMap.Add(Keys.O, new DeadCommand(mario));
            keyboardMap.Add(Keys.P, new BeStarMarioCommand(mario));
            keyboardMap.Add(Keys.Q, new QuitCommand(Game1.Instance));
            keyboardMap.Add(Keys.X, new ThrowFireballCommand(mario));
            keyboardMap.Add(Keys.None, new NoInputCommand(mario));
        }
        public void Update()
        {
            Keys[] getkeys = Keyboard.GetState().GetPressedKeys();
            // needs to update to check no input of just cardinal direction keys for movement input
            if (getkeys.Length == 0)
            {
                keyboardMap[Keys.None].Execute();
                previous = Keys.None;
            }
            foreach (Keys key in getkeys)
            {
                if (keyboardMap.ContainsKey(key)&&!(previous.Equals(Keys.Z)&&key.Equals(Keys.Z)))
                {
                  keyboardMap[key].Execute();
                }
                previous = key;
            }
        }
    }

}