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

namespace Mario.Factory
{
	class EnemyFactory : DynamicGameObjectFactory
	{
		private static EnemyFactory instance = new EnemyFactory();
		public static EnemyFactory Instance { get => instance; }
		private EnemyFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>
			{
				{EnemyType.Goomba.ToString(), GetGoomba },
				{EnemyType.Koopa.ToString(),GetKoopa }
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
			SpriteDictionary = new Dictionary<string, Dictionary<string, ISprite>>
			{
				{EnemyType.Koopa.ToString(), new Dictionary<string, ISprite>{
						{EnemyStateType.Stomped.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("StompedKoopa")) },
						{EnemyStateType.Flipped.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("FlippedKoopa")) },
						{EnemyStateType.MovingLeft.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("LeftMovingKoopa"),1,2) },
						{EnemyStateType.MovingRight.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("RightMovingKoopa"),1,2) }
					}
				},

				{EnemyType.Goomba.ToString(), new Dictionary<string, ISprite>
				{
						{EnemyStateType.Stomped.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("StompedGoomba") )},
						{EnemyStateType.Flipped.ToString(), SpriteFactory.Instance.CreateStaticSprite( content.Load<Texture2D>("flippedGoomba") )},
						{EnemyStateType.MovingLeft.ToString(), SpriteFactory.Instance.CreateAnimatedSprite( content.Load<Texture2D>("MovingGoomba"),1,2) },
						{EnemyStateType.MovingRight.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("MovingGoomba"),1,2) }
					}
				}
			};
		}
	}
}
