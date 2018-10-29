using Game1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	class BlockDecorator:GameObjectDecorator, IBlock
	{
		public BlockDecorator(IBlock decoratedBlock):base(decoratedBlock)
		{
			DecoratedBlock = decoratedBlock;
		}

		public IBlock DecoratedBlock { get => (IBlock)DecoratedObject; set => DecoratedObject = value; }

		public Rectangle Box => DecoratedBlock.Box;
        public Vector2 Position { get => DecoratedBlock.Position; set => DecoratedBlock.Position = value; }
		public IBlockState BlockState { get => DecoratedBlock.BlockState; set => DecoratedBlock.BlockState = value; }
        public string ItemContains { get => DecoratedBlock.ItemContains; set => DecoratedBlock.ItemContains = value; }

        public bool IsBreakableBlock()
		{
			return DecoratedBlock.IsBreakableBlock();
		}

		public bool IsBumpedBlockState()
		{
			return DecoratedBlock.IsBumpedBlockState();
		}

		public bool IsBumpedBreakBlock()
		{
			return DecoratedBlock.IsBumpedBreakBlock();
		}

		public bool IsHiddenBlock()
		{
			return DecoratedBlock.IsHiddenBlock();
		}

		public bool IsQuestionBlock()
		{
			return DecoratedBlock.IsQuestionBlock();
		}
        public override void SetContainsItem(String item)
        { }
        public void React()
		{
			DecoratedBlock.React();
		}
	}
}
