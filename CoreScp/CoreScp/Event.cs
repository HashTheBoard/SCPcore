using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Managers;
using System.Linq;
using UnityEngine;
using CoreEssential.commands;

namespace CoreEssential
{
    class Event
    {
        [Target(GameSourceEvent.PlayerReady, ExecutionMode.Event)]
        public void PlayerJoinEvent(ShPlayer player, InventoryManage inventory)
        {
            Vector3 pos = new Vector3(-544.375f, 36, 206);
            Quaternion quaternion = new Quaternion(-544.375f, 36, 206, 55);
            player.svPlayer.SvRestore(pos, quaternion, placeIndex: 0);
            player.svPlayer.SvTrySetJob(jobIndex: 1, true, false);
            player.svPlayer.SvUpdateDisplayName(player.ID.ToString() + " " + player.username);
            inventory.clearinventory(player, player);
        }

        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void environment(SvManager manager)
        {
            Color black = Color.black;
            manager.SvSetWeatherFraction(0f);
            manager.SvSetDayFraction(1.30f);
            manager.SvSetSkyColor(black);
        }
    }
}