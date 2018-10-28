using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Mario.Interfaces.GameObjects;

namespace Mario.Factory
{
	public interface IGameObjectFactory
	{
		IGameObject GetGameObject(Type typeName, Vector2 position);
		Func<Vector2, IGameObject> GetInstantiatorByTypeName(Type typeName);

	}
}
