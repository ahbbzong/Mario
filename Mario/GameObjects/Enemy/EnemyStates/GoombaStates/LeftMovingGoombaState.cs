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
        public LeftMovingGoombaState(Enemy enemy):base(enemy)
        {
			Debug.WriteLine(EnemyFactory.Instance.GetSpriteDictionary.Count);
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[EnemyType.Goomba.ToString()][EnemyStateType.MovingLeft.ToString()]);

        }
        public override void BeStomped()
        {
            enemy.EnemyState = new StomppedGoombaState(enemy);
        }
        public override void Beflipped()
        {
            enemy.EnemyState = new FlippedGoombaState(enemy);
        }
        public override bool IsGoomba()
        {
            return true;
        }
        public override void TurnRight()
        {
            enemy.EnemyState = new RightMovingGoombaState(enemy);
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
