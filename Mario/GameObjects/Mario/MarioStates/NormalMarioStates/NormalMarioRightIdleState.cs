using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioRightIdleState : MarioState
    {

        public NormalMarioRightIdleState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateNormalMarioRightIdleSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
        }

        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }

        public override void Left()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }

        public override void Right()
        {
            mario.marioState = new NormalMarioRightRunningState(mario);
        }

        public override void Up()
        {
            mario.marioState = new NormalMarioRightJumpState(mario);
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
