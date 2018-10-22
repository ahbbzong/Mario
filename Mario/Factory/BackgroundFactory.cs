using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Mario.Enums;
using Mario.Classes.BackgroundClasses;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game1;

namespace Mario.Factory
{
	class BackgroundFactory : SimpleGameObjectFactory
	{
		private static BackgroundFactory instance = new BackgroundFactory();
		public static BackgroundFactory Instance { get => instance; set => instance = value; }
		
		public BackgroundFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>{
				{ BackgroundType.BushSingle.ToString(), GetBushSingle },
				{ BackgroundType.BushTriple.ToString(), GetBushTriple},
				{ BackgroundType.CloudSingle.ToString(), GetCloudSingle},
				{ BackgroundType.CloudTriple.ToString(), GetCloudTriple},
				{ BackgroundType.MountainBig.ToString(), GetMounntainBig },
				{ BackgroundType.MountainSmall.ToString(), GetMountainSmall }
			};
		}

		private IGameObject GetMountainSmall(Vector2 arg)
		{
			return new MountainSmall(arg);
		}

		private IGameObject GetMounntainBig(Vector2 arg)
		{
			return new MountainBig(arg);
		}

		private IGameObject GetCloudTriple(Vector2 arg)
		{
			return new CloudTriple(arg);
		}

		private IGameObject GetCloudSingle(Vector2 arg)
		{
			return new CloudSingle(arg);
		}

		private IGameObject GetBushTriple(Vector2 arg)
		{
			return new BushTriple(arg);
		}

		private IGameObject GetBushSingle(Vector2 arg)
		{
			return new BushSingle(arg);
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<string, ISprite>
			{
				{BackgroundType.BushSingle.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("singleBush")) },
				{BackgroundType.BushTriple.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("tripleBush")) },
				{BackgroundType.CloudSingle.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("singleCloud")) },
				{BackgroundType.CloudTriple.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("tripleCloud")) },
				{BackgroundType.MountainBig.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("bigMountain")) },
				{BackgroundType.MountainSmall.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("smallMountain")) }
			};
		}
	}
}
