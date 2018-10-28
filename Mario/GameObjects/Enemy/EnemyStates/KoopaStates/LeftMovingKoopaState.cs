using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using Mario.Enums;
using Mario.Factory;
using Mario.GameObjects.Enemy.EnemyStates.KoopaStates;
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
            enemy.Velocity = -Vector2.UnitX;
        }
        public override void TurnRight()
        {
            enemy.EnemyState = new RightMovingKoopaState(enemy);
        }
        public override void Beflipped()
        {
            enemy.EnemyState = new FlippedKoopaState(enemy);
        }
        public override void BeStomped()
        {
            enemy.EnemyState = new StompedKoopaState(enemy);
        }
       
        public override bool IsKoopa()
        {
            return true;
        }
        public override void Update()
        {
            EnemySprite.Update();
            if (!enemy.Island)
            {
                enemy.gravityManagement.Update();
            }
            enemy.Position -= Vector2.UnitX;
        }



    }
}
