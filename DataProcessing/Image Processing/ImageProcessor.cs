using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DataProcessing
{
    public class ImageProcessor
    {
        public static BitmapImage CheckPlayerClass(string playerClass)
        {
            // Selecting player class avatar

            switch (playerClass)
            {
                case "Champion":
                    var championAvatar = new Uri(@"Image Processing\Ascendancy Avatars\duelist_champion_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(championAvatar);

                case "Gladiator":
                    var gladiatorAvatar = new Uri(@"Ascendancy Avatars\duelist_gladiator_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(gladiatorAvatar);

                case "Slayer":
                    var slayerAvatar = new Uri(@"Image Processing\Ascendancy Avatars\duelist_slayer_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(slayerAvatar);

                case "Berserker":
                    var berserkerAvatar = new Uri(@"Image Processing\Ascendancy Avatars\marauder_berserker_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(berserkerAvatar);

                case "Chieftain":
                    var chieftainAvatar = new Uri(@"Image Processing\Ascendancy Avatars/marauder_chieftain_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(chieftainAvatar);

                case "Juggernaut":
                    var juggernautAvatar = new Uri(@"Image Processing\Ascendancy Avatars/marauder_juggernaut_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(juggernautAvatar);

                case "Deadeye":
                    var deadeyeAvatar = new Uri(@"Image Processing\Ascendancy Avatars/ranger_deadeye_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(deadeyeAvatar);

                case "Pathfinder":
                    var pathfinderAvatar = new Uri(@"Image Processing\Ascendancy Avatars/ranger_pathfinder_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(pathfinderAvatar);

                case "Raider":
                    var raiderAvatar = new Uri(@"Image Processing\Ascendancy Avatars/ranger_raider_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(raiderAvatar);

                case "Ascendant":
                    var ascendantAvatar = new Uri(@"Image Processing\Ascendancy Avatars/scion_ascendant_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(ascendantAvatar);

                case "Assassin":
                    var assassinAvatar = new Uri(@"Image Processing\Ascendancy Avatars/shadow_assassin_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(assassinAvatar);

                case "Saboteur":
                    var saboteurAvatar = new Uri(@"Image Processing\Ascendancy Avatars/shadow_saboteur_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(saboteurAvatar);

                case "Trickster":
                    var tricksterAvatar = new Uri(@"Image Processing\Ascendancy Avatars/shadow_trickster_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(tricksterAvatar);

                case "Guardian":
                    var guardianAvatar = new Uri(@"Image Processing\Ascendancy Avatars/templar_guardian_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(guardianAvatar);

                case "Hierophant":
                    var hierophantAvatar = new Uri(@"Image Processing\Ascendancy Avatars/templar_hierophant_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(hierophantAvatar);

                case "Inquisitor":
                    var inquisitorAvatar = new Uri(@"Image Processing\Ascendancy Avatars/templar_inquisitor_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(inquisitorAvatar);

                case "Elementalist":
                    var elementalistAvatar = new Uri(@"Image Processing\Ascendancy Avatars\witch_elementalist_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(elementalistAvatar);

                case "Necromancer":
                    var necromancerAvatar = new Uri(@"Image Processing\Ascendancy Avatars/witch_necromancer_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(necromancerAvatar);

                case "Occultist":
                    var occultistAvatar = new Uri(@"Image Processing\Ascendancy Avatars/witch_occultist_ascendancy.png", UriKind.Relative);
                    return new BitmapImage(occultistAvatar);

                default:
                    return null;
            }
        }
    }
}
