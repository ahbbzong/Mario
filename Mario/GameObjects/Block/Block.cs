using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Classes.BlocksClasses
{
    public abstract class Block : IBlock, ICollidiable
    {
        private Vector2 BlockLocation;
        private String itemContains = "";
        public IBlockState BlockState { get; set; }
        public String ItemContains { get => itemContains; set => itemContains = value; }
        public virtual Rectangle Box
        {
            get
            {
                return new Rectangle((int)BlockLocation.X, (int)BlockLocation.Y, BlockState.GetWidth, BlockState.GetHeight);
            }
        }
        protected Block(Vector2 location)
        {
            BlockLocation = location;
            
        }
        public virtual void Update()
        {
            BlockState.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            BlockState.Draw(spriteBatch, BlockLocation);
        }
        public virtual void React()
        {
            //Need to override.
        }
        public virtual bool IsHiddenBlock() {
            return BlockState.IsHiddenBlock();
        }
        public virtual bool IsBreakableBlock()
        {
            return BlockState.IsBreakableBlock();
        }
        public virtual bool IsQuestionBlock()
        {
            return BlockState.IsQuestionBlock();
        }

        public virtual bool IsBumpedBlockState()
        {
            return BlockState.IsBumpedBlockState();
        }

        public virtual bool IsBumpedBreakBlock()
        {
            return BlockState.IsBumpedBreakBlock();
        }

        public virtual void SetContainsItem(String item)
        {
            this.ItemContains = String.Copy(item);
        }

        public Vector2 Position { get => BlockLocation; set => BlockLocation = value; }
	}
}
