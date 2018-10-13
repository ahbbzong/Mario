using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Mario.Factory
{
	abstract class GameObjectFactory : IGameObjectFactory, IContentBehavior
	{
		private Dictionary<string, Func<Vector2, IGameObject>> instantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>();
		protected Dictionary<string,Func<Vector2,IGameObject>> InstantiationLedger { get => instantiationLedger; set => instantiationLedger = value; }
		public IGameObject GetGameObject(string typeName, Vector2 position)
		{
			return GetInstantiatorByTypeName(typeName)(position);
		}

		public Func<Vector2, IGameObject> GetInstantiatorByTypeName(string typeName)
		{
			return instantiationLedger[typeName];
		}

		public abstract void LoadContent(ContentManager content);
	}
}
