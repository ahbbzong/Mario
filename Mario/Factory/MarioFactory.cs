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
			SpriteDictionary = new Dictionary<string, Dictionary<string, Tuple<Texture2D,int,int>>>
			{
				{MarioPowerupType.Normal.ToString(), new Dictionary<string, Tuple<Texture2D,int,int>>(){
					{MarioMovementType.LeftIdle.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioLeftIdle"),1,1) },
					{MarioMovementType.LeftJump.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioLeftJump"),1,1) },
					{MarioMovementType.LeftRun.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioLeftRunning"),1,3) },
					{MarioMovementType.RightIdle.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioRightIdle"),1,1) },
					{MarioMovementType.RightJump.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioRightJump"),1,1) },
					{MarioMovementType.RightRun.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioRightRunning"),1,3) }
				} },
				{MarioPowerupType.Big.ToString(), new Dictionary<string, Tuple<Texture2D,int,int>>(){
					{MarioMovementType.LeftCrouch.ToString(), new Tuple<Texture2D,int,int>( content.Load<Texture2D>("superMarioLeftCrouch"),1,1) },
					{MarioMovementType.LeftIdle.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioLeftIdle"),1,1) },
					{MarioMovementType.LeftJump.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioLeftJump"),1,1) },
					{MarioMovementType.LeftRun.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioLeftRunning"),1,3) },
					{MarioMovementType.RightIdle.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightIdle"),1,1) },
					{MarioMovementType.RightJump.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightJump"),1,1) },
					{MarioMovementType.RightRun.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightRunning"),1,3) },
					{MarioMovementType.RightCrouch.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightCrouch"),1,1 )}
				} },
				{MarioPowerupType.Fire.ToString(),new Dictionary<string, Tuple<Texture2D,int,int>>(){
					{MarioMovementType.LeftCrouch.ToString(), new Tuple<Texture2D,int,int>( content.Load<Texture2D>("fireMarioLeftCrouch"),1,1) },
					{MarioMovementType.LeftIdle.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioLeftIdle"),1,1) },
					{MarioMovementType.LeftJump.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioLeftJump"),1,1) },
					{MarioMovementType.LeftRun.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioLeftRunning"),1,3) },
					{MarioMovementType.RightIdle.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightIdle"),1,1) },
					{MarioMovementType.RightJump.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightJump"),1,1) },
					{MarioMovementType.RightRun.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightRunning"),1,3) },
					{MarioMovementType.RightCrouch.ToString(),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightCrouch"),1,1 )}
				}  },
				{MarioPowerupType.Dead.ToString(),new Dictionary<string, Tuple<Texture2D,int,int>>()
				{
					{MarioMovementType.Dead.ToString(), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioDead"),1,1) }
				} }

			};
		}
		private IGameObject GetMario(Vector2 arg)
		{
			return new Mario(arg);
		}

		
		
	}
}
