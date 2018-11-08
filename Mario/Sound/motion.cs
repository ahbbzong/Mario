﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Sound
{
    public static class Motion
    {

        private static SoundEffect breakBlock;
        private static SoundEffect bump;
        private static SoundEffect flip;
        private static SoundEffect marioCoin;
        private static SoundEffect marioDie;
        private static SoundEffect marioFireball;
        private static SoundEffect marioJump;
        private static SoundEffect marioOneUp;
        private static SoundEffect marioPowerUp;
        private static SoundEffect pipeTravel;
        private static SoundEffect powerUpAppears;
        private static SoundEffect stomp;
        private static SoundEffect takeDamage;
        private static Song starMarioMusic;
        private static Song clearStage;
        private static Song gameOver;
        private static Song timeRunningOut;

        public static void loadcontent(ContentManager content)
        {
            breakBlock = content.Load<SoundEffect>("breakBlock");
            bump = content.Load<SoundEffect>("bump");
            flip = content.Load<SoundEffect>("flip");
            marioCoin = content.Load<SoundEffect>("marioCoin");
            marioDie = content.Load<SoundEffect>("marioDie");
            marioFireball = content.Load<SoundEffect>("marioFireball");
            marioJump = content.Load<SoundEffect>("marioJump");
            marioOneUp = content.Load<SoundEffect>("marioOneUp");
            marioPowerUp = content.Load<SoundEffect>("marioPowerUp");
            pipeTravel = content.Load<SoundEffect>("pipeTravel");
            powerUpAppears = content.Load<SoundEffect>("powerUpAppears");
            stomp = content.Load<SoundEffect>("stomp");
            takeDamage = content.Load<SoundEffect>("takeDamage");
            starMarioMusic = content.Load<Song>("starMarioMusic");
            //clearStage = content.Load<Song>("clearStage");
            //gameOver = content.Load<Song>("gameOver");
            //timeRunningOut = content.Load<Song>("timeRunningOut");


        }

        public static SoundEffect BreakBlock { get { return breakBlock; } }
        public static SoundEffect Bump { get { return bump; } }
        public static SoundEffect Flip { get { return flip; } }
        public static SoundEffect MarioCoin { get { return marioCoin; } }
        public static SoundEffect MarioDie { get { return marioDie; } }
        public static SoundEffect MarioFireball { get { return marioFireball; } }
        public static SoundEffect MarioJump { get { return marioJump; } }
        public static SoundEffect MarioOneUp { get { return marioOneUp; } }
        public static SoundEffect MarioPowerUp { get { return marioPowerUp; } }

        public static SoundEffect PipeTravel { get { return pipeTravel; } }
        public static SoundEffect PowerUpAppears { get { return powerUpAppears; } }

        public static SoundEffect Stomp { get { return stomp; } }
        public static SoundEffect TakeDamage { get { return takeDamage; } }

        public static Song StarMarioMusic { get { return starMarioMusic; } }
        public static Song ClearStage { get { return clearStage; } }
        public static Song TimeRunningOut { get { return timeRunningOut; } }
        public static Song GameOver { get { return gameOver; } }

    }
}
