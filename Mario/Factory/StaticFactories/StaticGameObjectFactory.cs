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
		//Children of this class choose selectively whether to allow setting. But it is required that colllection be not read only
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		protected IDictionary<string, Tuple<Texture2D,int,int>> GameObjectSprites { get => gameObjectSprites; set => gameObjectSprites = value; }

		protected StaticGameObjectFactory()
		{

		}

		public abstract void LoadContent(ContentManager content);
	}
}
