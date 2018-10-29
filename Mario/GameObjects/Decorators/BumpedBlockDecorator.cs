using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.BlockStates;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.GameObjects.Decorators
{
	class BumpedBlockDecorator : BlockDecorator
	{
		private int movedY = 10;
		public BumpedBlockDecorator(IBlock decoratedBlock) : base(decoratedBlock)
		{
			
		}
		public override void Update()
		{
			if (movedY != 0)
			{
				DecoratedBlock.Position += Vector2.UnitY;
				movedY--;
			}
			else
			{
                if (!DecoratedBlock.ItemContains.Equals("None")||DecoratedBlock.IsQuestionBlock())
                {
                    DecoratedBlock.BlockState = new UsedBlockState(DecoratedBlock);
                }

                if (!GameObjectManager.Instance.Mario.IsNormalMario()&&DecoratedBlock.IsBreakableBlock())
                {
                    DecoratedBlock.BlockState = new DisappearBlockState(DecoratedBlock);
                }
                RemoveSelf();
			}
			base.Update();
		}

		private void RemoveSelf()
		{
			//should append ItemManager to remove and add items generally
			int index = GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(this);
			GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = DecoratedBlock;
		}
        
    }
}
