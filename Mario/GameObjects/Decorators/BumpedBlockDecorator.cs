using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.Factory;
using Mario.MarioStates.MarioPowerupStates;
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
                if ((!(GameObjectManager.Instance.Mario.MarioPowerupState is NormalMarioPowerupState)) && DecoratedBlock.BlockState is BrickBlockState)
                {
                    DecoratedBlock.BlockState = new DisappearBlockState(DecoratedBlock);
                }

                else if (!DecoratedBlock.ItemContains.Equals("None")||DecoratedBlock.BlockState is QuestionBlockState)
                {
                    DecoratedBlock.BlockState = new UsedBlockState(DecoratedBlock);
                    GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].Add(BlockFactory.Instance.GetGameObject(typeof(UsedBlock), new Vector2(DecoratedBlock.Position.X, DecoratedBlock.Position.Y)));
                    
                }

         
                RemoveSelf();
			}
			base.Update();
		}

		private void RemoveSelf()
		{
			int index = GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(this);
			GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = DecoratedBlock;
		}
        
    }
}
