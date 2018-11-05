using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1;
namespace Mario.Classes.BlocksClasses
{
	internal class BlockWithContainer : Block
	{
		public BlockWithContainer(Vector2 location) : base(location)
		{
		}

		public override Rectangle Box => base.Box;

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public override void React()
		{
			BlockState.React();
		}
		public override void Update()
		{
			base.Update();
		}
	}
}
