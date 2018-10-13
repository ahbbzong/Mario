using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioRightJumpState : MarioState
    {

        public NormalMarioRightJumpState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateNormalMarioRightJumpingSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightJumpState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightJumpState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightJumpState(mario);
        }

        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }

        public override void Down()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }

        public override void Left()
        {
            mario.marioState = new NormalMarioLeftJumpState(mario);
        }

      
        public override bool IsNormalMario()
        {
            return true;
        }
        public override void Up()
        {
            mario.Getposition().Y-=5;
        }
        public override void Right()
        {
            mario.Getposition().X+=5;
        }

    }
}
