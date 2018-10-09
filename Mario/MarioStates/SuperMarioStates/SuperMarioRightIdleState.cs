using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioRightIdleState : MarioState
    {

        public SuperMarioRightIdleState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioRightIdleSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
        }

        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }

        public override void Down()
        {
            mario.marioState = new SuperMarioRightCrouchState(mario);
        }
        public override void Left()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }

        public override void Right()
        {
            mario.marioState = new SuperMarioRightRunningState(mario);
        }

        public override void Up()
        {
            mario.marioState = new SuperMarioRightJumpState(mario);
        }
        public override bool IsSuperMario()
        {
            return true;
        }

    }
}
