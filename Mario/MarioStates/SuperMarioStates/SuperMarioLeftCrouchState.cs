using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioLeftCrouchState : MarioState
    {

        public SuperMarioLeftCrouchState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioLeftCrouchSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftCrouchState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftIdleState(mario);
        }

        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftCrouchState(mario);
        }

     
        public override void Left()
        {
            mario.Getposition().X-=5;
            mario.marioState = new SuperMarioLeftRunningState(mario);
        }

        public override void Right()
        {
            mario.marioState = new SuperMarioRightCrouchState(mario);
        }

        public override void Up()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }
        public override bool IsSuperMario()
        {
            return true;
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }
    }
}
