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
    public class FlippedKoopaState : EnemyState
    {
        public FlippedKoopaState(IEnemy enemy) : base(enemy)
        {
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[typeof(Koopa)][typeof(FlippedKoopaState)]);
        }
        
        public override bool IsFlipped()
        {
            return true;
        }
        public override bool IsKoopa()
        {
            return true;
        }
        public override void Update()
        {
            Enemy.gravityManagement.Update();
        }
    }
}
