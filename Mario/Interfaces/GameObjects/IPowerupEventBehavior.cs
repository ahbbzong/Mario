using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Interfaces.GameObjects
{
	public interface IPowerupEventBehavior
	{
		void Dead();


		void BeSuper();

		void BeNormal();

		void BeFire();
		void BeStar();
	}
}
