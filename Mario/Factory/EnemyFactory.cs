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

namespace Mario.Factory
{
	class EnemyFactory : GameObjectFactory
	{
		private static EnemyFactory instance = new EnemyFactory();
		public static EnemyFactory Instance { get => instance; }

		private Dictionary<string, Dictionary<string, Texture2D>> spriteDictionary;
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
			Dictionary<string, Texture2D> koopaDictionary = new Dictionary<string, Texture2D>
			{
				{EnemyStateType.Stomped.ToString(), content.Load<Texture2D>("StompedKoopa") },
				{EnemyStateType.Flipped.ToString(), content.Load<Texture2D>("FlippedKoopa") },
				{EnemyStateType.MovingLeft.ToString(), content.Load<Texture2D>("LeftMovingKoopa") },
				{EnemyStateType.MovingRight.ToString(), content.Load<Texture2D>("RightMovingKoopa") }

			};
			spriteDictionary.Add(EnemyType.Koopa.ToString(), koopaDictionary);

			Dictionary<string, Texture2D> goombaDictionary = new Dictionary<string, Texture2D>
			{
				{EnemyStateType.Stomped.ToString(), content.Load<Texture2D>("StompedGoomba") },
				{EnemyStateType.Flipped.ToString(), content.Load<Texture2D>("flippedGoomba") },
				{EnemyStateType.MovingLeft.ToString(), content.Load<Texture2D>("MovingGoomba") },
				{EnemyStateType.MovingRight.ToString(), content.Load<Texture2D>("MovingGoomba") }
			};
		}
	}
}
