using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.IO;

namespace CoreEssential
{
    public class Core : Plugin
    {
        public Core()
        {
            Info = new PluginInfo("CoreScpByYa80", "scp")
            {
                Description = "voici mon core scp pour mon serveur scp",
                Website = "https://terratech-heberg.fr"
            };
            LoadConfig();
        }

        public void writeconfig()
        {
            var test = 1;
        }

        public void keepinventory(ShPlayer player)
        {
            //player
        }

        public void LoadConfig()
        {
            if (!File.Exists("Plugins/settings/CoreEssential/settings.json"))
            {
                if (!Directory.Exists("Plugins/settings/CoreEssential"))
                {
                    Directory.CreateDirectory("Plugins/settings/CoreEssential");
                    File.WriteAllText("Plugins/settings/CoreEssential/settings.json", "cette configuration fonctionne !" + "ip of players :");
                }
            }
            string read = File.ReadAllText("Plugins/settings/CoreEssential/settings.json");
        }
    }
}