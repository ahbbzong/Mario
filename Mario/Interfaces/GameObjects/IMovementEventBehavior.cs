using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Interfaces.GameObjects
{
	public interface IMovementEventBehavior
	{
		void Up();
		void Down();
		void Left();
		void Right();


	}
}
