using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioRightRunningState : MarioState
    {

        public StarMarioRightRunningState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioRightRunningSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightRunningState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightRunningState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightRunningState(mario);
        }

        public override void Down()
        {
            mario.marioState = new StarMarioRightCrouch(mario);
            mario.Getposition().Y+=5;
        }

        

        public override void Left()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
         
        }


        public override void Up()
        {
            mario.marioState = new StarMarioRightJumpState(mario);
        }
        public override bool IsStarMario()
        {
            return true;
        }
        public override void Right()
        {
            mario.Getposition().X+=5;
        }
    }
}
