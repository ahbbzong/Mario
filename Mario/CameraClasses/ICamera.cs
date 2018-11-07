﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface ICamera
    {
        Vector2 Location { get; }
        Matrix Transform { get; }
        Rectangle InnerBox { get; set; }
        void ResetCameraLocation(Rectangle box);
        void MoveRight(float move);
        bool IsOffSideOfScreen(Rectangle box);

        bool IsOffTopOrBottomOfScreen(Rectangle box);
       
    }
}