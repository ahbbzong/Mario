using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.EnemyClasses;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Mario.Enums;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1;
using Mario.EnemyStates.GoombaStates;

namespace Mario.Factory
{
	class EnemyFactory : DynamicGameObjectFactory
	{
		private static readonly EnemyFactory instance = new EnemyFactory();
		public static EnemyFactory Instance { get => instance; }
		private EnemyFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{typeof(Goomba), GetGoomba },
				{typeof(Koopa),GetKoopa }
			};
		}
		private IGameObject GetGoomba(Vector2 position)
		{
			return new Goomba(position);
		}

		private IGameObject GetKoopa(Vector2 position)
		{
			return new Koopa(position);
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Dictionary<Type, Tuple<Texture2D,int,int>>>
			{
				{typeof(Koopa), new Dictionary<Type, Tuple<Texture2D,int,int>>{
						{typeof(StompedKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("StompedKoopa"),1,1) },
						{typeof(LeftStompedKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("StompedKoopa"),1,1) },
						{typeof(RightStompedKoopaState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("StompedKoopa"),1,1) },
						{typeof(FlippedKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("FlippedKoopa"),1,1) },
						{typeof(LeftMovingKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("LeftMovingKoopa"),1,2) },
						{typeof(RightMovingKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("RightMovingKoopa"),1,2) }
					}
				},

				{typeof(Goomba), new Dictionary<Type, Tuple<Texture2D,int,int>>{
						{typeof(StompedGoombaState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("StompedGoomba"),1,1 )},
						{typeof(FlippedGoombaState), new Tuple<Texture2D, int, int>( content.Load<Texture2D>("flippedGoomba"),1,2 )},
						{typeof(RightMovingGoombaState), new Tuple<Texture2D, int, int>( content.Load<Texture2D>("MovingGoomba"),1,2) },
                        { typeof(LeftMovingGoombaState), new Tuple<Texture2D, int, int>( content.Load<Texture2D>("MovingGoomba"),1,2)}
					}
				}
			};
		}
	}
}
