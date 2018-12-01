using System;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.AbstractClass;

namespace Mario.GameObjects
{
    public class MiniBoss : Enemy
    {

        public MiniBoss(Vector2 location) : base(location)
        {
         
        }

        public void ThrowGoomba()
        {
          //  EnemyFactory.Instance.GetGameObject();
        }

    }
}