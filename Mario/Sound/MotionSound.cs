using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Sound
{
    public class MotionSound
    {
		private static MotionSound instance = new MotionSound();
		public static MotionSound Instance { get => instance; set => instance = value; }

		private static IDictionary<string, SoundEffect> soundEffectDictionary = new Dictionary<string, SoundEffect>();
		private static IDictionary<string, Song> songDictionary = new Dictionary<string, Song>();
 

        public static void StopSong(){
			MediaPlayer.Stop();
        }
		public static void loadcontent(ContentManager content)
		{
			soundEffectDictionary = new Dictionary<string, SoundEffect>
			{
				{ "breakBlock", content.Load<SoundEffect>("breakBlock")},
				{"bump", content.Load<SoundEffect>("bump") },
				{"flip", content.Load<SoundEffect>("flip") },
				{"marioCoin", content.Load<SoundEffect>("marioCoin") },
				{"marioDie", content.Load<SoundEffect>("marioDie") },
				{"marioFireball",content.Load<SoundEffect>("smb_fireball") },
				{"marioJump" , content.Load<SoundEffect>("marioJump") },
				{"marioOneUp",content.Load<SoundEffect>("marioOneUp") },
				{"marioPowerUp",content.Load<SoundEffect>("marioPowerUp") },
				{"pipeTravel", content.Load<SoundEffect>("pipeTravel") },
				{"powerUpAppears", content.Load<SoundEffect>("powerUpAppears") },
				{"stomp", content.Load<SoundEffect>("smb_stomp") },
				{"takeDamage", content.Load<SoundEffect>("takeDamage") },
				{ "clearStage" , content.Load<SoundEffect>("clearStage")},
				{ "gameOver", content.Load<SoundEffect>("gameOver")},
				{ "timeRunningOut", content.Load<SoundEffect>("timeRunningOut")}
			};
			songDictionary = new Dictionary<string, Song>{
				{"starMarioMusic",content.Load<Song>("starMarioMusic") },
				{ "marioBGM", content.Load<Song>("marioBGM")}
			};
		}
		public void PlaySoundEffect(string soundEffectName)
		{
			soundEffectDictionary[soundEffectName].Play();
		}
		public void PlayBGM(string songName)
		{
			MediaPlayer.Play(songDictionary[songName]);
		}        
    }
}
