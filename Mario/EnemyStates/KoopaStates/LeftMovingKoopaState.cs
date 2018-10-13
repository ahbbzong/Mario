using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
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
            this.enemy = enemy;
            EnemySprite = SpriteFactory.Instance.CreateLeftMovingKoopaSprite();
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
    
      
    }
}
