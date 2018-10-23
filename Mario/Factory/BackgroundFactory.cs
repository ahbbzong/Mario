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
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>{
				{ Type.GetType("BushSingle"), GetBushSingle },
				{ Type.GetType("BushTriple"), GetBushTriple},
				{ Type.GetType("CloudSingle"), GetCloudSingle},
				{ Type.GetType("ClodTriple"), GetCloudTriple},
				{ Type.GetType("MountainBig"), GetMounntainBig },
				{ Type.GetType("MountainSmall"), GetMountainSmall }
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
				{Type.GetType("BushSingle"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("singleBush"),1,1) },
				{Type.GetType("BushTriple"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("tripleBush"),1,1) },
				{Type.GetType("CloudSingle"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("singleCloud"),1,1) },
				{Type.GetType("CloudTriple"),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("tripleCloud"),1,1) },
				{Type.GetType("MountainBig"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("bigMountain"),1,1) },
				{Type.GetType("MountainSmall"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("smallMountain"),1,1) }
			};
		}
	}
}
