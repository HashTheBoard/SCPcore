using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreEssential.commands
{
    internal class CustomTempban : IScript
    {
        public static float Time1 = 0;

        public CustomTempban()
        {
            CommandHandler.RegisterCommand("supertempban", new Action<ShPlayer>(this.paneltime), null, null);
        }

        public void paneltime(ShPlayer player)
        {
            List<LabelID> options = new List<LabelID>();
            options.Add(new LabelID("&4minutes", "minutes"));
            options.Add(new LabelID("&4hours", "hours"));
            options.Add(new LabelID("&4days", "days"));
            options.Add(new LabelID("&4months", "months"));
            player.svPlayer.SendOptionMenu("&6Ban Menu", player.ID, "BanMenu", options.ToArray(), new LabelID[1] { new LabelID("ban", "ban") }, 0.25f, 0.1f, 0.75f, 0.9f);
        }

        [Target(531, ExecutionMode.Event)]
        public void paneltime2(ShPlayer player, int targetID, string menuID, string optionID, string actionID)
        {
            if (menuID != "BanMenu" || actionID != "ban") return;
            if (optionID == "minutes")
            {
                float minutes = 60 * Time1;
            }
            
        }

        public void tempban(ShPlayer player, ShPlayer other, string reason)
        {
            player.svPlayer.SvBan(other, reason);
            player.svPlayer.StartCoroutine(coroutine1(player, other, reason));
        }

        public IEnumerator coroutine1(ShPlayer player, ShPlayer other, string reason)
        {
            var ip = other.svPlayer.connection.IP;
            yield return new WaitForSecondsRealtime(Time1);
            player.svPlayer.SvUnbanIP(ip);
            yield break;
        }
    }
}