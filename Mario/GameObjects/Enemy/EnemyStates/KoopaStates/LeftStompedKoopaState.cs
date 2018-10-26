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
    public class LeftStompedKoopaState : EnemyState
    {
        public LeftStompedKoopaState(Enemy enemy):base(enemy)
        {
            this.enemy = enemy;
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[EnemyType.Koopa.ToString()][EnemyStateType.Stomped.ToString()]);
			enemy.Velocity = Vector2.Zero;
        }
        public override bool IsLeftStomped()
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
        public override void TurnRight()
        {
            enemy.EnemyState = new RightStompedKoopaState(enemy);


        }
        public override void Update()
        {
            EnemySprite.Update();
            if (!enemy.Island)
            {
                enemy.Physics.Update();
            }
            enemy.Position -= StompedMovingUtil.Util;
        }

    }
}
