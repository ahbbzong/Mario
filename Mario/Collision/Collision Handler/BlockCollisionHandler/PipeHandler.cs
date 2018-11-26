﻿using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;

namespace Mario.Collision
{
	public class PipeHandler : IBlockCollisionHandler
    {
        int index;
        public PipeHandler(int index)
        {
            this.index = index;
        }
        public void HandleCollision(IBlock block, IMario mario,Direction result)
        {
            if (result == Direction.Up&&mario.IsCrouch&&index==CollisionUtil.groundPipeIndex)
            {
               
                mario.Position += Vector2.UnitX * CollisionUtil.undergroundOffset;
            }
            if(result == Direction.Up && mario.IsCrouch&& index == CollisionUtil.undergroundPipeIndex)
            {
                mario.Position -= new Vector2(CollisionUtil.marioOffesetX, CollisionUtil.marioOffsetY);
            }

        }

       
        
    }
}
