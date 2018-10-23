using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.BlocksClasses;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Mario.Enums;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1;

namespace Mario.Factory
{
	class BlockFactory : SimpleGameObjectFactory
	{
		private static BlockFactory instance = new BlockFactory();

		public static BlockFactory Instance { get => instance; set => instance = value; }
		
		public BlockFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{Type.GetType("HiddenBlock"), GetHiddenBlock  },
				{Type.GetType("FloorBlock"), GetFloorBlock },
				{Type.GetType("BreakableBlock"), GetBreakableBlock },
				{Type.GetType("Pipe"), GetPipe },
				{Type.GetType("QuestionBlock"), GetQuestionBlock },
				{Type.GetType("UnbreakableBlock"),GetUnbreakableBlock }
			};
		}

		private IGameObject GetUnbreakableBlock(Vector2 arg)
		{
			return new UnbreakableBlock(arg);
		}

		private IGameObject GetQuestionBlock(Vector2 arg)
		{
			return new QuestionBlock(arg);
		}

		private IGameObject GetPipe(Vector2 arg)
		{
			return new Pipe(arg);
		}

		private IGameObject GetBreakableBlock(Vector2 arg)
		{
			return new BreakableBlock(arg);
		}

		private IGameObject GetFloorBlock(Vector2 arg)
		{
			return new FloorBlock(arg);
		}

		private IGameObject GetHiddenBlock(Vector2 arg)
		{
			return new HiddenBlock(arg);
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Tuple<Texture2D,int,int>>
			{
				{Type.GetType("BreakableBlockState"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("brickBlock"),1,1)},
				{Type.GetType("FloorBlockState"), new Tuple<Texture2D,int,int>( content.Load<Texture2D>("floorBlock"),1,1) },
				//this should be changed moving forward to accept parameters for width and height with no sprite
				{Type.GetType("HiddenBlockState"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("usedBlock"),1,1) },
				{Type.GetType("PipeState"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("pipe"),1,1) },
				{Type.GetType("QuestionBlockState"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("questionBlock"),1,3) },
				{Type.GetType("UnbreakableBlockState"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("UnbreakableBlock"),1,1) },
				{Type.GetType("UsedBlockState"), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("usedBlock"),1,1) }

			};
		}
	}
}
