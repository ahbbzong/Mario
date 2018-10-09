using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioLeftJumpState : MarioState
    {
        public FireMarioLeftJumpState(Mario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioLeftJumpingSprite();
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftJumpState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftJumpState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftJumpState(mario);
        }

   
        public override void Down()
        {
            mario.marioState = new FireMarioLeftIdleState(mario);
        }

       

        public override void Right()
        {
            mario.marioState = new FireMarioRightJumpState(mario);
        }
        public override bool IsFireMario()
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
