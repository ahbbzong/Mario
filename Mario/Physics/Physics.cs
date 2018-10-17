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
       
        private float XAccrelerate { get; set; }
        private float Gravity { get; set; }
        IPhysicsBody physicsBody;
        public Physics(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            XAccrelerate = 2.0f;
            Gravity = 1.8f;
        }
        private void ApplyGtravity()
        {
            Gravity += 0.1f;
            physicsBody.Getposition().Y += Gravity;
        }
        public void ResetGravity()
        {
            Gravity = 1.8f;
        }
       public void Update()
        {
            ApplyGtravity();
        }
    }
}
