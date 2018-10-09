using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioRightJumpState : MarioState
    {
        public FireMarioRightJumpState(Mario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioRightJumpingSprite();
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightJumpState(mario);
        }

        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightJumpState(mario);
        }


            public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightJumpState(mario);
        }

        public override void Down()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }


        public override void Left()
        {
            mario.marioState = new FireMarioLeftJumpState(mario);
        }

     
        public override bool IsFireMario()
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
