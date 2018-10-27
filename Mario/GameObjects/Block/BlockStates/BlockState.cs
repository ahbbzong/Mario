﻿using Game1;
using Mario.Classes;
using Mario.Classes.BlocksClasses;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.BlockStates
{
    public abstract class BlockState : IBlockState
    {
        protected ISprite BlockSprite { get; set; }
        protected IBlock Block { get; set; }
        public int GetWidth
        {
            get
            {
                return BlockSprite.Width;
            }
        }
        public int GetHeight
        {
            get
            {
                return BlockSprite.Height;
            }
        }
        protected BlockState(IBlock block)
        {
            this.Block = block;
		}
		public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            BlockSprite.Draw(spriteBatch, location);
        }
        public virtual void Update()
        {
            BlockSprite.Update();
        }

      
        public virtual void React()
        {
            
        }
        public virtual bool IsHiddenBlock()
        {
            return false;
        }
        public virtual bool IsBreakableBlock()
        {
            return false;
        }

        public virtual bool IsQuestionBlock()
        {
            return false;
        }

        public virtual bool IsBumpedBlockState()
        {
            return false;
        }

        public virtual bool IsBumpedBreakBlock()
        {
            return false;
        }
    }
}
