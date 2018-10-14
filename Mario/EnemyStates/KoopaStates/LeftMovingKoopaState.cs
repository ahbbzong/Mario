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
    public class LeftMovingKoopaState : EnemyState
    {
        public LeftMovingKoopaState(Enemy enemy) : base(enemy)
        {
            EnemySprite = EnemyFactory.Instance.GetSpriteDictionary[EnemyType.Koopa.ToString()][EnemyStateType.MovingLeft.ToString()];

        }
        public override void TurnRight()
        {
            enemy.enemyState = new RightMovingKoopaState(enemy);
        }
        public override void Beflipped()
        {
            enemy.enemyState = new FlippedKoopaState(enemy);
        }
        public override void BeStomped()
        {
            enemy.enemyState = new StompedKoopaState(enemy);
        }
        public override void BeKilled()
        {
            enemy.enemyState = new DeadKoopaState(enemy);
        }


    }
}
