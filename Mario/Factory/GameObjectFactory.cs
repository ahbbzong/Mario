using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Mario.Factory
{
	abstract class GameObjectFactory : IGameObjectFactory
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
	}
}
