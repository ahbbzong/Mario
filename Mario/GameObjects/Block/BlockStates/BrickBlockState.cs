using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Mario.ItemClasses;
using Mario.MarioStates.MarioPowerupStates;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
    class BrickBlockState : BlockState
    {
        public BrickBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
        public override void React()
        {
          
                Block.Position -= Vector2.UnitY*10.0f;
                

				int index = GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(Block);
				GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = new BumpedBlockDecorator(Block);
            if (!(GameObjectManager.Instance.Mario.MarioPowerupState is NormalMarioPowerupState))
            {
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleLeft), new Vector2(Block.Position.X, Block.Position.Y)));
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleLeft), new Vector2(Block.Position.X, Block.Position.Y + 16)));

                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleRight), new Vector2(Block.Position.X + 16, Block.Position.Y)));
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleRight), new Vector2(Block.Position.X + 16, Block.Position.Y + 16)));
               

            }
           

        }
     
    }
}
