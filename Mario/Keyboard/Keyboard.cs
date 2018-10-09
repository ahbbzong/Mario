using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Mario.MarioCommand;
using Mario.BlocksCommand;
using Game1;

namespace Mario
{
    public class Keyboards : IController
    {
        private Dictionary<Keys, ICommand> keyboardMap;
        public Keyboards(Game1 mario)
        {
            keyboardMap = new Dictionary<Keys, ICommand>();
            keyboardMap.Add(Keys.Up,  new UpCommand(mario));
            keyboardMap.Add(Keys.Down, new DownCommand(mario));
            keyboardMap.Add(Keys.Left, new LeftCommand(mario));
            keyboardMap.Add(Keys.Right, new RightCommand(mario));
            keyboardMap.Add(Keys.W,  new UpCommand(mario));
            keyboardMap.Add(Keys.S,   new DownCommand(mario));
            keyboardMap.Add(Keys.A,   new LeftCommand(mario));
            keyboardMap.Add(Keys.D,   new RightCommand(mario));
            keyboardMap.Add(Keys.Y,   new BeNormalMarioCommand(mario));
            keyboardMap.Add(Keys.U,   new BeSuperMarioCommand(mario));
            keyboardMap.Add(Keys.I,   new BeFireMarioCommand(mario));
            keyboardMap.Add(Keys.O,   new DeadCommand(mario));
            keyboardMap.Add(Keys.P,   new BeStarMarioCommand(mario));
            keyboardMap.Add(Keys.Q,   new QuitCommand(mario));
        }
        public void Update()
        {
            
            {
                Keys[] getkeys = Keyboard.GetState().GetPressedKeys();
                foreach (Keys key in getkeys)
                {

                    if (keyboardMap.ContainsKey(key))
                        keyboardMap[key].Update();


                }
            }
        }
    }
}
