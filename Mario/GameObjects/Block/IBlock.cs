using Mario.BlockStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
	public interface IBlock : IGameObject, IPhysicsBody
	{

		Rectangle Box { get; }
		bool IsHiddenBlock();
		bool IsBreakableBlock();
		bool IsQuestionBlock();
		void React();
		bool IsBumpedBlockState();
		bool IsBumpedBreakBlock();
		IBlockState BlockState { get; set; }
       
    }
}
