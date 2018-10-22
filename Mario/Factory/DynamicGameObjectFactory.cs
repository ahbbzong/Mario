﻿using Game1;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Factory
{
	public abstract class DynamicGameObjectFactory:GameObjectFactory
	{
		private Dictionary<string, Dictionary<string,Tuple<Texture2D,int,int>>> spriteDictionary = new Dictionary<string, Dictionary<string,Tuple<Texture2D,int,int>>>();
		protected Dictionary<string, Dictionary<string, Tuple<Texture2D,int,int>>> SpriteDictionary { get => spriteDictionary; set => spriteDictionary = value; }
		public Dictionary<string, Dictionary<string, Tuple<Texture2D,int,int>>> GetSpriteDictionary { get => SpriteDictionary; }

		public DynamicGameObjectFactory() : base()
		{

		}
	}
}
