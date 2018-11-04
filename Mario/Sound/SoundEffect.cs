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
        public static MotionEffect Instance { get => instance; set => instance = value; }


        public IDictionary<string, SoundEffect> sef = new Dictionary<string, SoundEffect>();

        public void loadcontent()
        {

            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("breakBlock"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("bump"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("clearStage"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("flip"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("MarioPowrUp"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("marioDie"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("gameOver"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("marioCoin"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("marioFireball"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("marioJump"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("marioOneup"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("pipeTravel"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("powerUpAppears"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("stomp"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("takeDamage"));
            sef.Add("", Game1.Instance.Content.Load<SoundEffect>("timeRunningOut"));
        }

        public void effectPlay(string currentState)
        {
            sef[currentState].Play();
        }

    }
}
