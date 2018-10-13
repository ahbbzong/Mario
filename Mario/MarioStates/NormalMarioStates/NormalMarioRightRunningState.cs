using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioRightRunningState : MarioState
    {

        public NormalMarioRightRunningState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateNormalMarioRightRunningSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightRunningState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightRunningState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightRunningState(mario);
        }

        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }

        
        public override void Left()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }

        public override void Up()
        {
            mario.marioState = new NormalMarioRightJumpState(mario);
        }

        public override bool IsNormalMario()
        {
            return true;
        }
        public override void Right()
        {
            mario.Getposition().X+=5;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }


    }
}
