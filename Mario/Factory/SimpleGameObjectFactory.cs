using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Microsoft.Xna.Framework.Content;

namespace Mario.Factory
{
	public abstract class SimpleGameObjectFactory : GameObjectFactory
	{
		private Dictionary<string, ISprite> spriteDictionary = new Dictionary<string, ISprite>();
		protected Dictionary<string, ISprite> SpriteDictionary { get => spriteDictionary; set => spriteDictionary = value; }
		public Dictionary<string,ISprite> GetSpriteDictionary { get => SpriteDictionary; }
		protected SimpleGameObjectFactory():base()
		{
		}
		
	}
}
