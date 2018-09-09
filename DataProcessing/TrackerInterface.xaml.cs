using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataProcessing
{
    /// <summary>
    /// Logika interakcji dla klasy TrackerInterface.xaml
    /// </summary>
    public partial class TrackerInterface : Window
    {
        public TrackerInterface
            (
                string playerClass,
                string playerCharacter,
                string playerLeague,
                int playerGlobalRank,
                int playerClassRank,
                int playerLevel,
                double playerExperience,
                double playerPercentageExperience,
                double playerAboveExp,
                double playerBehindExp
            )
        {
            InitializeComponent();

            // Select player ascendancy avatar
            ascendancyAvatar.Source = ImageProcessor.CheckPlayerClass(playerClass);

            // Set player name
            playerName_Label.Content = playerCharacter;

            // Set player league
            leagueName_Label.Content = playerLeague;

            // Set player name
            playerLvl_Label.Content = "LVL " + playerLevel;

            // Set class rank
            playerClassRank_Label.Content = playerClassRank;

            // Set global rank
            playerGlobalRank_Label.Content = playerGlobalRank;

            // Set player experience
            if (playerLevel != 100)
            {
                playerExperience_Label.Content = $"{playerExperience}/{ExperienceTable.level[playerLevel]} ({playerPercentageExperience}%)";
            }
            else
            {
                playerExperience_Label.Content = $"{playerExperience}/{playerExperience} ({playerPercentageExperience}%)";
            }

            // Set player experience compared to player above/behind
            // If player rank is 1 , swap "Exp to rank x" with "Rank 1"
            if (playerGlobalRank == 1)
            {
                expToRankXAbove.Content = $"RANK {playerGlobalRank}";
                playerExpToRankAbove_Label.Content = "---";
                expToRankXBehind.Content = $"EXP TO RANK {playerGlobalRank + 1}";
                playerExpToRankBehind_Label.Content = playerBehindExp;
            }
            else
            {
                expToRankXAbove.Content = $"EXP TO RANK {playerGlobalRank - 1}";
                playerExpToRankAbove_Label.Content = playerAboveExp;
                expToRankXBehind.Content = $"EXP TO RANK {playerGlobalRank + 1}";
                playerExpToRankBehind_Label.Content = playerBehindExp;
            }
        }
        // Allows user to move TrackerInterface
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
