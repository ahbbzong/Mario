﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;
namespace Mario.XMLRead
{
    public class BlockXML
    {
        public BlockType BlockType{ get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
    }
}
