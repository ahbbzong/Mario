using Game1;
using Mario.Classes;
using Mario.Classes.BlocksClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.BlockStates
{
    public abstract class BlockState : IBlockState
    {
        protected ISprite blockSprite { get; set; }
        protected Block block { get; set; }
        public int getWidth
        {
            get
            {
                return blockSprite.Width;
            }
        }
        public int getHeight
        {
            get
            {
                return blockSprite.Height;
            }
        }
        protected BlockState(Block block)
        {
            this.block = block;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            blockSprite.Draw(spriteBatch, location);
        }
        public virtual void Update()
        {
            blockSprite.Update();
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
       
    }
}
