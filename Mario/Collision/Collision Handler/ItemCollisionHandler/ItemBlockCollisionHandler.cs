using Game1;
using Mario.Enums;
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
            switch (result)
            {
                case Direction.Up:
                    item.Position -= Vector2.UnitY* intersection.Height;
                    item.Getposition().Y -= intersection.Height;
                    item.IsLandTrue();
                    break;
                case Direction.Down:
                    item.Position += Vector2.UnitY* intersection.Height;
                    break;
                case Direction.Left:
                    item.Position -= Vector2.UnitX*intersection.Width;
                    break;
                case Direction.Right:
                    item.Position += Vector2.UnitX*intersection.Width;
                    break;
                case Direction.None:
                    item.IsLandFalse();
                    break;
            }
        }
    }
}
