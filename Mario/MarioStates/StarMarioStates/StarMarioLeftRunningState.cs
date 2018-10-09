using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioLeftRunningState : MarioState
    {

        public StarMarioLeftRunningState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioLeftRunningSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftRunningState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftRunningState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftRunningState(mario);
        }


        public override void Down()
        {
            mario.marioState = new StarMarioLeftCrouchState(mario);
            mario.Getposition().Y+=5;
        }

       
        public override void Right()
        {
            mario.marioState = new StarMarioLeftIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new StarMarioLeftJumpState(mario);
        }
        public override bool IsStarMario()
        {
            return true;
        }
        public override void Left()
        {
            mario.Getposition().X-=5;
        }

    }
}
