﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;
namespace Mario.XMLRead
{
    public class ItemXML
    {
        public int Chunk { get; set; }
        public string GameObjectType { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
    }
}
