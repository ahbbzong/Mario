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
    public class RightStompedKoopaState : EnemyState
    {
        public RightStompedKoopaState(Enemy enemy):base(enemy)
        {
            this.enemy = enemy;
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[typeof(Koopa)][typeof(RightStompedKoopaState)]);
			enemy.Velocity = Vector2.Zero;
        }
        public override bool IsRightStomped()
        {
            return true;
        }
        public override void Beflipped()
        {
            enemy.EnemyState = new FlippedKoopaState(enemy);
        }
       
        public override bool IsKoopa()
        {
            return true;
        }
        public override void TurnLeft()
        {
            enemy.EnemyState = new LeftStompedKoopaState(enemy);
        }
        public override void Update()
        {
            EnemySprite.Update();
            if (!enemy.Island)
            {
                enemy.gravityManagement.Update();
            }
            enemy.Position += StompedMovingUtil.Util;
        }


    }
}
