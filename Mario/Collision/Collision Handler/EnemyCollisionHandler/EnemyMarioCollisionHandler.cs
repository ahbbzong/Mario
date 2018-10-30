using Game1;
using Mario.EnemyStates.GoombaStates;
using Mario.Enums;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.EnemyCollisionHandler
{
    public class EnemyMarioCollisionHandler: IEnemyCollisionHandler
    {
        IMario mario;
        Direction result;
        public EnemyMarioCollisionHandler(IMario mario, Direction result)
        {
            this.mario = mario;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemy)
        {
            if (mario.IsStarMario()&&result!=Direction.None)
            {
                enemy.Beflipped();
            }
            if (result==Direction.Up)
            {
                enemy.BeStomped();
            }
            if (enemy.EnemyState is StompedKoopaState && result==Direction.Right)
            {
                enemy.TurnLeft();
            }
            else if(enemy.EnemyState is StompedKoopaState && result==Direction.Left)
            {
                enemy.TurnRight();
            }

        }
     
	}
}
