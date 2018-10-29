using Game1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Game1
{
    public class Physics 
    {
       
        public float XVelocity { get; set; }
        private float Gravity { get; set; }
        public float YVelocity { get; set; }
        private float MinYVelocity { get; set; }
        private float MaxYVelocity { get; set; }
        IMario mario;
        public Physics(IMario mario)
        {
            this.mario = mario;
            XVelocity = 0;
            YVelocity = 0;
            MinYVelocity = PhysicsUtil.minYVelocity;
            MaxYVelocity = PhysicsUtil.maxYVelocity;
        }
        public void Sprint()
        {
            XVelocity *= PhysicsUtil.sprintVelocity;
        }
     
        public void MoveRight()
        {
            if (XVelocity < PhysicsUtil.firstPhaseXVelocity)
            {
                XVelocity += PhysicsUtil.maxXVelocity * PhysicsUtil.firstPhaseMultiplier;
            }
            else
            {
                XVelocity += PhysicsUtil.maxXVelocity * PhysicsUtil.secondPhaseMultiplier;
            }
            if (XVelocity > PhysicsUtil.maxXVelocity)
            {
                XVelocity = PhysicsUtil.maxYVelocity;
            }
        }
        public void MoveLeft()
        {
            if (XVelocity >= -PhysicsUtil.firstPhaseXVelocity) { 
            
                XVelocity -= PhysicsUtil.maxXVelocity * PhysicsUtil.firstPhaseMultiplier;
            }
            else
            {
                XVelocity -= PhysicsUtil.maxXVelocity * PhysicsUtil.secondPhaseMultiplier;
            }
        }
        public void JumpLeft()
        {
            if (!mario.IsDead())
            {
                XVelocity -= 10 * 0.5f;

                if (XVelocity < -PhysicsUtil.maxXVelocity)
                {
                    XVelocity = -PhysicsUtil.maxXVelocity;
                }
            }
        }
        public void JumpRight()
        {
            if (!mario.IsDead())
            {
                XVelocity += 10 * 0.5f;

                   if (XVelocity > PhysicsUtil.maxXVelocity)
                   {
                     XVelocity = PhysicsUtil.maxXVelocity;
            }
            }
        }
        public void Jump()
        {
            if (YVelocity <= MaxYVelocity)
            {
                YVelocity = MinYVelocity + YVelocity * PhysicsUtil.JumpPhaseMultiplier;
            }
            else
            {
                YVelocity = MaxYVelocity;
            }
        }
        public void NotJump()
        {
            if (YVelocity > 1.2f)
            {
                YVelocity = 0.3f;
            }
        }
       
        public void CheckFalling()
        {
            if (YVelocity<-2)
            {
                mario.SetFalling(true);
                mario.IsLandFlase();
            }
            else
            {
                mario.SetFalling(false);
            }
        }
        public void UpdateVertical()
        {
            mario.Position -= Vector2.UnitY * YVelocity;
            if (YVelocity >= 0.05)
            {
                YVelocity *= 0.70f;
            }
            else if (YVelocity <= 0.05)
            {

                YVelocity -= MaxYVelocity * 0.02f;

            }
        }
        public void UpdateHorizontal()
        {
            mario.Position += Vector2.UnitX * XVelocity;
            if (mario.IsLandResponse())
            {
                XVelocity *= 0.9f;
            }
            else
            {
                XVelocity = 0;
            }
        }
        public float XVelocityResponse()
        {
            return XVelocity;
        }
        public float YVelocityResponse()
        {
            return YVelocity;
        }
        public void ResetGravity()
        {
            YVelocity = 0.0f;
        }
        public void ResetHorizontal()
        {
            XVelocity = 0.0f;
        }
        public void ReverseYVelocity()
        {
            YVelocity = -YVelocity/1.2f;
        }
     
        public void Update()
        {
            UpdateHorizontal();
            UpdateVertical();
            CheckFalling();
        }
    }
}
