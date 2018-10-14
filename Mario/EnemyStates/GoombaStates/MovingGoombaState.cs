using Game1;
using Mario.AbstractClass;
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
    public class MovingGoombaState : EnemyState
    {
        public MovingGoombaState(Enemy enemy):base(enemy)
        {
            EnemySprite = EnemyFactory.Instance.GetSpriteDictionary[EnemyType.Goomba.ToString()][EnemyStateType.MovingLeft.ToString()];
        }
        public override void BeStomped()
        {
            enemy.enemyState = new StomppedGoombaState(enemy);
        }
    }
}
