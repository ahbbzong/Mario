﻿using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Mario.ItemClasses;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class BreakableBlockState : BlockState
    {
        public BreakableBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
        public override void React()
        {
          
                Block.Position -= Vector2.UnitY*10.0f;

				int index = ItemManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(Block);
				ItemManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = new BumpedBlockDecorator(Block);
            if (!ItemManager.Instance.Mario.IsNormalMario())
            {
                ItemManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleLeft), new Vector2(Block.Position.X, Block.Position.Y)));
                ItemManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleLeft), new Vector2(Block.Position.X, Block.Position.Y + 16)));

                ItemManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleRight), new Vector2(Block.Position.X + 16, Block.Position.Y)));
                ItemManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleRight), new Vector2(Block.Position.X + 16, Block.Position.Y + 16)));
               

            }
        }
        public override bool IsBreakableBlock()
        {
            return true;
        }

    }
}
