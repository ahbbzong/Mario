
using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class SuperMarioRightCrouchState :MarioState
    {

        public SuperMarioRightCrouchState(IMario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioRightCrouchSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioRightCrouchState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightCrouch(mario);
        }

   
        
        public override void Left()
        {
            mario.marioState = new SuperMarioLeftCrouchState(mario);
        }

        public override void Right()
        {
            mario.Getposition().X+=5;
            mario.marioState = new SuperMarioRightRunningState(mario);
        }

        public override void Up()
        {
            mario.marioState = new SuperMarioRightIdleState(mario);
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
