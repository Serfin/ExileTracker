using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataProcessing
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Try loading leagues when player is turning on app
            // Disable player character selection comboBox and start tracking button

            playerCharacters_comboBox.IsEnabled = false;
            startTrackingButton.IsEnabled = false;

            try
            {
                LoadLeagueNames();
            }
            catch (WebException)
            {
                MessageBox.Show("Path of Exile API is not responding");
            }
        }
        private void LoadLeagueNames()
        {
            // Get all main league from API, loop through array containing
            // league ID's and add them to comboBox

            var leagueDataResult = GetDataFromApi.GetLeagueData();

            leagueName_comboBox.Items.Clear();

            for (int i = 0; i < leagueDataResult.Count; i++)
            {
                leagueName_comboBox.Items.Add(leagueDataResult[i].Id);
            }
        }
        private void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Get data from Player IGN textBox
            string playerIGN = playerIGN_textbox.Text;

            // Get data from Player league comboBox
            string leagueName = Convert.ToString(leagueName_comboBox.SelectedItem);

            if (string.IsNullOrWhiteSpace(playerIGN) || playerIGN.StartsWith(" ") || string.IsNullOrWhiteSpace(leagueName))
            {
                MessageBox.Show("Please check your Player IGN");
            }
            else if (string.IsNullOrWhiteSpace(leagueName))
            {
                MessageBox.Show("Please check your League field");
            }
            else
            {
                // Adding player characters to clear comboBox
                playerCharacters_comboBox.Items.Clear();

                var currentPlayer = GetDataFromApi.GetPlayerData(playerIGN, leagueName);
                for (int i = 0; i < currentPlayer.Entries.Count(); i++)
                {
                    if (currentPlayer.Entries[i].Dead == true)
                    {
                        playerCharacters_comboBox.Items.Add($"{currentPlayer.Entries[i].Character.Name} ({currentPlayer.Entries[i].Character.Class}) DEAD");
                    }
                    else
                    {
                        playerCharacters_comboBox.Items.Add($"{currentPlayer.Entries[i].Character.Name} ({currentPlayer.Entries[i].Character.Class})");
                    }
                }

                // After receiving player characters, allow user to select character and start tracking

                playerCharacters_comboBox.IsEnabled = true;
                startTrackingButton.IsEnabled = true;
            }
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadLeagueNames();
            }
            catch (WebException)
            {
                MessageBox.Show("Path of Exile API is not responding");
            }
        }

        private void StartTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(playerCharacters_comboBox.Text))
            {
                MessageBox.Show("Select character from player characters list");
            }
            else
            {
                DataProcessor dataProcessor = new DataProcessor();
                dataProcessor.ProcessData
                    (
                        playerIGN_textbox.Text,
                        leagueName_comboBox.SelectedItem.ToString(),
                        playerCharacters_comboBox.SelectedIndex
                    );
            }
        }
    }
}