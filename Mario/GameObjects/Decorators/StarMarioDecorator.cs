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
        public void Damage()
        {

        }

        public void Update()
        {
            time++;
            if (time == 10)
            {
                ItemManager.Instance.Mario = DecoratedObject;
            }
        }
	}
}
