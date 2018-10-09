using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioLeftRunningState : MarioState
    {

        public NormalMarioLeftRunningState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateNormalMarioLeftRunningSprite();
        }
        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftRunningState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftRunningState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftRunningState(mario);
        }

        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }

        public override void Right()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new NormalMarioLeftJumpState(mario);
        }
        public override bool IsNormalMario()
        {
            return true;
        }
        public override void Left()
        {
            mario.Getposition().X-=5;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }

    }
}
