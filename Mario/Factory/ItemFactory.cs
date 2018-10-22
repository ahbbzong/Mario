using System;
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
using Game1;

namespace Mario.Factory
{
	class ItemFactory:SimpleGameObjectFactory
	{
		private static ItemFactory instance = new ItemFactory();
		public static ItemFactory Instance { get => instance; }
		
		private ItemFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>
			{
				{"Coin",GetCoin },
				{"FireFlower",GetFireFlower },
				{"MagicMushroom",GetMagicMushroom },
				{"OneUpMushroom",GetOneUpMushroom },
				{"Starman", GetStarman },
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
			SpriteDictionary = new Dictionary<string, Tuple<Texture2D, int, int>>
			{
				{ItemType.Coin.ToString(), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("Coin"),1,4) },
				{ItemType.FireFlower.ToString(),new Tuple<Texture2D, int, int>(content.Load<Texture2D>("FireFlower"),1,4)},
				{ItemType.MagicMushroom.ToString(), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("MagicMushroom"),1,1) },
				{ItemType.OneUpMushroom.ToString(),new Tuple<Texture2D, int, int>(content.Load<Texture2D>("OneUpMushroom"),1,1) },
				{ItemType.Starman.ToString(), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("Starman"),1,4) },
            };
		}
	}
}
