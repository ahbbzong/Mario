using Game1;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.ItemCollisionHandler
{
    public class ItemMarioCollisionHandler : IItemCollisionHandler
    {
        private int locationOffset;
        public ItemMarioCollisionHandler()
        {
            locationOffset = 9999;
        }
        public void HandleCollision(IItem item)
        {
            item.Getposition().Y += locationOffset;
            
        }
    }
}
