using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioRightRunningState : MarioState
    {

        public SuperMarioRightRunningState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioRightRunningSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightRunningState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightRunningState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightRunningState(mario);
        }


        public override void Down()
        {
            mario.marioState = new SuperMarioRightCrouchState(mario);
            mario.Getposition().Y+=5;
        }
     


        public override void Left()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
        }


        public override void Up()
        {
            mario.marioState = new SuperMarioRightJumpState(mario);
        }

        public override bool IsSuperMario()
        {
            return true;
        }
        public override void Right()
        {
            mario.Getposition().X+=5;
        }
    }
}
