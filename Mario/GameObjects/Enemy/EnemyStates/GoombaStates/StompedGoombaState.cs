using Game1;
using Mario.AbstractClass;
using Mario.Classes.BlocksClasses;
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
    public class StompedGoombaState : EnemyState
    {
        int count = EnemyUtil.goombaAppear;
        public StompedGoombaState(IEnemy enemy) :base(enemy)
        {
        }

        public override bool IsGoombaStomped()
        {
            return true;

        }
        public override bool IsGoomba()
        {
            return true;
        }
        public override void Update()
        {
            count++;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (count < EnemyUtil.goombaDisappear)
            {
                EnemySprite.Draw(spriteBatch, location);
            }
            else
            {
                GameObjectManager.Instance.GameObjectListsByType[typeof(IEnemy)].Remove(Enemy);
            }
        }



    }
}

