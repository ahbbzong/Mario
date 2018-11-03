using Mario.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Factory
{
	public abstract class StaticGameObjectFactory: IContentBehavior
	{
		private IDictionary<string, Tuple<Texture2D,int,int>> gameObjectSprites = new Dictionary<string, Tuple<Texture2D,int,int>>();
		protected IDictionary<string, Tuple<Texture2D,int,int>> GameObjectSprites { get => gameObjectSprites; set => gameObjectSprites = value; }

		public IDictionary<string, Tuple<Texture2D,int,int>> GetGameObjectSprites { get => GameObjectSprites; }
		protected StaticGameObjectFactory()
		{

		}

		public abstract void LoadContent(ContentManager content);
	}
}
