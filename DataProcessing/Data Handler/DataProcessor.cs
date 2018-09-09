using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    public class DataProcessor
    {
        public void ProcessData(string _playerIGN, string _leagueName, int _playerCharacter)
        {
            // API request
            var currentPlayer = ApiDataHandler.GetPlayerData(_playerIGN, _leagueName);

            // Player class
            string playerClass = currentPlayer.Entries[_playerCharacter].Character.Class;

            // Player selected character
            string playerCharacter = currentPlayer.Entries[_playerCharacter].Character.Name;

            // Player league
            string playerLeague = _leagueName;

            // Player global rank
            int playerGlobalRank = currentPlayer.Entries[_playerCharacter].Rank;

            // Player class rank
            const int maxLimit = 200;
            int _offset = 0;
            int playerClassRank = 0;

            //// Checking players class above selected player, if they are playing same class , add it to counter (playerClassRank)

            //void checkPlayerClassRank(int globalRank)
            //{
            //    if (globalRank <= maxLimit)
            //    {
            //        var playersAbove = ApiDataHandler.GetPlayersAboveData(playerLeague, globalRank, _offset);

            //        for (int i = 0; i < globalRank; i++)
            //        {
            //            if (playersAbove.Entries[i].Character.Class == currentPlayer.Entries[_playerCharacter].Character.Class)
            //            {
            //                playerClassRank++;
            //            }
            //        }
            //    }
            //    else if (globalRank > maxLimit)
            //    {
            //        var playersAbove = ApiDataHandler.GetPlayersAboveData(playerLeague, maxLimit, _offset);
            //        _offset += 200;
            //        globalRank -= 200;

            //        for (int i = 0; i < 200; i++)
            //        {
            //            if (playersAbove.Entries[i].Character.Class == currentPlayer.Entries[_playerCharacter].Character.Class)
            //            {
            //                playerClassRank++;
            //            }
            //        }

            //        checkPlayerClassRank(globalRank);
            //    }
            //}

            //checkPlayerClassRank(playerGlobalRank);

            // Player level
            int playerLevel = currentPlayer.Entries[_playerCharacter].Character.Level;

            // Player experience
            double playerExperience = currentPlayer.Entries[_playerCharacter].Character.Experience;

            //Player % exp , rounded to two decimal places           
            double gainedExp, expToGain, playerPercentageExperience;
            if (playerLevel != 100)
            {
                gainedExp = playerExperience - ExperienceTable.level[playerLevel - 1];
                expToGain = ExperienceTable.level[playerLevel] - ExperienceTable.level[playerLevel - 1];

                playerPercentageExperience = Math.Round(gainedExp * 100 / expToGain, 2);
            }
            else
                playerPercentageExperience = 100;

            // Player exp compared to player above/behind
            // Calculating player offset -> 1.playerAbove 2.currentPlayer 3.playerBehind
            // Subtracting currentPlayer exp from player above/behind
            int offset;

            switch (currentPlayer.Entries[_playerCharacter].Rank)
            {
                case 1:
                case 2:
                    offset = 0;
                    break;
                case 3:
                    offset = 1;
                    break;
                default:
                    offset = currentPlayer.Entries[_playerCharacter].Rank - 2;
                    break;
            }

            var playerBehindAndAbove = ApiDataHandler.GetDataOfPlayerAboveAndBehind(_leagueName, offset);
            double playerBehindExp;
            if (playerGlobalRank == 1)
            {
                playerBehindExp = playerExperience - playerBehindAndAbove.Entries[1].Character.Experience;
            }
            else
            {
                playerBehindExp = playerExperience - playerBehindAndAbove.Entries[2].Character.Experience;
            }
            double playerAboveExp;

            if (currentPlayer.Entries[_playerCharacter].Rank == 1)
            {
                playerAboveExp = 0;
            }
            else
                playerAboveExp = currentPlayer.Entries[_playerCharacter].Character.Experience - playerBehindAndAbove.Entries[0].Character.Experience;

            TrackerInterface trackerInterface = new TrackerInterface
                (
                    playerClass,
                    playerCharacter,
                    playerLeague,
                    playerGlobalRank,
                    playerClassRank,
                    playerLevel,
                    playerExperience,
                    playerPercentageExperience,
                    playerAboveExp,
                    playerBehindExp
                );

            trackerInterface.Show();
        }
    }
}
