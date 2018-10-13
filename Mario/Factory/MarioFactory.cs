using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Mario.Enums;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Mario.Factory
{
	class MarioFactory:GameObjectFactory
	{
		private static MarioFactory instance = new MarioFactory();
		public static MarioFactory Instance { get => instance; set => instance = value; }

		private IDictionary<string, IDictionary<string,Texture2D>> spriteDictionary = new Dictionary<string,IDictionary<string,Texture2D>>();

		public MarioFactory()
		{
			InstantiationLedger = new Dictionary<string, Func<Microsoft.Xna.Framework.Vector2, Interfaces.GameObjects.IGameObject>>
			{
				{"Mario", GetMario }
			};
		}

		public override void LoadContent(ContentManager content)
		{
			Dictionary<string, Texture2D> normalMarioSprites = new Dictionary<string, Texture2D>()
			{
				{MarioMovementType.LeftIdle.ToString(),content.Load<Texture2D>("normalMarioLeftIdle") },
				{MarioMovementType.LeftJump.ToString(),content.Load<Texture2D>("normalMarioLeftJump") },
				{MarioMovementType.LeftRun.ToString(), content.Load<Texture2D>("normalMarioLeftRun") },
				{MarioMovementType.RightIdle.ToString(), content.Load<Texture2D>("normalMarioRightIdle") },
				{MarioMovementType.RightJump.ToString(), content.Load<Texture2D>("normalMarioRightJump") },
				{MarioMovementType.RightRun.ToString(), content.Load<Texture2D>("normalMarioRightRun") }
			};
			spriteDictionary.Add(MarioPowerupType.Normal.ToString(), normalMarioSprites);

			Dictionary<string, Texture2D> superMarioSprites = new Dictionary<string, Texture2D>()
			{
				{MarioMovementType.LeftCrouch.ToString(), content.Load<Texture2D>("superMarioLeftCrouch") },
				{MarioMovementType.LeftIdle.ToString(),content.Load<Texture2D>("superMarioLeftIdle") },
				{MarioMovementType.LeftJump.ToString(),content.Load<Texture2D>("superMarioLeftJump") },
				{MarioMovementType.LeftRun.ToString(), content.Load<Texture2D>("superMarioLeftRun") },
				{MarioMovementType.RightIdle.ToString(), content.Load<Texture2D>("superMarioRightIdle") },
				{MarioMovementType.RightJump.ToString(), content.Load<Texture2D>("superMarioRightJump") },
				{MarioMovementType.RightRun.ToString(), content.Load<Texture2D>("superMarioRightRun") },
				{MarioMovementType.RightCrouch.ToString(),content.Load<Texture2D>("superMarioRightCrouch") }
			};
			spriteDictionary.Add(MarioPowerupType.Big.ToString(), superMarioSprites);

			Dictionary<string, Texture2D> fireMarioSprites = new Dictionary<string, Texture2D>()
			{
				{MarioMovementType.LeftCrouch.ToString(), content.Load<Texture2D>("fireMarioLeftCrouch") },
				{MarioMovementType.LeftIdle.ToString(),content.Load<Texture2D>("fireMarioLeftIdle") },
				{MarioMovementType.LeftJump.ToString(),content.Load<Texture2D>("fireMarioLeftJump") },
				{MarioMovementType.LeftRun.ToString(), content.Load<Texture2D>("fireMarioLeftRun") },
				{MarioMovementType.RightIdle.ToString(), content.Load<Texture2D>("fireMarioRightIdle") },
				{MarioMovementType.RightJump.ToString(), content.Load<Texture2D>("fireMarioRightJump") },
				{MarioMovementType.RightRun.ToString(), content.Load<Texture2D>("fireMarioRightRun") },
				{MarioMovementType.RightCrouch.ToString(),content.Load<Texture2D>("fireMarioRightCrouch") }
			};

			Dictionary<string, Texture2D> deadMarioSprites = new Dictionary<string, Texture2D>()
			{
				{MarioMovementType.Dead.ToString(),content.Load<Texture2D>("normalMarioDead") }
			};
		}
		private IGameObject GetMario(Vector2 arg)
		{
			return new Mario(arg);
		}

		
	}
}
