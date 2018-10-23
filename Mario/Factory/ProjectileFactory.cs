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
	class ProjectileFactory : SimpleGameObjectFactory
	{
		private static ProjectileFactory instance = new ProjectileFactory();
		public static ProjectileFactory Instance { get => instance; }
		
		private ProjectileFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
                {Type.GetType("Fireball"),GetFireball }
			};
		}

		
        private IGameObject GetFireball(Vector2 arg)
        {
            return new Fireball(arg);
        }

        public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Tuple<Texture2D,int,int>>
			{
                {Type.GetType("Fireball"), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("Fireball"),1,4) }
            };
		}
	}
}
