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
        public LeftMovingKoopaState(IEnemy enemy) : base(enemy)
        {
        }
        public override void TurnRight()
        {
            Enemy.EnemyState = new RightMovingKoopaState(Enemy);
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedKoopaState(Enemy);
        }
        public override void BeStomped()
        {
            Enemy.EnemyState = new StompedKoopaState(Enemy);
        }
       
        public override bool IsKoopa()
        {
            return true;
        }
        public override void Update()
        {
            EnemySprite.Update();
            Enemy.gravityManagement.Update();
            Enemy.Position -= Vector2.UnitX;
        }



    }
}
