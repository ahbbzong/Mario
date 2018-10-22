using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
   public interface IMarioState
    {
        void Up();
        void Down();
        void Left();
        void Right();
        void Dead();
        void BeSuperMario();
        void BeNormalMario();
        void BeFireMario();
        void BeStarMario();
        bool IsSuperMario();
        bool IsFireMario();
        bool IsNormalMario();
        bool IsDead();
        bool IsStarMario();
    }
}
