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
    public class LeftMovingStompedKoopaState : EnemyState
    {
        public LeftMovingStompedKoopaState(Enemy enemy) : base(enemy)
        {
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[EnemyType.Koopa.ToString()][EnemyStateType.Stomped.ToString()]);

        }
        public override void TurnRight()
        {
            enemy.EnemyState = new RightMovingStompedKoopaState(enemy);
        }
        public override void Beflipped()
        {
            enemy.EnemyState = new FlippedKoopaState(enemy);
        }
        public override void BeKilled()
        {
            enemy.EnemyState = new DeadKoopaState(enemy);
        }
        public override bool IsKoopa()
        {
            return true;
        }

    }
}
