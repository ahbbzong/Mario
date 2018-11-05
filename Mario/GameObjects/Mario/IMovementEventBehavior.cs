using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;

namespace Mario.Interfaces.GameObjects
{
	public interface IMovementEventBehavior
	{
		void GoUp();
		void GoDown();
		void GoLeft();
		void GoRight();
		void NoInput();
	}
}
