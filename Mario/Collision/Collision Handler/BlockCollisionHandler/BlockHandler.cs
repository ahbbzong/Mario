﻿using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using System;

namespace Mario.Collision
{
	public class BlockHandler : IBlockCollisionHandler
    {
        public BlockHandler()
        {
        }
        public void HandleCollision(IBlock block, IMario mario,Direction result)
        {
            bool isDown = result == Direction.Down;
            bool isHidden = block.BlockState is HiddenBlockState;
            bool isHiddenTouched = isHidden && !mario.Fall;
            bool isReactable = block.BlockState is QuestionBlockState || block.BlockState is BrickBlockState || isHiddenTouched;
            if (!isDown || !isReactable) return;
            block.React();
            if (isHidden) return;
            if (mario.MarioPowerupState is NormalMarioPowerupState)
                AddNormalItem(block);
            else if (!(mario.MarioPowerupState is DeadMarioPowerupState) || mario.IsStarMario())
                AddBigItem(block);
        }

        public void HandleCollision(IGameObject source, IGameObject target, Direction direction)
        {
            HandleCollision((IBlock)source, (IMario)target, direction);
        }
        private void AddNormalItem(IBlock block)
        {
            Type IItemType = typeof(IItem);
            switch (block.ItemContained)
            {
                case ItemString.Coin:
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Coin), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case ItemString.Starman:
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Starman), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case ItemString.OneUpMushroom:
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(OneUpMushroom), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case ItemString.None:
                    if (block.BlockState is HiddenBlockState || block.BlockState is QuestionBlockState)
                        GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(MagicMushroom), new Vector2(block.Position.X, block.Position.Y)));
                    break;
            }
        }
        private void AddBigItem(IBlock block)
        {
            Type IItemType = typeof(IItem);
            switch (block.ItemContained)
            {
                case ItemString.Coin:
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Coin), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case ItemString.None:
                    if (block.BlockState is HiddenBlockState || block.BlockState is QuestionBlockState)
                        GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(FireFlower), new Vector2(block.Position.X, block.Position.Y-3)));
                    break;
                case ItemString.Starman:
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(Starman), new Vector2(block.Position.X, block.Position.Y)));
                    break;
                case ItemString.OneUpMushroom:
                    GameObjectManager.Instance.GameObjectListsByType[IItemType].Add(ItemFactory.Instance.GetGameObject(typeof(OneUpMushroom), new Vector2(block.Position.X, block.Position.Y)));
                    break;
            }
        }
    }
}
