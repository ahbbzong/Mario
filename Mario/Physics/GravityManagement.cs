using Game1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class GravityManagement
    {
        IPhysicsBody physicsBody;
        float Gravity { get; set; }
        float YVelocity { get; set; }
        public GravityManagement(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            YVelocity = 0;
            Gravity = 0.8f;
        }
        public void ReverseYVelocity()
        {
            YVelocity = -YVelocity / 1.2f;
        }
        public void ResetGravity()
        {
            YVelocity = 0;
        }
        private void ApplyGtravity()
        {
            physicsBody.Position += Vector2.UnitY * YVelocity;
            YVelocity += Gravity;
        }

        public void Update()
        {
            ApplyGtravity();
        }
        
    }
}
