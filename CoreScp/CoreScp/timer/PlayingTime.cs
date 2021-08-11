/*using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CoreEssential.timer
{
    internal class PlayingTime : IScript
    {


        [Target(GameSourceEvent.PlayerReady, ExecutionMode.Event)]
        public void CountTime(ShPlayer player ,float playtime)
        {
            player.svPlayer.StartCoroutine((string)makeTime(player, playtime));
        }
        private IEnumerable makeTime(ShPlayer player, float playtime)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1);
                playtime = playtime + 1;
            } 
            yield break;
        }
    }
}*/
