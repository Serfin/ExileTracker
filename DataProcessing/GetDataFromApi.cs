using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    public class GetDataFromApi
    {
        /// <summary>
        /// Sending request to API with params
        /// </summary>
        /// <param name="IGN">
        /// Player IGN
        /// </param>
        /// <param name="leagueName">
        /// Player leagueName
        /// </param>
        /// <returns>
        /// Deserialized object with player data
        /// </returns>

        public static RootObject GetPlayerData(string IGN, string leagueName)
        {
            string url = $"http://api.pathofexile.com/ladders/{leagueName}?limit=1&accountName={IGN}";
            var client = new WebClient();
            var json = client.DownloadString(url);
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);

            return result;
        }

        /// <summary>
        /// Sending request to API for players above specified player
        /// </summary>
        /// <param name="leagueName"></param>
        /// <param name="limit"></param>
        /// <returns></returns>

        public static RootObject GetPlayersAboveData(string leagueName, int limit, int offset)
        {
            string url = $"http://api.pathofexile.com/ladders/{leagueName}?offset={offset}&limit={limit}";
            var client = new WebClient();
            var json = client.DownloadString(url);
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);

            return result;
        }

        /// <summary>
        /// Sending request for one player above and one behind specified player
        /// </summary>
        /// <param name="leagueName"></param>
        /// <param name="offset"></param>
        /// <returns></returns>

        public static RootObject GetDataOfPlayerAboveAndBehind(string leagueName, int offset)
        {
            string url = $"http://api.pathofexile.com/ladders/{leagueName}?offset={offset}&limit=3";
            var client = new WebClient();
            var json = client.DownloadString(url);
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);

            return result;
        }

        /// <summary>
        /// Sending request for current main Leagues
        /// </summary>
        /// <returns></returns>

        public static List<LeagueData> GetLeagueData()
        {
            string url = $"http://api.pathofexile.com/leagues?type=main&compact=1";
            var client = new WebClient();
            var json = client.DownloadString(url);
            List<LeagueData> result = JsonConvert.DeserializeObject<List<LeagueData>>(json);

            return result;
        }
    }
}
