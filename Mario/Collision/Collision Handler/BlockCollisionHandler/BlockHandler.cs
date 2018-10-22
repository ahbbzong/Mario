using Game1;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Mario.XMLRead;
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
        public void HandleCollision(IBlock block, IMario mario, Direction result)
        {

            if ((block.IsQuestionBlock() || (block.IsHiddenBlock() && !mario.Isfalling()))
                && result.Equals(Direction.Down))
            {
                //should be put into react if it work

                block.React();

                if (mario.IsNormalMario())
                {
                    ItemManager.Instance.AddNormalItem(block);
                }
                else if (mario.IsSuperMario())
                {
                    ItemManager.Instance.AddBigItem(block);
                }
            }
            else if (block.IsBreakableBlock() && result.Equals(Direction.Down))
            {
                block.React();
                //block.Getposition().Y += locationOffset;
            }
            BlockMovement(block, result);
        }

		public void HandleCollision(IGameObject source, IGameObject target, Direction direction, Rectangle intersection)
		{
			HandleCollision((IBlock)source,(IMario)target, direction);

        }
        public void BlockMovement(IBlock block, Direction result)
        {
            if(block.IsBreakableBlock() && result.Equals(Direction.Down))
            {
                
            }
        }
	}
}
