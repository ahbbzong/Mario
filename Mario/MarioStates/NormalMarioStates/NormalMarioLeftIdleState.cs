using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioLeftIdleState : MarioState
    {

        public NormalMarioLeftIdleState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateNormalMarioLeftIdleSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftIdleState(mario);
        }

        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }


        public override void Left()
        {
            mario.marioState = new NormalMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new NormalMarioLeftJumpState(mario);
        }
        public override bool IsNormalMario()
        {
            return true;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }


    }
}
