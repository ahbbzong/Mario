using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Game1
{
	public interface IBlock : IGameObject
	{
		
        string ItemContained { get; set; }
		void React();
        Vector2 Position { get; set; }
	
        IBlockState BlockState { get; set; }
       
    }
}
