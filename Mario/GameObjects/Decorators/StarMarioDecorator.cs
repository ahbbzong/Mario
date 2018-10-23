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

        private ISprite starMarioSprite = null;
        private int timer = 0;
		public StarMarioDecorator(IMario mario):base(mario){

		}
		public void Damage()
        {

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

        public override void Draw(SpriteBatch spriteBatch){

            timer++;
            switch (timer%10)
            {
                case 1: 
                    starMarioSprite.Draw(spriteBatch , DecoratedMario.Position, Color.White);
                    break;
                case 2:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.Blue);
                    break;
                case 3:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.Red);
                    break;
                case 4:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.Green);
                    break;
                case 5:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.Black);
                    break;
                case 6:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.Pink);
                    break;
                case 7:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.SteelBlue);
                    break;
                case 8:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.RoyalBlue);
                    break;
                case 9:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.SaddleBrown);
                    break;
                default:
                    starMarioSprite.Draw(spriteBatch, DecoratedMario.Position, Color.White);
                    break;
            }
        }

	}
}
