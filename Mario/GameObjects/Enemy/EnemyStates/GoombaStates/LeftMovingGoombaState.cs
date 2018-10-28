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
using System.Diagnostics;
namespace Mario.EnemyStates.GoombaStates
{
    public class LeftMovingGoombaState : EnemyState
    {
        public LeftMovingGoombaState(IEnemy enemy):base(enemy)
        {
        }
        public override void BeStomped()
        {
            Enemy.EnemyState = new StompedGoombaState(Enemy);
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedGoombaState(Enemy);
        }
        public override bool IsGoomba()
        {
            return true;
        }
        public override void TurnRight()
        {
            Enemy.EnemyState = new RightMovingGoombaState(Enemy);
        }
        public override void Update()
        {
            EnemySprite.Update();
            if (!Enemy.Island)
            {
                Enemy.gravityManagement.Update();
            }
            Enemy.Position -= Vector2.UnitX;
        }



    }
}
