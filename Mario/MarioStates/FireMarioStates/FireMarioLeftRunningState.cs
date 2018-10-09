using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioLeftRunningState : MarioState
    {
        public FireMarioLeftRunningState(Mario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioLeftRunningSprite();
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftRunningState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftRunningState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftRunningState(mario);
        }

        public override void Down()
        {
            mario.marioState = new FireMarioLeftCrouchState(mario);
            mario.Getposition().Y+=5;
        }


        public override void Right()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new FireMarioLeftJumpState(mario);
        }
        public override bool IsFireMario()
        {
            return true;
        }
        public override void Left()
        {
            mario.Getposition().X-=5;
        }
    }
}
