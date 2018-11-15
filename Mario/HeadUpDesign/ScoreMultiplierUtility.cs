﻿using Game1;
using Mario.Interfaces.GameObjects;
using Mario.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.HeadUpDesign
{
    class ScoreMultiplierUtility
    {
        private Dictionary<IGameObject, int> koopaKickedShells;
        private int stompedEnemiesInSequence = ScoreUtil.ZeroScore;
        public bool HitEnemyAlreadyThisIteration { get; set; } = false;
        
        public ScoreMultiplierUtility()
        {
            this.stompedEnemiesInSequence = ScoreUtil.ZeroScore;
            this.koopaKickedShells = new Dictionary<IGameObject, int>();
        }

        public int DetermineDoubleStompSequence()
        {
            int scoreToAdd = ScoringMultiplerUtil.InitialStompScore;
            if (HitEnemyAlreadyThisIteration)
                scoreToAdd = ScoringMultiplerUtil.DoubleStompScore;
            HitEnemyAlreadyThisIteration = true;
            return scoreToAdd;
        }

        public int DetermineStompSequence()
        {
            int scoreToAdd = DetermineDoubleStompSequence();
            if (scoreToAdd == ScoringMultiplerUtil.InitialStompScore && (!GameObjectManager.Instance.Mario.Island))
            {
                switch (stompedEnemiesInSequence)
                {
                    case 0:
                        scoreToAdd = ScoringMultiplerUtil.InitialStompScore;
                        break;
                    case 1:
                        scoreToAdd = ScoringMultiplerUtil.Stomp2ComboScore;
                        break;
                    case 2:
                        scoreToAdd = ScoringMultiplerUtil.Stomp3ComboScore;
                        break;
                    case 3:
                        scoreToAdd = ScoringMultiplerUtil.Stomp4ComboScore;
                        break;
                    case 4:
                        scoreToAdd = ScoringMultiplerUtil.Stomp5ComboScore;
                        break;
                    case 5:
                        scoreToAdd = ScoringMultiplerUtil.Stomp6ComboScore;
                        break;
                    case 6:
                        scoreToAdd = ScoringMultiplerUtil.Stomp7ComboScore;
                        break;
                    case 7:
                        scoreToAdd = ScoringMultiplerUtil.Stomp8ComboScore;
                        break;
                    case 8:
                        scoreToAdd = ScoringMultiplerUtil.Stomp9ComboScore;
                        break;
                    case 9:
                        LifeCounter.Instance.IncreaseLife();
                        break;
                    default:
                        break;
                }

                stompedEnemiesInSequence++;
            }
            else if (GameObjectManager.Instance.Mario.Island)
            {
                stompedEnemiesInSequence = ScoreUtil.ZeroScore;
            }
            return scoreToAdd;
        }

        public int DetermineShellHitSequence(IGameObject koopa)
        {
            int scoreToAdd = ScoringMultiplerUtil.InitialShellHitScore;
            switch (koopaKickedShells[koopa])
            {
                case 0:
                    scoreToAdd = ScoringMultiplerUtil.InitialShellHitScore;
                    break;
                case 1:
                    scoreToAdd = ScoringMultiplerUtil.ShellHit2ComboScore;
                    break;
                case 2:
                    scoreToAdd = ScoringMultiplerUtil.ShellHit3ComboScore;
                    break;
                case 3:
                    scoreToAdd = ScoringMultiplerUtil.ShellHit4ComboScore;
                    break;
                case 4:
                    scoreToAdd = ScoringMultiplerUtil.ShellHit5ComboScore;
                    break;
                case 5:
                    scoreToAdd = ScoringMultiplerUtil.ShellHit6ComboScore;
                    break;
                case 6:
                    LifeCounter.Instance.IncreaseLife();
                    break;
                default:
                    break;
            }
            koopaKickedShells[koopa]++;
            return scoreToAdd;
        }

        public int DetermineShellInitializationSequence(IGameObject koopa)
        {
            int scoreToAdd = ScoringMultiplerUtil.InitialShellKickScore;
            if (!koopaKickedShells.ContainsKey(koopa))
                koopaKickedShells.Add(koopa, 0);
            if ((!GameObjectManager.Instance.Mario.Island))
                scoreToAdd = ScoringMultiplerUtil.InAirAfterMakingShellKickScore;
            return scoreToAdd;
        }
    }
}

   