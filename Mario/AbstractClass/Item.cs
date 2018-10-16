using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Classes.BlocksClasses
{
    public abstract class Item : IItem ,ICollidiable
    {
        protected ISprite ItemSprite { get; set; }
        private Vector2 ItemLocation;
        public ItemType Type { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)ItemLocation.X, (int)ItemLocation.Y, ItemSprite.Width, ItemSprite.Height);
            }
        }

        public float XVelocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float YVelocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float XVelocityMax { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float YVelocityMax { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected Item(Vector2 location)
        {
            ItemLocation = location;
        }
        public virtual void Update()
        {
            ItemSprite.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ItemSprite.Draw(spriteBatch, ItemLocation);
        }

        public virtual ref Vector2 Getposition()
        {
            return ref ItemLocation;
        }
    }
}
