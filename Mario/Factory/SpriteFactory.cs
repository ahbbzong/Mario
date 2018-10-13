

using Game1;
using Mario.AbstractClass;
using Mario.BackgroundSprite;
using Mario.BlockSprite;
using Mario.FireMarioSprite;
using Mario.GoombaSprite;
using Mario.Items;
using Mario.KoopaSprite;
using Mario.NormalMarioSprite;
using Mario.PipeSprites;
using Mario.StarMarioSprite;
using Mario.SuperMarioSprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Factory
{
    public class SpriteFactory
    {
       
        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            
        }

		public ISprite CreateAnimatedSprite(Texture2D texture, int rows, int columns)
		{
			return new AnimatedSprite(texture,rows,columns);
		}

		public ISprite CreateStaticSprite(Texture2D texture)
		{
			return new StaticSprite(texture);
		}

    }
}

