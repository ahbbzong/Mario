using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;


namespace Mario.Sound
{
    class MotionEffect
    {

        private static MotionEffect instance = new MotionEffect();
        public static MotionEffect Instance {get   => instance ; set => instance = value  ;}


        public IDictionary<string, SoundEffect > sef = new Dictionary<string, SoundEffect>();
            
        public void loadcontent()
        {

            sef.Add("breakblock" ,Game1.Instance.Content.Load<SoundEffect>("breakBlock"));
            sef.Add("bump",  Game1.Instance.Content.Load<SoundEffect>("bump"));
            sef.Add("clearStage", Game1.Instance.Content.Load<SoundEffect>("clearStage");
            sef.Add("flip", Game1.Instance.Content.Load<SoundEffect>(""));
            sef.Add("MarioPowerUpSate",Game1.Instance.Content.Load<SoundEffect>("MarioPowrUpState")   );



            sef.Add("flip", content.Load<SoundEffect>("flip"));
            sef.Add("gameOver", content.Load<SoundEffect>("gameOer"));
            sef.Add("marioCoin", content.Load<SoundEffect>("marioCoin"));
            sef.Add("marioDie", content.Load<SoundEffect>("marioDie"));
            sef.Add("marioFireball", content.Load<SoundEffect>("marioFireball"));
            sef.Add("marioJump", content.Load<SoundEffect>("marioJump"));
            sef.Add("marioOneUp", content.Load<SoundEffect>("marioOneup"));

            sef.Add("marioPowerUp", content.Load<SoundEffect>("marioPowerUp"));
            sef.Add("pipeTravel", content.Load<SoundEffect>("pipeTravel"));
            sef.Add("powerUpAppears", content.Load<SoundEffect>("powerUpAppears"));
            sef.Add("stomp", content.Load<SoundEffect>("stomp"));
            sef.Add("takeDamage", content.Load<SoundEffect>("takeDamage"));
            sef.Add("timeRunningOut", content.Load<SoundEffect>("timeRunningOut"));

        }
        /*
            breakBlock
            bump
            clearStage
            flip
            gameOver
            marioCoin
            marioDie
            marioFireball
            marioJump
            marioOneUp
            marioPowerUp
            pipeTravel
            powerUpAppears
            stomp
            takeDamage
            timeRunningOut

            */



        public void effectPlay(string currentState)
        {
            sef[currentState].Play();     
        }

}
}
