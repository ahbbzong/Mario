using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioRightRunningState : MarioState
    {
        
        public FireMarioRightRunningState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateFireMarioRightRunningSprite();
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightRunningState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightRunningState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightRunningState(mario);
        }

        public override void Down()
        {
            mario.marioState = new FireMarioRightCrouchState(mario);
            mario.Getposition().Y+=5;
        }


        public override void Left()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new FireMarioRightJumpState(mario);
        }
        public override bool IsFireMario()
        {
            return true;
        }
        public override void Right()
        {
            mario.Getposition().X+=5;
        }

    }
}
