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
        private Vector2 maxVelocity = new Vector2(8.0f, 8.0f);
        public Vector2 MaxVelocity { get => maxVelocity; }
        private Vector2 velocity = Vector2.Zero;
        public Vector2 Velocity { get => velocity; set => velocity = value; }

        public GravityManagement gravityManagement { get; set; }
        public bool IsLand { get ; set ; }
		public Vector2 Position { get => ItemLocation; set => ItemLocation = value; }

		protected Item(Vector2 location)
        {
            ItemLocation = location;
            IsLand = false;
            gravityManagement = new GravityManagement(this);
            velocity = Vector2.UnitX;

        }
        public virtual void Update()
        {
            ItemSprite.Update();
            if (!IsLand){
                gravityManagement.Update();
            }
            Move();
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ItemSprite.Draw(spriteBatch, ItemLocation);
        }
        public virtual void IsLandTrue()
        {

            gravityManagement.ResetGravity();
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

        public virtual void TurnLeft()
        {
            velocity = -Vector2.UnitX;
        }

        public virtual void TurnRight()
        {
            velocity = Vector2.UnitX;
        }
        public virtual void Move()
        {
            ItemLocation += velocity;
        }

        public virtual bool IsCoin()
        {
            return false;
        }
    }
}
