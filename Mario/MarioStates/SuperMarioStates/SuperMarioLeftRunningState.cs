using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioLeftRunningState : MarioState
    {

        public SuperMarioLeftRunningState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioLeftRunningSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftRunningState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftRunningState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftRunningState(mario);
        }

    

        public override void Down()
        {
            mario.marioState = new SuperMarioLeftCrouchState(mario);
            mario.Getposition().Y+=5;
        }

       
        public override void Right()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new SuperMarioLeftJumpState(mario);
        }
        public override bool IsSuperMario()
        {
            return true;
        }
        public override void Left()
        {
            mario.Getposition().X-=5;
        }


    }
}
