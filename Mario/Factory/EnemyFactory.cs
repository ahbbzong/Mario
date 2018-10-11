using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.EnemyClasses;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Mario.Enums;
namespace Mario.Factory
{
	class EnemyFactory : GameObjectFactory
	{
		private static EnemyFactory instance = new EnemyFactory();
		public static EnemyFactory Instance { get => instance; }

		private EnemyFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>
			{
				{EnemyType.Goomba.ToString(), GetGoomba },
				{EnemyType.Koopa.ToString(),GetKoopa }
			};
		}
		private IGameObject GetGoomba(Vector2 position)
		{
			return new Goomba(position);
		}

		private IGameObject GetKoopa(Vector2 position)
		{
			return new Koopa(position);
		}
	}
}
