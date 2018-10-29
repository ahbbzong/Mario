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
    public abstract class Background : IBackground
    {
        protected ISprite BackgroundSprite { get; set; }
        private Vector2 BackgroundLocation;
        public Rectangle Box { get; }

    
        protected Background(Vector2 location)
        {
            BackgroundLocation = location;
			BackgroundSprite = SpriteFactory.Instance.CreateSprite(BackgroundFactory.Instance.GetSpriteDictionary[this.GetType()]);
            Box = Rectangle.Empty;
		}
        public virtual void Update()
        {
            BackgroundSprite.Update();
        }
        public virtual void SetContainsItem(String item)
        { }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            BackgroundSprite.Draw(spriteBatch, BackgroundLocation);
        }
    }
}
