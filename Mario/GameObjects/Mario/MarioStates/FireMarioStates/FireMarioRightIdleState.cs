using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioRightIdleState : MarioState
    {
        public FireMarioRightIdleState(IMario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioRightIdleSprite();
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


        public override void Down()
        {
            mario.marioState = new FireMarioRightCrouchState(mario);
        }


        public override void Left()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }

        public override void Right()
        {
            mario.marioState = new FireMarioRightRunningState(mario);
        }

        public override void Up()
        {
            mario.marioState = new FireMarioRightJumpState(mario);
        }
        public override bool IsFireMario()
        {
            return true;
        }

    }
}
