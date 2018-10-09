
using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioLeftCrouchState : MarioState
    {

        public StarMarioLeftCrouchState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioLeftCrouchSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftCrouchState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftCrouchState(mario);
        }
        public override void Left()
        {
            mario.Getposition().X-=5;
            mario.marioState = new StarMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new StarMarioRightCrouch(mario);
        }

        public override void Up()
        {
            mario.marioState = new StarMarioLeftIdleState(mario);
        }
        public override bool IsStarMario()
        {
            return true;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }
    }
}
