using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario;
using Game1;
using Mario.Enums;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class MarioDecorator : IMario
    {
        public Rectangle Box => throw new NotImplementedException();

        private IMario DecoratedMario { get; set; }
        public MarioMovementState MarioMovementState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MarioPowerupState MarioPowerupState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Physics physics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MarioMovementType MarioMovementType => throw new NotImplementedException();

        public MarioPowerupType MarioPowerupType => throw new NotImplementedException();

        public virtual void IsLeft()
        {
            
        }

        public virtual void IsRight()
        {

        }
        public  virtual void IsDead()
        {

        }

        public virtual void IsFalling()
        {

        }

        public virtual void IsSuperMario()
        {

        }
        public void IsNormalMario()
        {

        }
        public void  IsFireMario()
        {

        }
        public void IsStarMario()
        {

        }

        bool IMario.IsSuperMario()
        {
            throw new NotImplementedException();
        }

        bool IMario.IsNormalMario()
        {
            throw new NotImplementedException();
        }

        bool IMario.IsFireMario()
        {
            throw new NotImplementedException();
        }

        bool IMario.IsStarMario()
        {
            throw new NotImplementedException();
        }

        bool IMario.IsDead()
        {
            throw new NotImplementedException();
        }

        public bool Isfalling()
        {
            throw new NotImplementedException();
        }

        bool IMario.IsLeft()
        {
            throw new NotImplementedException();
        }

        bool IMario.IsRight()
        {
            throw new NotImplementedException();
        }

        public void ThrowFireball()
        {
            throw new NotImplementedException();
        }

        public void IsLandTrue()
        {
            throw new NotImplementedException();
        }

        public void IsLandFlase()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Up()
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void Left()
        {
            throw new NotImplementedException();
        }

        public void Right()
        {
            throw new NotImplementedException();
        }

        public void NoInput()
        {
            throw new NotImplementedException();
        }

        public void Dead()
        {
            throw new NotImplementedException();
        }

        public void BeSuper()
        {
            throw new NotImplementedException();
        }

        public void BeNormal()
        {
            throw new NotImplementedException();
        }

        public void BeFire()
        {
            throw new NotImplementedException();
        }

        public void BeStar()
        {
            throw new NotImplementedException();
        }

        public ref Vector2 Getposition()
        {
            throw new NotImplementedException();
        }
    }
}
