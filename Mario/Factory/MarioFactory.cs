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
using Game1;

namespace Mario.Factory
{
	class MarioFactory:DynamicGameObjectFactory
	{
		private static MarioFactory instance = new MarioFactory();
		public static MarioFactory Instance { get => instance; set => instance = value; }
		public MarioFactory():base()
		{
			InstantiationLedger = new Dictionary<string, Func<Vector2, IGameObject>>
			{
				{"Mario", GetMario }
			};
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<string, Dictionary<string, ISprite>>
			{
				{MarioPowerupType.Normal.ToString(), new Dictionary<string, ISprite>(){
					{MarioMovementType.LeftIdle.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("normalMarioLeftIdle")) },
					{MarioMovementType.LeftJump.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("normalMarioLeftJump")) },
					{MarioMovementType.LeftRun.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("normalMarioLeftRunning"),1,3) },
					{MarioMovementType.RightIdle.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("normalMarioRightIdle")) },
					{MarioMovementType.RightJump.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("normalMarioRightJump")) },
					{MarioMovementType.RightRun.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("normalMarioRightRunning"),1,3) }
				} },
				{MarioPowerupType.Big.ToString(), new Dictionary<string, ISprite>(){
					{MarioMovementType.LeftCrouch.ToString(), SpriteFactory.Instance.CreateStaticSprite( content.Load<Texture2D>("superMarioLeftCrouch")) },
					{MarioMovementType.LeftIdle.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("superMarioLeftIdle")) },
					{MarioMovementType.LeftJump.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("superMarioLeftJump")) },
					{MarioMovementType.LeftRun.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("superMarioLeftRunning"),1,3) },
					{MarioMovementType.RightIdle.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("superMarioRightIdle")) },
					{MarioMovementType.RightJump.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("superMarioRightJump")) },
					{MarioMovementType.RightRun.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("superMarioRightRunning"),1,3) },
					{MarioMovementType.RightCrouch.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("superMarioRightCrouch") )}
				} },
				{MarioPowerupType.Fire.ToString(),new Dictionary<string, ISprite>(){
					{MarioMovementType.LeftCrouch.ToString(), SpriteFactory.Instance.CreateStaticSprite( content.Load<Texture2D>("fireMarioLeftCrouch")) },
					{MarioMovementType.LeftIdle.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("fireMarioLeftIdle")) },
					{MarioMovementType.LeftJump.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("fireMarioLeftJump")) },
					{MarioMovementType.LeftRun.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("fireMarioLeftRunning"),1,3) },
					{MarioMovementType.RightIdle.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("fireMarioRightIdle")) },
					{MarioMovementType.RightJump.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("fireMarioRightJump")) },
					{MarioMovementType.RightRun.ToString(), SpriteFactory.Instance.CreateAnimatedSprite(content.Load<Texture2D>("fireMarioRightRunning"),1,3) },
					{MarioMovementType.RightCrouch.ToString(),SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("fireMarioRightCrouch") )}
				}  },
				{MarioPowerupType.Dead.ToString(),new Dictionary<string, ISprite>()
				{
					{MarioMovementType.Dead.ToString(), SpriteFactory.Instance.CreateStaticSprite(content.Load<Texture2D>("normalMarioDead")) }
				} }

			};
		}
		private IGameObject GetMario(Vector2 arg)
		{
			return new Mario(arg);
		}

		
		
	}
}
