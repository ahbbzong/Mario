using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioLeftIdleState : MarioState
    {
        public FireMarioLeftIdleState(Mario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioLeftIdleSprite();
        }


        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftIdleState(mario);
        }

        public override void Down()
        {
            mario.marioState = new FireMarioLeftCrouchState(mario);
        }

        public override void Left()
        {
            mario.marioState = new FireMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new FireMarioLeftJumpState(mario);
        }
        public override bool IsFireMario()
        {
            return true;
        }
    }
}
