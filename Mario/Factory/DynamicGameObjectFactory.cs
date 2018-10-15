using Game1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Factory
{
	public abstract class DynamicGameObjectFactory:GameObjectFactory
	{
		private Dictionary<string, Dictionary<string, ISprite>> spriteDictionary = new Dictionary<string, Dictionary<string, ISprite>>();
		protected Dictionary<string, Dictionary<string, ISprite>> SpriteDictionary { get => spriteDictionary; set => spriteDictionary = value; }
		public Dictionary<string, Dictionary<string, ISprite>> GetSpriteDictionary { get => SpriteDictionary; }

		public DynamicGameObjectFactory() : base()
		{

		}
	}
}
