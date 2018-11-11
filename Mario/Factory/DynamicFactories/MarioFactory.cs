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
using Mario.MarioStates.MarioPowerupStates;
using Mario.MarioStates.MarioMovementStates;

namespace Mario.Factory
{
	class MarioFactory:DynamicGameObjectFactory
	{
		private static MarioFactory instance = new MarioFactory();
		public static MarioFactory Instance { get => instance;}
		public MarioFactory():base()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{typeof(IMario), GetMario }
			};
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Dictionary<Type, Tuple<Texture2D, int, int>>>
			{
				{typeof(NormalMarioPowerupState), new Dictionary<Type, Tuple<Texture2D,int,int>>(){
					{typeof(LeftIdleMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioLeftIdle"),1,1) },
					{typeof(LeftJumpingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioLeftJump"),1,1) },
					{typeof(LeftRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioLeftRunning"),1,3) },
					{typeof(RightIdleMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioRightIdle"),1,1) },
					{typeof(RightJumpingMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioRightJump"),1,1) },
					{typeof(RightRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioRightRunning"),1,3) }
				} },
				{typeof(SuperMarioPowerupState), new Dictionary<Type, Tuple<Texture2D,int,int>>(){
					{typeof(LeftCrouchingMarioMovementState), new Tuple<Texture2D,int,int>( content.Load<Texture2D>("superMarioLeftCrouch"),1,1) },
					{typeof(LeftIdleMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioLeftIdle"),1,1) },
					{typeof(LeftJumpingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioLeftJump"),1,1) },
					{typeof(LeftRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioLeftRunning"),1,3) },
					{typeof(RightIdleMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightIdle"),1,1) },
					{typeof(RightJumpingMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightJump"),1,1) },
					{typeof(RightRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightRunning"),1,3) },
					{typeof(RightCrouchingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("superMarioRightCrouch"),1,1 )}
				} },
				{typeof(FireMarioPowerupState),new Dictionary<Type, Tuple<Texture2D,int,int>>(){
					{typeof(LeftCrouchingMarioMovementState), new Tuple<Texture2D,int,int>( content.Load<Texture2D>("fireMarioLeftCrouch"),1,1) },
					{typeof(LeftIdleMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioLeftIdle"),1,1) },
					{typeof(LeftJumpingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioLeftJump"),1,1) },
					{typeof(LeftRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioLeftRunning"),1,3) },
					{typeof(RightIdleMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightIdle"),1,1) },
					{typeof(RightJumpingMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightJump"),1,1) },
					{typeof(RightRunningMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightRunning"),1,3) },
					{typeof(RightCrouchingMarioMovementState),new Tuple<Texture2D,int,int>(content.Load<Texture2D>("fireMarioRightCrouch"),1,1 )}
				}  },
				{typeof(DeadMarioPowerupState),new Dictionary<Type, Tuple<Texture2D,int,int>>()
				{
					{typeof(DeadMarioMovementState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>("normalMarioDead"),1,1) }
				} },
               


            };
		}
		private IGameObject GetMario(Vector2 arg)
		{
			return new Mario(arg);
		}

		
		
	}
}
