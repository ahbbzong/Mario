using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Mario
{
	public interface IPlayerStats
	{
		int Lives { get; set; }
		int Score { get; set; }
		float ScoreMultiplier { get; set; }
	}
}
