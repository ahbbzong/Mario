using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IPhysicsBody
    {
         float XVelocity { get; set; }
         float YVelocity { get; set; }
         float XVelocityMax { get; set; }
         float YVelocityMax { get; set; }

    }
}
