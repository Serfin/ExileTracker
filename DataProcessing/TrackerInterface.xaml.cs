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

            ascendancyAvatar.Source = ImageProcessor.CheckPlayerClass(playerClass);
            playerName_Label.Content = playerCharacter;
            leagueName_Label.Content = playerLeague;
            playerLvl_Label.Content = "LVL " + playerLevel;
            playerClassRank_Label.Content = playerClassRank;
            playerGlobalRank_Label.Content = playerGlobalRank;
            playerExperience_Label.Content = $"{playerExperience}/{ExperienceTable.level[playerLevel]} ({playerPercentageExperience}%)";

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
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
