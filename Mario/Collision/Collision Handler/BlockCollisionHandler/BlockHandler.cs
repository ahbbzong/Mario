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
        public BlockHandler()
        {
    }
        public void HandleCollision(IBlock block, IMario mario,Direction result)
        {
            if ((block.IsQuestionBlock() ||block.IsBreakableBlock())&& result.Equals(Direction.Down))
            {
                block.React();
                if (mario.IsNormalMario())
                {
                    GameObjectManager.Instance.AddNormalItem(block);
                }
                else if (mario.IsSuperMario()|| mario.IsFireMario()|| mario.IsStarMario())
                {
                    GameObjectManager.Instance.AddBigItem(block);
                }
            }
            else if (block.IsHiddenBlock() && result.Equals(Direction.Down)&&!mario.Isfalling())
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
