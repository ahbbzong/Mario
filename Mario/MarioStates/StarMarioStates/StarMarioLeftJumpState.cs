using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario.MarioStates
{
    public class StarMarioLeftJumpState : MarioState
    {

        public StarMarioLeftJumpState(Mario mario) : base(mario)
        {
            this.mario = mario;

            marioSprite = SpriteFactory.Instance.CreateStarMarioLeftJumpingSprite();
        }

        public override void BeFireMario()
        {
            mario.marioState = new FireMarioLeftJumpState(mario);
        }

        public override void BeNormalMario()
        {
            mario.marioState = new NormalMarioLeftJumpState(mario);
        }
        public override void BeSuperMario()
        {
            mario.marioState = new SuperMarioLeftJumpState(mario);
        }
        public override void Down()
        {
            mario.marioState = new StarMarioLeftIdleState(mario);
        }


        public override void Right()
        {
            mario.marioState = new StarMarioRightJumpState(mario);
        }
        public override bool IsStarMario()
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
