using Game1;
using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class Physics 
    {
       
        private float XVelocity { get; set; }
        private float Gravity { get; set; }
        private float MaxXVelocity { get; set; }
        private float MinXVelocity { get; set; }


        IPhysicsBody physicsBody;
        public Physics(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            XVelocity = 0;
            MaxXVelocity = 3.0f;
            MinXVelocity = -3.0f;
            Gravity = 0.8f;
        }
        private void ApplyGtravity()
        {
            Gravity += 0.05f;
            physicsBody.Getposition().Y += Gravity;

        }
        public void ApplyForce()
        {
            physicsBody.Getposition().X += XVelocity;
            XVelocity /= 1.05f;
        }
        public void MoveRight()
        {
            if (XVelocity < MaxXVelocity)
            {
                XVelocity += 0.05f;
            }
            else
            {
                XVelocity = MaxXVelocity;
            }
            physicsBody.Getposition().X += XVelocity;
        }
        public void MoveLeft()
        {
            if (XVelocity > MinXVelocity)
            {
                XVelocity -= 0.05f;
            }
            else
            {
                XVelocity = MinXVelocity;
            }
            physicsBody.Getposition().X += XVelocity;
        }
   
        public void ResetGravity()
        {
            Gravity = 0.8f;
        }
        
       public void Update()
        {
            ApplyGtravity();
        }
    }
}
