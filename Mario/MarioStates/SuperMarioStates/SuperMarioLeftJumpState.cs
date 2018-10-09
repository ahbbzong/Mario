using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    public class SuperMarioLeftJumpState : MarioState
    {

        public SuperMarioLeftJumpState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateSuperMarioLeftJumpingSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftJumpState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftJumpState(mario);
        }
        public override void BeStarMario()
        {
            mario.marioState = new StarMarioLeftJumpState(mario);
        }

    

        public override void Down()
        {
            mario.marioState = new SuperMarioLeftIdleState(mario);
        }

        

       

        public override void Right()
        {
            mario.marioState = new SuperMarioRightJumpState(mario);
        }

        public override bool IsSuperMario()
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
