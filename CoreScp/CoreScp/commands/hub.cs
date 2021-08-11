using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;
using UnityEngine;

namespace CoreEssential.commands
{
    internal class hub : IScript
    {
        public hub()
        {
            CommandHandler.RegisterCommand("hub", new Action<ShPlayer>(this.hubhandler), null, null);
            CommandHandler.RegisterCommand("recrutement", new Action<ShPlayer>(this.staffrecruit), null, null);
            CommandHandler.RegisterCommand("whitelist", new Action<ShPlayer>(this.whitelist), null, null);
        }

        public void staffrecruit(ShPlayer player)
        {
            player.svPlayer.SvOpenURL("https://forms.gle/vqzH3o4XJ7U1C5Xw9");
        }

        public void whitelist(ShPlayer player)
        {
            player.svPlayer.SvOpenURL("https://forms.gle/cgejYRSqB1JnWt2BA");
        }

        public void hubhandler(ShPlayer player)
        {
            Vector3 pos1 = new Vector3(-11, 1, -27);
            Quaternion quaternion1 = new Quaternion(-11, 1, -27, 55);
            player.svPlayer.SvRestore(pos1, quaternion1, placeIndex: 0);
        }
    }
}