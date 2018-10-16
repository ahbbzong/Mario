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
                {"Fireball",GetFireball }
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
        private IGameObject GetFireball(Vector2 arg)
        {
            return new Fireball(arg);
        }

        public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<string, ISprite>
			{
				{ItemType.Coin.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("Coin"),1,4) },
				{ItemType.FireFlower.ToString(),SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("FireFlower"),1,4) },
				{ItemType.MagicMushroom.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("MagicMushroom")) },
				{ItemType.OneUpMushroom.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("OneUpMushroom")) },
				{ItemType.Starman.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("Starman"),1,4) },
                {ItemType.Fireball.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("Fireball"),1,4) }
            };
		}
	}
}
