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

       
        public Physics Physics { get ; set ; }
        public bool IsLand { get ; set ; }
		public Vector2 Position { get => ItemLocation; set => ItemLocation = value; }

		protected Item(Vector2 location)
        {
            ItemLocation = location;
            IsLand = false;
            Physics = new Physics(this);

        }
        public virtual void Update()
        {
            ItemSprite.Update();
            if (!IsLand){
                Physics.Update();
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ItemSprite.Draw(spriteBatch, ItemLocation);
        }

        public virtual ref Vector2 Getposition()
        {
            return ref ItemLocation;
        }

        public virtual void IsLandTrue()
        {
            if (IsStarman())
            {
                Physics.ReverseYVelocity();
            }
            else
            {
                Physics.ResetGravity();
            }
            IsLand = true;
        }

        public virtual void IsLandFalse()
        {
            IsLand = false;
        }

        public virtual bool IsStarman()
        {
            return false;
        }
    }
}
