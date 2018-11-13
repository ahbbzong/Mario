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
    public class LeftStompedKoopaState : EnemyState
    {
        public LeftStompedKoopaState(IEnemy enemy):base(enemy)
        {
            Enemy = enemy;
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[typeof(Koopa)][typeof(StompedKoopaState)]);
        }
        public override bool IsLeftStomped()
        {
            return true;
        }
       
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedKoopaState(Enemy);
        }
       
        public override bool IsKoopa()
        {
            return true;
        }
        public override void TurnRight()
        {
            Enemy.EnemyState = new RightStompedKoopaState(Enemy);


        }
        public override void Update()
        {
            EnemySprite.Update();
            Enemy.gravityManagement.Update();
            Enemy.Position -= EnemyUtil.Util;
        }

    }
}
