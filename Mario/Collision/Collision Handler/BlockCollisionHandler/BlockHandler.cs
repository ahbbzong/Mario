﻿using Game1;
using Mario.BlocksClasses;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
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
            if ((block is QuestionBlock ||block is BreakableBlock)&& result == Direction.Down)
            {
                block.React();
                if (mario.MarioPowerupState is NormalMarioPowerupState)
                {
                    GameObjectManager.Instance.AddNormalItem(block);
                }
                else if (mario.MarioPowerupState is SuperMarioPowerupState || mario.MarioPowerupState is FireMarioPowerupState || mario.IsStarMario() )
                {
                    GameObjectManager.Instance.AddBigItem(block);
                }
            }
            else if (block is HiddenBlock && result==Direction.Down&&!mario.Isfalling())
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
