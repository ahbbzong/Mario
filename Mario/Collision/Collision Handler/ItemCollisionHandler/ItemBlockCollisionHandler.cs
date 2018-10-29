﻿using Game1;
using Mario.BlocksClasses;
using Mario.Enums;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.ItemCollisionHandler
{
    class ItemBlockCollisionHandler : IItemCollisionHandler
    {
        Rectangle intersection;
        IBlock block;
        Direction result;
        public  ItemBlockCollisionHandler(IBlock block, Rectangle intersection, Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IItem item)
        {
            if (!(item is Coin)&&!(item is BrickParticleLeft)&&!(item is BrickParticleRight))
            switch (result)
            {
                case Direction.Up:
                    item.Position -= Vector2.UnitY* intersection.Height;
                    item.IsLandTrue();
                    break;
                case Direction.Down:
                    item.Position += Vector2.UnitY* intersection.Height;
                    break;
                case Direction.Left:
                    item.Position -= Vector2.UnitX*intersection.Width;
                        ItemTurnLeft(item);
                    break;
                case Direction.Right:
                    item.Position += Vector2.UnitX*intersection.Width;
                        ItemTurnRight(item);
                    break;
                case Direction.None:
                    item.IsLandFalse();
                    break;
            }
        }
        public void ItemTurnLeft(IItem item)
        {
            if(block is Pipe||block is UnbreakableBlock)
            {
                item.TurnLeft();
            }
        }
        public void ItemTurnRight(IItem item)
        {
            if (block is Pipe|| block is UnbreakableBlock)
            {
                item.TurnRight();
            }
        }
    }
}
