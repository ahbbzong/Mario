using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Factory
{
	public abstract class SimpleGameObjectFactory : GameObjectFactory
	{
		private Dictionary<string, Tuple<Texture2D,int,int>> spriteDictionary = new Dictionary<string, Tuple<Texture2D,int,int>>();
		protected Dictionary<string, Tuple<Texture2D,int,int>> SpriteDictionary { get => spriteDictionary; set => spriteDictionary = value; }
		public Dictionary<string,Tuple<Texture2D,int,int>> GetSpriteDictionary { get => SpriteDictionary; }
		protected SimpleGameObjectFactory():base()
		{
		}
		
	}
}
