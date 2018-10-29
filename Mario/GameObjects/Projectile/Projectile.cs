﻿using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Classes.BlocksClasses
{
    public abstract class Projectile : IProjectile, ICollidiable
    {
        protected ISprite ProjectileSprite { get; set; }
        private Vector2 ProjectileLocation;
        public static IMario Mario { get { return (IMario)ItemManager.Instance.GameObjectListsByType[typeof(IMario)][0]; } }
        public ProjectileType Type { get; set; }
        public float XVelocity { get; set; }
        public GravityManagement gravityManagement { get; set; }
        public ProjectileState ProjectileState { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)ProjectileLocation.X, (int)ProjectileLocation.Y, ProjectileSprite.Width, ProjectileSprite.Height);
            }
        }

       
        public bool IsLand { get; set; }
		public Vector2 Position { get => ProjectileLocation; set => ProjectileLocation = value; }

		protected Projectile(Vector2 location)
        {
            ProjectileLocation = location;
            gravityManagement = new GravityManagement(this);
            IsLand = false;
        }
        public virtual void Update()
        {
            ProjectileSprite.Update();
            if (!IsLand) { gravityManagement.Update(); }
            Position += Vector2.UnitX*XVelocity;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ProjectileSprite.Draw(spriteBatch, ProjectileLocation);
        }
		
		public virtual void IsLandTrue()
        {
            gravityManagement.ReverseYVelocity();
            IsLand = true;
        }
        public virtual void IsLandFalse()
        {
            IsLand = false;
        }

        public virtual void React()
        {
            //Need to override
        }
        public virtual void MovingLeft()
        {

        }

        public virtual void SetContainsItem(String item)
        { }
    }
}
