
using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioLeftIdleState : MarioState
    {

        public StarMarioLeftIdleState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioLeftIdleSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }
        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }
        public override void Down()
        {
            mario.marioState = new StarMarioLeftCrouchState(mario);
        }
        public override void Left()
        {
            mario.marioState = new StarMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new StarMarioLeftJumpState(mario);
        }
        public override bool IsStarMario()
        {
            return true;
        }
    }
}
