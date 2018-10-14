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
    public class StomppedGoombaState : EnemyState
    {
        public StomppedGoombaState(Enemy enemy) :base(enemy)
        {
            EnemySprite = EnemyFactory.Instance.GetSpriteDictionary[EnemyType.Goomba.ToString()][EnemyStateType.Stomped.ToString()];
        }

        public override bool IsStomped()
        {
            return true;

        }
    }
}

