using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioRightIdleState : MarioState
    {

        public StarMarioRightIdleState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioRightIdleSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }
        
        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
        }


        public override void Down()
        {
            mario.marioState = new StarMarioRightCrouch(mario);
        }
        public override void Left()
        {
            mario.marioState = new StarMarioLeftIdleState(mario);
        }

        public override void Right()
        {
            mario.marioState = new StarMarioRightRunningState(mario);
        }

        public override void Up()
        {
            mario.marioState = new StarMarioRightJumpState(mario);
        }
        public override bool IsStarMario()
        {
            return true;
        }

    }
}
