using Game1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Physics
{
   public class Physics
    {
        private IMario mario;
        private float XVelocity { get; set; }
        private float YVelocity { get; set; }
        private float XVelocityMax { get; set; }
        private float XVelocityMin { get; set; }
        private float YVelocityMax { get; set; }
        private float YVelocityMin { get; set; }
        private float XAccrelerate { get; set; }
        private float Gravity { get; set; }
        public Physics(IMario mario)
        {
            this.mario = mario;
            XVelocity = 0;
            YVelocity = 3.5f;
            XVelocityMax = 3.5f;
            XVelocityMin = -3.5f;
            YVelocityMax = 3.5f;
            YVelocityMin = 0;
            XAccrelerate = 2.0f;
            Gravity = 3.8f;
        }
        public void MovingLeft()
        {
            if (XVelocity > XVelocityMin)
            {
                XVelocity -= XAccrelerate;
            }
            else
            {
                XVelocity = XVelocityMin;
            }
        }
        public void MovingRight()
        {
            if (XVelocity <= XVelocityMin)
            {
                XVelocity += XAccrelerate;
            }
            else
            {
                XVelocity = XVelocityMax;
            }
        }
        public void MovingUp()
        {
            if (YVelocity<YVelocityMax)
            {
                YVelocity += Gravity;
            }
            else
            {
                YVelocity = YVelocityMax;
            }
        }
    }
}
