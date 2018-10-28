using Game1;
using Mario.AbstractClass;
using Mario.Classes.BlocksClasses;
using Mario.EnemyClasses;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.EnemyStates.GoombaStates
{
    public class FlippedGoombaState : EnemyState
    {
        public FlippedGoombaState(IEnemy enemy) :base(enemy)
        {
        }
        public override bool IsFlipped()
        {
            return true;
        }
        public override void Update()
        {
            Enemy.gravityManagement.Update();
        }
    }
}
