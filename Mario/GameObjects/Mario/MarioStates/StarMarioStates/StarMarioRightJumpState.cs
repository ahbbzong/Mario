using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioRightJumpState : MarioState
    {

        public StarMarioRightJumpState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioRightJumpingSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightJumpState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightJumpState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightJumpState(mario);
        }


        public override void Down()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
        }

        

        public override void Left()
        {
            mario.marioState = new StarMarioLeftJumpState(mario);
        }
        public override bool IsStarMario()
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
