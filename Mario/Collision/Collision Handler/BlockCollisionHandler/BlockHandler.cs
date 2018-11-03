using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Mario.MarioStates.MarioPowerupStates;
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
			//need to remove breakable block class
            if ((block.BlockState is QuestionBlockState ||block.BlockState is BrickBlockState)&& result == Direction.Down)
			
            {
                block.React();
                if (mario.MarioPowerupState is NormalMarioPowerupState)
                {
                    AddNormalItem(block);
                }
                else if (mario.MarioPowerupState is SuperMarioPowerupState || mario.MarioPowerupState is FireMarioPowerupState || mario.IsStarMario() )
                {
                    AddBigItem(block);
                }
            }
            else if (block.BlockState is HiddenBlockState && result==Direction.Down&&!mario.Isfalling())
            {
                block.React();
            }
        }

        public void HandleCollision(IGameObject source, IGameObject target, Direction direction)
        {
            HandleCollision((IBlock)source, (IMario)target, direction);
        }
        public void AddNormalItem(IBlock block)
        {
            Type IItemType = typeof(IItem);
            switch (block.ItemContains)
            {
                case "Coin":
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Coin), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case "Starman":
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Starman), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case "OneUpMushroom":
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(OneUpMushroom), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case "None":
                    if (block.BlockState is HiddenBlockState || block.BlockState is QuestionBlockState)
                    {
                        GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(MagicMushroom), new Vector2(block.Position.X, block.Position.Y)));
                    }
                    break;
            }
        }
        public void AddBigItem(IBlock block)
        {
            Type IItemType = typeof(IItem);
            switch (block.ItemContains)
            {
                case "Coin":
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Coin), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case "None":
                    if (block.BlockState is HiddenBlockState || block.BlockState is QuestionBlockState)
                    {
                        GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(FireFlower), new Vector2(block.Position.X, block.Position.Y-3)));
                    }
                    break;
                case "Starman":
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Starman), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case "OneUpMushroom":
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(OneUpMushroom), new Vector2(block.Position.X, block.Position.Y)));
                    break;
            }
        }
    }
}
