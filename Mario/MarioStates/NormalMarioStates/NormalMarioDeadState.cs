using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioDeadState : MarioState
    {

        public NormalMarioDeadState(Mario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateNormalMarioDeadSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
        }
        public override bool IsNormalMario()
        {
            return true;
        }
        public override bool IsDead()
        {
            return true;
        }

    }
}
