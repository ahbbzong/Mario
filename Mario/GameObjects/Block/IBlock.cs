using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
	public interface IBlock : IGameObject, IPhysicsBody
	{
		
        string ItemContains { get; set; }
		bool IsHiddenBlock();
		bool IsBreakableBlock();
		bool IsQuestionBlock();
		void React();
		bool IsBumpedBlockState();
		bool IsBumpedBreakBlock();
        //void SetContainsItem(String item);
     
        IBlockState BlockState { get; set; }
       
    }
}
