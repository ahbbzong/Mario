using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
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
        public Dictionary<string, IList<IGameObject>> gameObjectListsByType;
        public IMario Mario { get { return (IMario)gameObjectListsByType["Mario"][0]; } }
        public ProjectileType Type { get; set; }
        public float XVelocity { get; set; }
        public Physics physics { get; set; }
        public ProjectileState ProjectileState { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)ProjectileLocation.X, (int)ProjectileLocation.Y, ProjectileSprite.Width, ProjectileSprite.Height);
            }
        }

       
        public bool IsLand { get; set; }

        protected Projectile(Vector2 location)
        {
            ProjectileLocation = location;
            IsLand = false;
        }
        public virtual void Update()
        {
            ProjectileSprite.Update();
            if (!IsLand) { physics.Update(); }
            physics.FireballMove(XVelocity);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ProjectileSprite.Draw(spriteBatch, ProjectileLocation);
        }

        public virtual ref Vector2 Getposition()
        {
            return ref ProjectileLocation;
        }
        public virtual void IsLandTrue()
        {
            physics.ReverseYVelocity();
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
    }
}
