using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Mario.MarioStates.MarioPowerupStates;
using Mario.XMLRead;
using Mario.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Collision
{
    public class PipeHandler : IBlockCollisionHandler
    {
        int index;
        public PipeHandler(int index)
        {
            this.index = index;
            MotionEffect.Instance.EffectPlay(MotionType.pipeTravel);
        }
        public void HandleCollision(IBlock block, IMario mario,Direction result)
        {
            if (result == Direction.Up&&mario.IsCrouch()&&index==0)
            {
                mario.Position += Vector2.UnitX * 17000;
                
            }
            if(result == Direction.Up && mario.IsCrouch() && index == 8)
            {
                mario.Position -= Vector2.UnitX * 15895;
                mario.Position -= Vector2.UnitY * 80;
            }

        }

        public void HandleCollision(IGameObject source, IGameObject target, Direction direction)
        {
            HandleCollision((IBlock)source, (IMario)target, direction);
        }
        
    }
}
