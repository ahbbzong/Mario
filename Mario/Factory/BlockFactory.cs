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

namespace Mario.Factory
{
	class BlockFactory : GameObjectFactory
	{
		private static BlockFactory instance = new BlockFactory();

		public static BlockFactory Instance { get => instance; set => instance = value; }

		private Dictionary<string, Texture2D> spriteDictionary;
		public BlockFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>
			{
				{BlockType.Hidden.ToString(), GetHiddenBlock  },
				{BlockType.Floor.ToString(), GetFloorBlock },
				{BlockType.Breakable.ToString(), GetBreakableBlock },
				{BlockType.Pipe.ToString(), GetPipe },
				{BlockType.Question.ToString(), GetQuestionBlock },
				{BlockType.Unbreakable.ToString(),GetUnbreakableBlock }
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
			spriteDictionary = new Dictionary<string, Texture2D>
			{
				{BlockType.Breakable.ToString(), content.Load<Texture2D>("brickBlock")},
				{BlockType.Floor.ToString(), content.Load<Texture2D>("floorBlock") },
				{BlockType.Hidden.ToString(), content.Load<Texture2D>("usedBlock") },
				{BlockType.Pipe.ToString(), content.Load<Texture2D>("pipe") },
				{BlockType.Question.ToString(), content.Load<Texture2D>("questionBlock") },
				{BlockType.Unbreakable.ToString(), content.Load<Texture2D>("UnbreakableBlock") },
				{BlockType.Used.ToString(), content.Load<Texture2D>("usedBlock") }

			};
		}
	}
}
