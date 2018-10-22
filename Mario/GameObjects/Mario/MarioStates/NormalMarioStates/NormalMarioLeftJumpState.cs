using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class NormalMarioLeftJumpState : MarioState
    {

        public NormalMarioLeftJumpState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateNormalMarioLeftJumpingSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftJumpState(mario);
        }


        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftJumpState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftJumpState(mario);
        }
        public override void Dead()
        {
            mario.marioState = new NormalMarioDeadState(mario);
        }

        public override void Down()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }

        
       

        public override void Right()
        {
            mario.marioState = new NormalMarioRightJumpState(mario);
        }
        public override bool IsNormalMario()
        {
            return true;
        }
        public override void Left()
        {
            mario.Getposition().X-=5;
        }
        public override void Up()
        {
            mario.Getposition().Y-=5;
        }

    }
}
