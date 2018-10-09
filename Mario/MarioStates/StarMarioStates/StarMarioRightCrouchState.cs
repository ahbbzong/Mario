
using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class StarMarioRightCrouch : MarioState
    {

        public StarMarioRightCrouch(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioRightCrouchSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightCrouchState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightCrouchState(mario);
        }


        public override void Left()
        {
            mario.marioState = new StarMarioLeftCrouchState(mario);
        }

       public override void Right()
        {
            mario.Getposition().X+=5;
            mario.marioState = new StarMarioRightRunningState(mario);
        }

        public override void Up()
        {
            mario.marioState = new StarMarioRightIdleState(mario);
        }
        public override bool IsStarMario()
        {
            return true;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }

    }


}
