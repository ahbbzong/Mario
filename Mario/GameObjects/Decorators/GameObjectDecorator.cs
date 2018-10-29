using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	abstract class GameObjectDecorator : IGameObject
	{
        private IGameObject decoratedObject; protected IGameObject DecoratedObject { get => decoratedObject; set => decoratedObject = value; }

		protected GameObjectDecorator(IGameObject obj)
		{
			decoratedObject = obj;
		}
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			decoratedObject.Draw(spriteBatch);
		} 

		public virtual void Update()
		{
			decoratedObject.Update();
		}

        public virtual void SetContainsItem(String item)
        { }
    }
}
