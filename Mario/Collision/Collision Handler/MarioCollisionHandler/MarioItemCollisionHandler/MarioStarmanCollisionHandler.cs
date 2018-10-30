using Game1;
using Mario.Enums;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler
{
    public class MarioStarmanCollisionHandler : IMarioCollisionHandler
    {
        public MarioStarmanCollisionHandler()
        {
        }
        public void HandleCollision(IMario mario, Direction result)
        {
            if (mario.MarioPowerupState is NormalMarioPowerupState
                || mario.MarioPowerupState is SuperMarioPowerupState
                || mario.MarioPowerupState is FireMarioPowerupState)
            {
                mario.BeStar();
            }
        }
    }
}
