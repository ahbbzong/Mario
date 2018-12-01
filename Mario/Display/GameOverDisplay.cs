using Game1;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.Sound;
using Mario.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Display
{
	public  class GameOverDisplay: IDisplay
    {
        ITextSprite lifeTextSprite;
        IGameObject backgroundSprite;
            public GameOverDisplay()
            {
                lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
                backgroundSprite = BackgroundFactory.Instance.GetBackgroundObject("BlackGround", new Vector2(SpriteUtil.Zero, SpriteUtil.Zero));
                lifeTextSprite.Text = "Game Over";
            //if ()
            //{

            //count the number of game count adn then if it is reaches the three, then 
            // play the gameover song
            SoundManager.Instance.PlaySoundEffect(SoundString.gameOver);

            SoundManager.StopSong();
        }
        public void Update()
            {
            //implement to reach 100 count.
            }
            public void Draw(SpriteBatch spriteBatch)
            {
                backgroundSprite.Draw(spriteBatch);
                lifeTextSprite.Location = new Vector2(SpriteUtil.gameOverPositionX, SpriteUtil.gameOverPositionY);
                lifeTextSprite.Draw(spriteBatch);
            }
    }
}
