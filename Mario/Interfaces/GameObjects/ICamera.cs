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
        void MoveRight(float move);
    }
}