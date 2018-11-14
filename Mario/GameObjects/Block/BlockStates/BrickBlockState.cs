using Game1;
using Mario.BlocksClasses;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Mario.HeadUpDesign;
using Mario.ItemClasses;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sound;
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
            Block.Position -= Vector2.UnitY * BlockUtil.BlockOffset;

            int index = GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].IndexOf(Block);
            GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)][index] = new BumpedBlockDecorator(Block);

            if (!(GameObjectManager.Instance.Mario.MarioPowerupState is NormalMarioPowerupState))
            {
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleLeft), new Vector2(Block.Position.X, Block.Position.Y)));
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleLeft), new Vector2(Block.Position.X, Block.Position.Y + BlockUtil.brickBlockParticleOffset)));
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleRight), new Vector2(Block.Position.X + BlockUtil.brickBlockParticleOffset, Block.Position.Y)));
                GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Add(ItemFactory.Instance.GetGameObject(typeof(BrickParticleRight), new Vector2(Block.Position.X + BlockUtil.brickBlockParticleOffset, Block.Position.Y + BlockUtil.brickBlockParticleOffset)));
                GameObjectManager.Instance.GameObjectListsByType[typeof(IBlock)].RemoveAt(index);
                ScoringSystem.Instance.AddPointsForBreakingBlock();
                MotionSound.BreakBlock.Play();
            }
            else {
                base.React();
            }

        }
     
    }
}
