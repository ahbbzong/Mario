using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    class FireMarioRightCrouchState : MarioState
    {
        public FireMarioRightCrouchState(IMario mario) : base(mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactory.Instance.CreateFireMarioRightCrouchSprite();
        }

       public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioRightIdleState(mario);
        }

       public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioRightCrouchState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioRightCrouch(mario);
        }


       public override void Left()
        {
            mario.marioState = new FireMarioLeftCrouchState(mario);
        }

       public override void Right()
        {
            mario.Getposition().X+=5;
            mario.marioState = new FireMarioRightRunningState(mario);
        }

       public override void Up()
        {
            mario.marioState = new FireMarioRightIdleState(mario);
        }
        public override void Down()
        {
            mario.Getposition().Y+=5;
        }
        public override bool IsFireMario()
        {
            return true;
        }
        
    }
}
