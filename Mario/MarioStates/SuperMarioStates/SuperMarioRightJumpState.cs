using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioRightJumpState : MarioState
    {

        public SuperMarioRightJumpState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioRightJumpingSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightJumpState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightJumpState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightJumpState(mario);
        }


        public override void Down()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
        }

        

        public override void Left()
        {
            mario.marioState = new SuperMarioLeftJumpState(mario);
        }

       
        public override bool IsSuperMario()
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
