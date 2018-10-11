using Game1;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision
{
    public class BlockHandler : IBlockCollisionHandler
    {
        private IMario mario;
        private int locationOffset;
        public BlockHandler(IMario mario)
        {
            this.mario = mario;
            locationOffset = 9999;
    }
        public void HandleCollision(IBlock block, Direction result)
        {
           
            if ((block.IsQuestionBlock()||(block.IsHiddenBlock() && !mario.Isfalling()))
                &&result.Equals(Direction.Down))
            {
                block.React();
            }
            else if(block.IsBreakableBlock() && !mario.IsNormalMario() 
                && result.Equals(Direction.Down))
            {
                block.React();
                block.Getposition().Y += locationOffset;
            }

        }

		public void HandleCollision(IGameObject source, IGameObject target, Direction direction, Rectangle intersection)
		{
			HandleCollision((IBlock)source, direction);
		}
	}
}
