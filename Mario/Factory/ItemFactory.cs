﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Mario.Factory;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Mario.Enums;

namespace Mario.Factory
{
	class ItemFactory:GameObjectFactory
	{
		private static ItemFactory instance = new ItemFactory();
		public static ItemFactory Instance { get => instance; }

		private Dictionary<string, Texture2D> spriteDictionary;
		private ItemFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>
			{
				{"Coin",GetCoin },
				{"FireFlower",GetFireFlower },
				{"MagicMushroom",GetMagicMushroom },
				{"OneUpMushroom",GetOneUpMushroom },
				{"Starman", GetStarman }
			};
		}

		private IGameObject GetStarman(Vector2 arg)
		{
			return new Starman(arg);
		}

		private IGameObject GetOneUpMushroom(Vector2 arg)
		{
			return new OneUpMushroom(arg);
		}

		private IGameObject GetMagicMushroom(Vector2 arg)
		{
			return new MagicMushroom(arg);
		}

		private IGameObject GetFireFlower(Vector2 arg)
		{
			return new FireFlower(arg);
		}

		private IGameObject GetCoin(Vector2 arg)
		{
			return new Coin(arg);
		}

		public override void LoadContent(ContentManager content)
		{
			spriteDictionary = new Dictionary<string, Texture2D>
			{
				{ItemType.Coin.ToString(), content.Load<Texture2D>("Coin") },
				{ItemType.FireFlower.ToString(), content.Load<Texture2D>("FireFlower") },
				{ItemType.MagicMushroom.ToString(), content.Load<Texture2D>("MagicMushroom") },
				{ItemType.OneUpMushroom.ToString(), content.Load<Texture2D>("OneUpMushroom") },
				{ItemType.Starman.ToString(), content.Load<Texture2D>("Starman") }
			};
		}
	}
}
