﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
         public interface IMario : IDrawable, IUpdateable
        {
          void Up();
          void Down();

         void Left();

         void Right();

         void Dead();

         void BeSuperMario();

         void BeNormalMario();

         void BeFireMario();
        void BeStarMario();
        bool IsSuperMario();
        bool IsNormalMario();
        bool IsFireMario();
        bool IsStarMario();
        bool IsDead();

        bool Isfalling();
         Rectangle Box { get; }
         ref Vector2 Getposition();

    }
}
