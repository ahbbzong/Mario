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
        public BlockHandler(IMario mario)
        {
            this.mario = mario;
    }
        public void HandleCollision(IBlock block, IMario mario, Direction result)
        {

            if ((block.IsQuestionBlock() || (block.IsHiddenBlock() && !mario.Isfalling()))
                && result.Equals(Direction.Down))
            {
                block.React();
                


                if (mario.IsNormalMario())
                {
                    ItemManager.Instance.AddNormalItem(block);
                }
                else if (mario.IsSuperMario()||mario.IsFireMario()||mario.IsStarMario())
                {
                    ItemManager.Instance.AddBigItem(block);
                }
            }
            else if (block.IsBreakableBlock() && result.Equals(Direction.Down))
            {
                block.React();
            }
        }

        public void HandleCollision(IGameObject source, IGameObject target, Direction direction, Rectangle intersection)
        {
            HandleCollision((IBlock)source, (IMario)target, direction);
        }
	}
}
