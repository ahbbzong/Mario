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
using Mario.Classes.BlocksClasses;

namespace Mario.Factory
{
	class BackgroundFactory : StaticGameObjectFactory
	{
		private static readonly BackgroundFactory instance = new BackgroundFactory();
		public static BackgroundFactory Instance { get => instance;  }
		
		public BackgroundFactory()
		{

		}

		public IGameObject GetBackgroundObject(string backgroundObjectName, Vector2 arg)
		{
			Background backgroundObj = new BackgroundObject(arg)
			{
				BackgroundSprite = SpriteFactory.Instance.CreateSprite(GameObjectSprites[backgroundObjectName])
			};
			return backgroundObj;
		}
		public override void LoadContent(ContentManager content)
		{
			GameObjectSprites = new Dictionary<string, Tuple<Texture2D,int,int>>
			{
				{"BushSingle", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("singleBush"),1,1) },
				{"BushTriple", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("tripleBush"),1,1) },
				{"CloudSingle", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("singleCloud"),1,1) },
				{"CloudTriple",new Tuple<Texture2D,int,int>(content.Load<Texture2D>("tripleCloud"),1,1) },
				{"MountainBig", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("bigMountain"),1,1) },
                {"BlackGround", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("BlackGround"),1,1) },
                {"MountainSmall", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("smallMountain"),1,1) },
                {"Castle", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("castle"),1,1) },
                {"Flag", new Tuple<Texture2D,int,int>(content.Load<Texture2D>("Flag"),1,5) }
            };
		}
	}
}
