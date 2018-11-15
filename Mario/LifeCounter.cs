using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
   public sealed class LifeCounter
    {
        private static LifeCounter instance = new LifeCounter();
        public static LifeCounter Instance { get => instance; set => instance = value; }
        public int Life { get; set; }
        private LifeCounter()
        {
            Life = 3;
        }
        public int LifeRemains()
        {
            return Life;
        }
        public void DecreaseLife()
        {
            Life--;
        }
        public void IncreaseLife()
        {
            Life++;
        }
        public void ResetLife()
        {
            Life = 3;
        }
        public void SetLifeZero()
        {
            Life = 0;
        }
    }
}
