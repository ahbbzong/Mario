using Game1;
using Mario.BlocksCommand;
using Mario.MarioCommand;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mario
{
    public class GamePadController : IController
    {
        private Game1 myMario { get; set; }
        private IList<ICommand> commandList;
        private int delay;
        public GamePadController(Game1 mario)
        {
            myMario = mario;
            commandList = new List<ICommand>();
            delay = 0;
        }
        public void Update()
        {
           /* delay++;
            if (delay == 5)
            {
                GamePadState currentState = GamePad.GetState(PlayerIndex.One);
                if (currentState.Buttons.Start.Equals(ButtonState.Pressed))
                {
                    commandList.Add(new QuitCommand(myMario));
                }
                if (currentState.ThumbSticks.Left.X > 0)
                {
                    commandList.Add(new LeftCommand(myMario));
                }
                if (currentState.ThumbSticks.Left.Y > 0)
                {
                    commandList.Add(new UpCommand(myMario));
                }
                if (currentState.ThumbSticks.Left.Y < 0)
                {
                    commandList.Add(new DownCommand(myMario));
                }
                if (currentState.ThumbSticks.Left.X > 0)
                {
                    commandList.Add(new RightCommand(myMario));
                }
                foreach (ICommand command in commandList)
                {
                    command.Execute();
                }
                delay = 0;
            }
			*/

        }

		public void Initialize(IMario mario) { 
		
			commandList.Add(new QuitCommand(myMario));
			commandList.Add(new LeftCommand(mario));
			commandList.Add(new UpCommand(mario));
			commandList.Add(new DownCommand(mario));
			commandList.Add(new RightCommand(mario));
			
		}
	}
}
