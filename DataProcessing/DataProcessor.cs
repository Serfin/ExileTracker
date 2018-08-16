using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class DataProcessor
    {
        public DataProcessor(string _playerIGN, string _leagueName, int _playerCharacter)
        {
            // API request
            var currentPlayer = GetDataFromApi.GetPlayerData(_playerIGN, _leagueName);

            // Player class
            string playerClass = currentPlayer.Entries[_playerCharacter].Character.Class;

            // Player selected character
            string playerCharacter = currentPlayer.Entries[_playerCharacter].Character.Name;

            // Player league
            string playerLeague = _leagueName;

            // Player global rank
            int playerGlobalRank = currentPlayer.Entries[_playerCharacter].Rank;

            // Player class rank
            var playersAbove = GetDataFromApi.GetPlayersAboveData(_leagueName, currentPlayer.Entries[_playerCharacter].Rank);
            int playerClassRank = 0;

            // Checking players class above selected player, if they are playing same class , add it to counter (playerClassRank)

            for ( int i = 0; i < currentPlayer.Entries[_playerCharacter].Rank; i++)
            {
                if (playersAbove.Entries[i].Character.Class == currentPlayer.Entries[_playerCharacter].Character.Class)
                {
                    playerClassRank++;
                }
            }

            // Player level
            int playerLevel = currentPlayer.Entries[_playerCharacter].Character.Level;

            // Player experience
            double playerExperience = currentPlayer.Entries[_playerCharacter].Character.Experience;

            //Player % exp , rounded to two decimal places
            double playerPercentageExperience = Math.Round(playerExperience / ExperienceTable.level[playerLevel] * 100, 2);

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

            var playerBehindAndAbove = GetDataFromApi.GetDataOfPlayerAboveAndBehind(_leagueName, offset);

            double playerBehindExp = playerExperience - playerBehindAndAbove.Entries[2].Character.Experience;
            double playerAboveExp;

            if (currentPlayer.Entries[_playerCharacter].Rank == 1)
            {
                playerAboveExp = 0;
            }
            else
                playerAboveExp = currentPlayer.Entries[_playerCharacter].Character.Experience - playerBehindAndAbove.Entries[0].Character.Experience;


            // playerClass
            // playerCharacter
            // playerLeague
            // playerGlobalRank
            string s_playerGlobalRank;
            // playerClassRank
            string s_playerClassRank;
            // playerLevel
            string s_playerLevel;
            // playerExperience
            string s_playerExperience;
            // playerPercentageExperience
            string s_playerPercentageExperience;
            // playerAboveExp
            string s_playerAboveExp;
            // playerBehindExp
            string s_playerbehindExp;
        }
    }
}
