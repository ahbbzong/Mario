using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioLeftCrouchState : MarioState
    {
        public FireMarioLeftCrouchState(IMario mario):base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioLeftCrouchSprite();
        }


        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftCrouchState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftCrouchState(mario);
        }

        public override void Left()
        {
            mario.Getposition().X-=5;
            mario.marioState = new FireMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new FireMarioRightCrouchState(mario);
        }

        public override void Up()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }
        public override bool IsFireMario()
        {
            return true;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }

    }
}
