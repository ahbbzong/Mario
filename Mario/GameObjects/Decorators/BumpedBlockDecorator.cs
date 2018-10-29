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
                if(DecoratedBlock.IsQuestionBlock())
				DecoratedBlock.BlockState = new UsedBlockState(DecoratedBlock);
                RemoveSelf();
			}
			base.Update();
		}

		private void RemoveSelf()
		{
			//should append ItemManager to remove and add items generally
			int index = ItemManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(this);
			ItemManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = DecoratedBlock;
		}
        
    }
}
