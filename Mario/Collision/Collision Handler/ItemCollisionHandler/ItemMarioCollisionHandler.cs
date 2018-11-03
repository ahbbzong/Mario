using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
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
        public ItemMarioCollisionHandler()
        {
        }
        public void HandleCollision(IItem item)
        {
            GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Remove(item);
        }
    }
}
