using Game1;
using Mario.BlocksCommand;
using Mario.MarioCommand;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mario
{
    public class GamePadController : IController
    {
        private Game1 game { get; set; }
        private IMario mario;
        private IList<ICommand> commandList;
        private int delay;
        public GamePadController(Game1 game)
        {
            this.game = game;
            mario = ItemManager.Instance.Mario;
            commandList = new List<ICommand>();
            delay = 0;
        }
        public void Update()
        {
            delay++;
            if (delay == 5)
            {
                GamePadState currentState = GamePad.GetState(PlayerIndex.One);
                if (currentState.Buttons.Start.Equals(ButtonState.Pressed))
                {
                    commandList.Add(new QuitCommand(game));
                }
                if (currentState.ThumbSticks.Left.X > 0)
                {
                    commandList.Add(new LeftCommand(mario));
                }
                if (currentState.Buttons.A > 0)
                {
                    commandList.Add(new UpCommand(mario));
                }
                if (currentState.ThumbSticks.Left.Y < 0)
                {
                    commandList.Add(new DownCommand(mario));
                }
                if (currentState.ThumbSticks.Left.X > 0)
                {
                    commandList.Add(new RightCommand(mario));
                }
                if (currentState.Buttons.B > 0)
                {
                    commandList.Add(new ThrowFireballCommand(mario));
                }
               
                foreach (ICommand command in commandList)
                {
                    command.Execute();
                }

                delay = 0;
            }
			

        }

		public void Initialize(IMario mario) { 
		
			commandList.Add(new QuitCommand(game));
			commandList.Add(new LeftCommand(mario));
			commandList.Add(new UpCommand(mario));
			commandList.Add(new DownCommand(mario));
			commandList.Add(new RightCommand(mario));
			
		}
	}
}
