﻿

using System;
using Game1;
using Mario.AbstractClass;
using Mario.AbstractClass.SpriteAbstractClasses;
using Mario.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Factory
{
    public class SpriteFactory
    {
       
        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFactory()
        {
        }

		internal ISprite CreateSprite(Tuple<Texture2D, int, int> tuple)
		{
			return new AnimatedSprite(tuple.Item1, tuple.Item2, tuple.Item3);
		}
		
		public ISprite CreateEmptySprite(int width, int height)
		{
			return new EmptySprite(width, height);
		}
    }
}

