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
		public static BackgroundFactory Instance { get => instance;  }
		
		public BackgroundFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>{
				{ typeof(BushSingle), GetBushSingle },
				{ typeof(BushTriple), GetBushTriple},
				{ typeof(CloudSingle), GetCloudSingle},
				{ typeof(CloudTriple), GetCloudTriple},
				{ typeof(MountainBig), GetMounntainBig },
				{ typeof(MountainSmall), GetMountainSmall }
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
			SpriteDictionary = new Dictionary<Type, Tuple<Texture2D,int,int>>
			{
				{typeof(BushSingle), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("singleBush"),1,1) },
				{typeof(BushTriple), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("tripleBush"),1,1) },
				{typeof(CloudSingle), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("singleCloud"),1,1) },
				{typeof(CloudTriple),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("tripleCloud"),1,1) },
				{typeof(MountainBig), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("bigMountain"),1,1) },
				{typeof(MountainSmall), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("smallMountain"),1,1) }
			};
		}
	}
}
