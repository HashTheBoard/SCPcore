using System;
using System.Linq;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;

namespace CoreEssential.commands
{
    class InventoryManage : IScript
    {
        public InventoryManage()
        {
            CommandHandler.RegisterCommand("clearinventory", new Action<ShPlayer, ShPlayer>(clearinventory), null, null);
            CommandHandler.RegisterCommand("invsee", new Action<ShPlayer, ShPlayer>(invsee), null, null);
        }

        public void clearinventory(ShPlayer player, ShPlayer other)
        {
            foreach(var item in other.myItems.ToList())
            {
                other.TransferItem(DeltaInv.RemoveFromMe, item.Key);
            }
            player.svPlayer.SendGameMessage("tu à bien clear" + other.username + "tout les items de son inventaire");
            other.svPlayer.SendGameMessage("tu à était clear de ton inventaire");
        }

        public void invsee(ShPlayer player, ShPlayer other)
        {
           
           player.svPlayer.SendTextMenu("l'inventaire de" + other,$"le jouer {other.username} a pour items: {other}");
        }
    }
}
