using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Mario.Factory
{
	class MarioFactory:GameObjectFactory
	{
		private static MarioFactory instance = new MarioFactory();
		public static MarioFactory Instance { get => instance; set => instance = value; }
		public MarioFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Microsoft.Xna.Framework.Vector2, Interfaces.GameObjects.IGameObject>>
			{
				{"Mario", GetMario }
			};
		}

		private IGameObject GetMario(Vector2 arg)
		{
			return new Mario(arg);
		}
	}
}
