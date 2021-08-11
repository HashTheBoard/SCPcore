using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;
using UnityEngine;

namespace CoreEssential.commands
{
    internal class GoTeleport : IScript
    {
        public GoTeleport()
        {
            CommandHandler.RegisterCommand("Go", new Action<ShPlayer, String>(this.hubhandler), null, null);
            CommandHandler.RegisterCommand("Golist", new Action<ShPlayer>(this.golist), null, null);
        }

        public void golist(ShPlayer player)
        {
            player.svPlayer.SendMessage("voici la list des tp: outside, lightzone");
        }

        public void hubhandler(ShPlayer player, String where)
        {
            if (where == "outside")
            {
                Vector3 pos1 = new Vector3(364.625f, 57.5f, -9.75f);
                Quaternion quaternion1 = new Quaternion(364.625f, 57.5f, -9.75f, 55);
                player.svPlayer.SvRestore(pos1, quaternion1, placeIndex: 0);
            }
            if (where == "lightzone")
            {
                Vector3 pos = new Vector3(-544.375f, -42, 206);
                Quaternion quaternion = new Quaternion(-544.375f, -43, 206, 55);
                player.svPlayer.SvRestore(pos, quaternion, placeIndex: 2);
            }
        }
    }
}