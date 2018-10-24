using Game1;
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
        private float YVelocityMax { get; set; }


        IPhysicsBody physicsBody;
        public Physics(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            XVelocity = 0;
            YVelocity = 0;
            YVelocityMax = -20.0f; 
            MaxXVelocity = 8.0f;
            MinXVelocity = -8.0f;
            Gravity = 0.8f;
        }
        private void ApplyGtravity()
        {
           
                physicsBody.Position += Vector2.UnitY * YVelocity;
                YVelocity += Gravity;
            
            
        }
        public void ApplyFriction()
        {
            physicsBody.Position += Vector2.UnitX*XVelocity;
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
            physicsBody.Position += Vector2.UnitX*XVelocity;
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
            physicsBody.Position += Vector2.UnitX* XVelocity;
        }
        public void FireballMove(float Velocity)
        {
            physicsBody.Position += Vector2.UnitX*Velocity;
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
