

using Game1;
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
        //textures for mario
        private Texture2D noramlMarioLeftIdleSheet;
        private Texture2D noramlMarioRightIdleSheet;
        private Texture2D normalMarioLeftRunningSheet;
        private Texture2D normalMarioRightRunningSheet;
        private Texture2D normalMarioLeftJumpingSheet;
        private Texture2D normalMarioRightJumpingSheet;
        private Texture2D normalMarioDeadSheet;
        private Texture2D superMarioLeftIdleSheet;
        private Texture2D superMarioRightIdleSheet;
        private Texture2D superMarioLeftRunningSheet;
        private Texture2D superMarioRightRunningSheet;
        private Texture2D superMarioLeftJumpingSheet;
        private Texture2D superMarioRightJumpingSheet;
        private Texture2D superMarioLeftCrouchSheet;
        private Texture2D superMarioRightCrouchSheet;
        private Texture2D fireMarioLeftIdleSheet;
        private Texture2D fireMarioRightIdleSheet;
        private Texture2D fireMarioLeftRunningSheet;
        private Texture2D fireMarioRightRunningSheet;
        private Texture2D fireMarioLeftJumpingSheet;
        private Texture2D fireMarioRightJumpingSheet;
        private Texture2D fireMarioLeftCrouchSheet;
        private Texture2D fireMarioRightCrouchSheet;
        private Texture2D starMarioLeftIdleSheet;
        private Texture2D starMarioRightIdleSheet;
        private Texture2D starMarioLeftRunningSheet;
        private Texture2D starMarioRightRunningSheet;
        private Texture2D starMarioLeftJumpingSheet;
        private Texture2D starMarioRightJumpingSheet;
        private Texture2D starMarioLeftCrouchSheet;
        private Texture2D starMarioRightCrouchSheet;
        //textures for blocks
        private Texture2D breakableBlockSheet;
        private Texture2D questionBlockSheet;
        private Texture2D unbreakableBlockSheet;
        private Texture2D usedBlockSheet;
        private Texture2D hiddenBlockSheet;
        private Texture2D floorBlockSheet;
        //texture for item
        private Texture2D pipeSheet;
        private Texture2D coinSheet;
        private Texture2D fireFlowerSheet;
        private Texture2D magicMushroomSheet;
        private Texture2D oneUpMushroomSheet;
        private Texture2D starmanSheet;
        private Texture2D MovingGoombaSheet;
        private Texture2D flippedGoombaSheet;
        private Texture2D stompedGoombaSheet;
        private Texture2D flippedKoopaSheet;
        private Texture2D stompedKoopaSheet;
        private Texture2D leftMovingKoopaSheet;
        private Texture2D rightMovingKoopaSheet;
        //texture for background
        private Texture2D bushSingle;
        private Texture2D bushTriple;
        private Texture2D mountainBig;
        private Texture2D mountainSmall;
        private Texture2D cloudSingle;
        private Texture2D cloudTriple;
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
            noramlMarioLeftIdleSheet = content.Load<Texture2D>("normalMarioLeftIdle");
            noramlMarioRightIdleSheet = content.Load<Texture2D>("normalMarioRightIdle");
            normalMarioLeftRunningSheet = content.Load<Texture2D>("normalMarioLeftRunning");
            normalMarioRightRunningSheet = content.Load<Texture2D>("normalMarioRightRunning");
            normalMarioLeftJumpingSheet = content.Load<Texture2D>("normalMarioLeftJump");
            normalMarioRightJumpingSheet = content.Load<Texture2D>("normalMarioRightJump");
            normalMarioDeadSheet = content.Load<Texture2D>("normalMarioDead");
            superMarioLeftCrouchSheet = content.Load<Texture2D>("superMarioLeftCrouch");
            superMarioRightCrouchSheet = content.Load<Texture2D>("superMarioRightCrouch");
            superMarioLeftIdleSheet = content.Load<Texture2D>("superMarioLeftIdle");
            superMarioRightIdleSheet = content.Load<Texture2D>("superMarioRightIdle");
            superMarioLeftJumpingSheet = content.Load<Texture2D>("superMarioLeftJump");
            superMarioRightJumpingSheet = content.Load<Texture2D>("superMarioRightJump");
            superMarioLeftRunningSheet = content.Load<Texture2D>("superMarioLeftRunning");
            superMarioRightRunningSheet = content.Load<Texture2D>("superMarioRightRunning");
            fireMarioLeftCrouchSheet = content.Load<Texture2D>("fireMarioLeftCrouch");
            fireMarioRightCrouchSheet = content.Load<Texture2D>("fireMarioRightCrouch");
            fireMarioLeftIdleSheet = content.Load<Texture2D>("fireMarioLeftIdle");
            fireMarioRightIdleSheet = content.Load<Texture2D>("fireMarioRightIdle");
            fireMarioLeftJumpingSheet = content.Load<Texture2D>("fireMarioLeftJump");
            fireMarioRightJumpingSheet = content.Load<Texture2D>("fireMarioRightJump");
            fireMarioLeftRunningSheet = content.Load<Texture2D>("fireMarioLeftRunning");
            fireMarioRightRunningSheet = content.Load<Texture2D>("fireMarioRightRunning");
            starMarioLeftCrouchSheet = content.Load<Texture2D>("superMarioLeftCrouch");
            starMarioRightCrouchSheet = content.Load<Texture2D>("superMarioRightCrouch");
            starMarioLeftIdleSheet = content.Load<Texture2D>("superMarioLeftIdle");
            starMarioRightIdleSheet = content.Load<Texture2D>("superMarioRightIdle");
            starMarioLeftJumpingSheet = content.Load<Texture2D>("superMarioLeftJump");
            starMarioRightJumpingSheet = content.Load<Texture2D>("superMarioRightJump");
            starMarioLeftRunningSheet = content.Load<Texture2D>("superMarioLeftRunning");
            starMarioRightRunningSheet = content.Load<Texture2D>("superMarioRightRunning");

            //textures for blocks
            breakableBlockSheet = content.Load<Texture2D>("brickBlock");
            questionBlockSheet = content.Load<Texture2D>("questionBlock");
            unbreakableBlockSheet = content.Load<Texture2D>("UnbreakableBlock");
            usedBlockSheet = content.Load<Texture2D>("usedBlock");
            hiddenBlockSheet = content.Load<Texture2D>("usedBlock");
            floorBlockSheet = content.Load<Texture2D>("floorBlock");


            //texture for pipe
            pipeSheet = content.Load<Texture2D>("pipe");

            coinSheet = content.Load<Texture2D>("Coin");
            fireFlowerSheet = content.Load<Texture2D>("FireFlower");
            magicMushroomSheet = content.Load<Texture2D>("MagicMushroom");
            oneUpMushroomSheet = content.Load<Texture2D>("OneUpMushroom");
            starmanSheet = content.Load<Texture2D>("Starman");

            MovingGoombaSheet = content.Load<Texture2D>("MovingGoomba");
            flippedGoombaSheet = content.Load<Texture2D>("flippedGoomba");
            stompedGoombaSheet = content.Load<Texture2D>("StompedGoomba");
            flippedKoopaSheet = content.Load<Texture2D>("FlippedKoopa");
            stompedKoopaSheet = content.Load<Texture2D>("StompedKoopa");
            rightMovingKoopaSheet = content.Load<Texture2D>("RightMovingKoopa");
            leftMovingKoopaSheet = content.Load<Texture2D>("LeftMovingKoopa");

            bushSingle = content.Load<Texture2D>("singleBush");
            bushTriple = content.Load<Texture2D>("tripleBush");
            mountainBig = content.Load<Texture2D>("bigMountain");
            mountainSmall = content.Load<Texture2D>("smallMountain");
            cloudSingle = content.Load<Texture2D>("singleCloud");
            cloudTriple = content.Load<Texture2D>("tripleCloud");


        }

        public ISprite CreateNormalMarioDeadSprite()
        {
            return new NormalMarioDeadSprite(normalMarioDeadSheet);
        }
        public ISprite CreateNormalMarioLeftIdleSprite()
        {
            return new NormalMarioLeftIdleSprite(noramlMarioLeftIdleSheet);
        }
        public ISprite CreateNormalMarioRightIdleSprite()
        {
            return new NormalMarioRightIdleSprite(noramlMarioRightIdleSheet);
        }
        public ISprite CreateNormalMarioLeftJumpingSprite()
        {
            return new NormalMarioLeftJumpSprite(normalMarioLeftJumpingSheet);
        }
        public ISprite CreateNormalMarioRightJumpingSprite()
        {
            return new NormalMarioRightJumpSprite(normalMarioRightJumpingSheet);
        }
        public ISprite CreateNormalMarioLeftRunningSprite()
        {
            return new NormalMarioLeftRunningSprite(normalMarioLeftRunningSheet, 1, 3);
        }
        public ISprite CreateNormalMarioRightRunningSprite()
        {
            return new NormalMarioRightRunningSprite(normalMarioRightRunningSheet, 1, 3);
        }

        public ISprite CreateSuperMarioLeftIdleSprite()
        {
            return new SuperMarioLeftIdleSprite(superMarioLeftIdleSheet);
        }
        public ISprite CreateSuperMarioRightIdleSprite()
        {
            return new SuperMarioRightIdleSprite(superMarioRightIdleSheet);
        }
        public ISprite CreateSuperMarioLeftJumpingSprite()
        {
            return new SuperMarioLeftJumpSprite(superMarioLeftJumpingSheet);
        }
        public ISprite CreateSuperMarioRightJumpingSprite()
        {
            return new SuperMarioRightJumpSprite(superMarioRightJumpingSheet);
        }
        public ISprite CreateSuperMarioLeftRunningSprite()
        {
            return new SuperMarioLeftRunningSprite(superMarioLeftRunningSheet, 1, 3);
        }
        public ISprite CreateSuperMarioRightRunningSprite()
        {
            return new SuperMarioRightRunningSprite(superMarioRightRunningSheet, 1, 3);
        }

        public ISprite CreateSuperMarioLeftCrouchSprite()
        {
            return new SuperMarioLeftCrouchSprite(superMarioLeftCrouchSheet);
        }
        public ISprite CreateSuperMarioRightCrouchSprite()
        {
            return new SuperMarioRightCrouchSprite(superMarioRightCrouchSheet);
        }

        public ISprite CreateStarMarioLeftIdleSprite()
        {
            return new StarMarioLeftIdleSprite(starMarioLeftIdleSheet);
        }
        public ISprite CreateStarMarioRightIdleSprite()
        {
            return new StarMarioRightIdleSprite(starMarioRightIdleSheet);
        }
        public ISprite CreateStarMarioLeftJumpingSprite()
        {
            return new StarMarioLeftJumpSprite(starMarioLeftJumpingSheet);
        }
        public ISprite CreateStarMarioRightJumpingSprite()
        {
            return new StarMarioRightJumpSprite(starMarioRightJumpingSheet);
        }
        public ISprite CreateStarMarioLeftRunningSprite()
        {
            return new StarMarioLeftRunningSprite(starMarioLeftRunningSheet, 1, 3);
        }
        public ISprite CreateStarMarioRightRunningSprite()
        {
            return new StarMarioRightRunningSprite(starMarioRightRunningSheet, 1, 3);
        }

        public ISprite CreateStarMarioLeftCrouchSprite()
        {
            return new StarMarioLeftCrouchSprite(starMarioLeftCrouchSheet);
        }
        public ISprite CreateStarMarioRightCrouchSprite()
        {
            return new StarMarioRightCrouchSprite(starMarioRightCrouchSheet);
        }

        public ISprite CreateFireMarioLeftIdleSprite()
        {
            return new FireMarioLeftIdleSprite(fireMarioLeftIdleSheet);
        }
        public ISprite CreateFireMarioRightIdleSprite()
        {
            return new FireMarioRightIdleSprite(fireMarioRightIdleSheet);
        }
        public ISprite CreateFireMarioLeftJumpingSprite()
        {
            return new FireMarioLeftJumpSprite(fireMarioLeftJumpingSheet);
        }
        public ISprite CreateFireMarioRightJumpingSprite()
        {
            return new FireMarioRightJumpSprite(fireMarioRightJumpingSheet);
        }
        public ISprite CreateFireMarioLeftRunningSprite()
        {
            return new FireMarioLeftRunningSprite(fireMarioLeftRunningSheet, 1, 3);
        }
        public ISprite CreateFireMarioRightRunningSprite()
        {
            return new FireMarioRightRunning(fireMarioRightRunningSheet, 1, 3);
        }

        public ISprite CreateFireMarioLeftCrouchSprite()
        {
            return new FireMarioLeftCrouchSprite(fireMarioLeftCrouchSheet);
        }
        public ISprite CreateFireMarioRightCrouchSprite()
        {
            return new FireMarioRightCrouchSprite(fireMarioRightCrouchSheet);
        }
        //ISprite for blockes
        //textures for blocks
        public ISprite CreateBreakableBlockSprite()
        {
            return new BreakableBlockSprite(breakableBlockSheet);
        }
        public ISprite CreateHiddenBlockSprite()
        {
            return new HiddenBlockSprite(hiddenBlockSheet);
        }
        public ISprite CreateUnBreakableBlockSprite()
        {
            return new UnBreakableBlockSprite(unbreakableBlockSheet);
        }
        public ISprite CreateQuestionBlockSprite()
        {
            return new QuestionBlockSprite(questionBlockSheet,1,3);
        }
        public ISprite CreateUsedBlockSprite()
        {
            return new UsedBlockSprite(usedBlockSheet);
        }
        public ISprite CreateFloorBlockSprite()
        {
            return new FloorBlockSprite(floorBlockSheet);
        }
        //for pipe
        public ISprite CreatePipeSprite()
        {
            return new PipeSprite(pipeSheet);
        }

        public ISprite CreateCoinSprite()
        {
            return new CoinSprite(coinSheet, 1, 4);
        }
        public ISprite CreateFireFlowerSprite()
        {
            return new FireFlowerSprite(fireFlowerSheet, 1, 4);
        }
        public ISprite CreateMagicMushroomSprite()
        {
            return new MagicMushroomSprite(magicMushroomSheet);
        }
        public ISprite CreateOneUpMushroomSprite()
        {
            return new OneUpMushroomSprite(oneUpMushroomSheet);
        }
        public ISprite CreateStarmanSprite()
        {
            return new StarmanSprite(starmanSheet, 1, 4);
        }
        public ISprite CreateMovingGoombaSprite()
        {
            return new MovingGoombaSprite(MovingGoombaSheet, 1, 2);
        }
        public ISprite CreateLeftMovingKoopaSprite()
        {
            return new LeftMovingKoopaSprite(leftMovingKoopaSheet, 1, 2);
        }

           
        public ISprite CreateFlippedGoombaSprite()
        {
            return new FlippedGoombaSprite(flippedGoombaSheet);
        }
        public ISprite CreateStompedGoombaSprite()
        {
            return new StompedGoombaSprite(stompedGoombaSheet);
        }
        public ISprite CreateFlippedKoopaSprite()
        {
            return new FlippedKoopaSprite(flippedKoopaSheet);
        }
        public ISprite CreateStompedKoopaSprite()
        {
            return new StompedKoopaSprite(stompedKoopaSheet);
        }
        public ISprite CreateRightMovingKoopaSprite()
        {
            return new RightMovingKoopaSprite(rightMovingKoopaSheet, 1, 2);
        }
        public ISprite CreatBushSingleSprite()
        {
            return new BushSingleSprite(bushSingle);
        }
        public ISprite CreatBushTripleSprite()
        {
            return new BushTripleSprite(bushTriple);
        }
        public ISprite CreatMountainBigSprite()
        {
            return new MountainBigSprite(mountainBig);
        }
        public ISprite CreatMountainSmallSprite()
        {
            return new MountainSmallSprite(mountainSmall);
        }
        public ISprite CreatCloudSingleSprite()
        {
            return new CloudSingleSprite(cloudSingle);
        }
        public ISprite CreatCloudTripleSprite()
        {
            return new CloudTripleSprite(cloudTriple);
        }
       

    }
}

