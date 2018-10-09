
using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioLeftIdleState : MarioState
    {

        public SuperMarioLeftIdleState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioLeftIdleSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftCrouchState(mario);
        }

   

        public override void Down()
        {
            mario.marioState = new SuperMarioLeftCrouchState(mario);
        }

        

        public override void Left()
        {
            mario.marioState = new SuperMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new SuperMarioLeftJumpState(mario);
        }
        public override bool IsSuperMario()
        {
            return true;
        }


    }
}
