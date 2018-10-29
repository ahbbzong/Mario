using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	class StarMarioDecorator: MarioDecorator
	{

        private int timer = 0;
		public StarMarioDecorator(IMario mario):base(mario){

		}
		

		public override void TakeDamage()
		{
			//NO -OP
		}

		public override void Update()
        {
            timer+= ItemManager.Instance.CurrentGameTime.ElapsedGameTime.Milliseconds;
            if (timer == 5000)
            {
                ItemManager.Instance.Mario = DecoratedMario;
            }
			base.Update();
        }

		public override bool IsStarMario()
		{
			return true;
		}

        public override void Draw(SpriteBatch spriteBatch){

            timer++;
            switch (timer%10)
            {
                case 1: 
                    DecoratedMario.Draw(spriteBatch , Color.White);
                    break;
                case 2:
                    DecoratedMario.Draw(spriteBatch, Color.Blue);
                    break;
                case 3:
                    DecoratedMario.Draw(spriteBatch, Color.Red);
                    break;
                case 4:
                    DecoratedMario.Draw(spriteBatch, Color.Green);
                    break;
                case 5:
                    DecoratedMario.Draw(spriteBatch, Color.Black);
                    break;
                case 6:
                    DecoratedMario.Draw(spriteBatch, Color.Pink);
                    break;
                case 7:
                    DecoratedMario.Draw(spriteBatch, Color.SteelBlue);
                    break;
                case 8:
                    DecoratedMario.Draw(spriteBatch, Color.RoyalBlue);
                    break;
                case 9:
                    DecoratedMario.Draw(spriteBatch, Color.SaddleBrown);
                    break;
                default:
                    DecoratedMario.Draw(spriteBatch, Color.White);
                    break;
            }
        }

	}
}
