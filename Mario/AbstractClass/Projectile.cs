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
    public abstract class Projectile : IProjectile, ICollidiable
    {
        protected ISprite ProjectileSprite { get; set; }
        private Vector2 ProjectileLocation;
        public ProjectileType Type { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)ProjectileLocation.X, (int)ProjectileLocation.Y, ProjectileSprite.Width, ProjectileSprite.Height);
            }
        }

        public float XVelocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float YVelocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float XVelocityMax { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float YVelocityMax { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected Projectile(Vector2 location)
        {
            ProjectileLocation = location;
        }
        public virtual void Update()
        {
            ProjectileSprite.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ProjectileSprite.Draw(spriteBatch, ProjectileLocation);
        }

        public virtual ref Vector2 Getposition()
        {
            return ref ProjectileLocation;
        }
    }
}
