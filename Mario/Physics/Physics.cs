using Game1;
using Mario.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class Physics : IUpdateable
    {
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        private float XVelocityMax { get; set; }
        private float YVelocityMax { get; set; }
        private float XAccrelerate { get; set; }
        private float Gravity { get; set; }
        IPhysicsBody physicsBody;
        public Physics(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            XVelocity = physicsBody.XVelocity;
            YVelocity = physicsBody.YVelocity;
            XVelocityMax = physicsBody.XVelocityMax;
            YVelocityMax = physicsBody.YVelocityMax;
            XAccrelerate = 2.0f;
            Gravity = 3.8f;
        }
        private void ApplyGtravity()
        {
             YVelocity -= Gravity;
        }
        private void ApplyFriction()
        {
            if (XVelocity <= XVelocityMax)
            {
                XVelocity += XAccrelerate;
            }
            else
            {
                XVelocity = XVelocityMax;
            }
        }
        public void Update()
        {
            ApplyGtravity();
            ApplyFriction();
        }
    }
}
