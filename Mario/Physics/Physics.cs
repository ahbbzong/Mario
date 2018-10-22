using Game1;
using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Mario
{
    public class Physics 
    {
       
        public float XVelocity { get; set; }
        private float Gravity { get; set; }
        public float YVelocity { get; set; }
        private float MaxXVelocity { get; set; }
        private float MinXVelocity { get; set; }


        IPhysicsBody physicsBody;
        public Physics(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            XVelocity = 0;
            YVelocity = 0;
            MaxXVelocity = 8.0f;
            MinXVelocity = -8.0f;
            Gravity = 0.8f;
        }
        private void ApplyGtravity()
        {
            physicsBody.Getposition().Y += YVelocity;
            YVelocity += Gravity;

        }
        public void ApplyFriction()
        {
            physicsBody.Getposition().X += XVelocity;
            XVelocity /= 1.25f;
        }
        public void ApplyForceVertical(float YVelocity)
        {
            this.YVelocity = YVelocity;
            
        }
        public void MoveRight()
        {
            if (XVelocity < MaxXVelocity)
            {
                XVelocity += 1.0f;
            }
            else
            {
                XVelocity = MaxXVelocity;
            }
            physicsBody.Getposition().X += XVelocity;
        }
        public void MoveLeft()
        {
            if (XVelocity > MinXVelocity) { 
            
                XVelocity -= 1.0f;
            }
            else
            {
                XVelocity = MinXVelocity;
            }
            physicsBody.Getposition().X += XVelocity;
        }
        public void FireballMove(float Velocity)
        {
            physicsBody.Getposition().X += Velocity;
        }

        public void ResetGravity()
        {
            YVelocity = 0.0f; 
        }
        public void ReverseYVelocity()
        {
            YVelocity = -YVelocity/1.2f;
        }
     
        public void Update()
        {
            ApplyGtravity();
        }
    }
}
