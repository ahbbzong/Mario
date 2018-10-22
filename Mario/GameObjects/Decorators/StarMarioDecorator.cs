using Game1;
using Mario.XMLRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators
{
	class StarMarioDecorator: MarioDecorator
	{
		
        private int time = 0;
		public StarMarioDecorator(IMario mario):base(mario){

		}
		public void Damage()
        {

        }

        public override void Update()
        {
            time++;
            if (time == 10)
            {
                ItemManager.Instance.Mario = DecoratedMario;
            }
			base.Update();
        }
	}
}
