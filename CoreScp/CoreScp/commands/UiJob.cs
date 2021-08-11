using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using BrokeProtocol.Utility.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BrokeProtocol.Utility;

namespace CoreEssential
{
    public class UiJob : IScript
    {
        public void JobList(ShPlayer player)
        {
            var jobs = BPAPI.Instance.Jobs;
            List<LabelID> options = new List<LabelID>();
            foreach (var job in jobs)
            {
                string count = job.maxCount.ToString();
                if (int.Parse(count) < 1) count = "∞";
                options.Add(new LabelID($"{job.shared.jobName} {job.members.Count}/{count}", job.shared.jobIndex.ToString()));
            }
            player.svPlayer.SendOptionMenu("métier", player.ID, "jobsMenuV3", options.ToArray(), new LabelID[1] { new LabelID("je veut ce métier", "choose Job")}, 0.25f, 0.1f, 0.75f, 0.9f
            );
        }

        public void clearinventorylocal(ShPlayer player)
        {
            foreach (var item in player.myItems.ToList())
            {
                player.TransferItem(DeltaInv.RemoveFromMe, item.Key);
            }
        }

        [Target(GameSourceEvent.PlayerOptionAction, ExecutionMode.Event)]
        public void OnOptionAction(ShPlayer player, int targetID, string menuID, string optionID, string actionID)
        {
            if (menuID != "jobsMenuV3" || actionID != "choose Job") return;
            if (byte.TryParse(optionID, out byte value))
            {
                byte[] whitelist = new byte[] { 2, 3, 5, 7, 8, 9, 10, 11, 12, 13 , 14 , 15 ,16 };
                var Group = player.svPlayer.HasPermission("scp.jobpay");
                JobInfo job = BPAPI.Instance.Jobs.First(x => x.shared.jobIndex == byte.Parse(optionID));
                if (!whitelist.Any(x => x == value) && player.svPlayer.godMode == false)
                {
                    clearinventorylocal(player);
                    player.svPlayer.SendGameMessage("bienvenu dans le scp fondation");
                    player.svPlayer.SvTrySetJob(byte.Parse(optionID), true, false);
                    switch (byte.Parse(optionID))
                    {
                        case 0:
                            player.svPlayer.SvUpdateDisplayName($"{player.username} {player.ID}");
                            break;
                        //class d
                        case 1:
                            Vector3 pos = new Vector3(-544.375f, 36, 206);
                            Quaternion quaternion = new Quaternion(-544.375f, 36, 206, 55);
                            player.svPlayer.SvRestore(pos, quaternion, placeIndex: 0);
                            player.svPlayer.SvUpdateDisplayName($"Class-D {player.ID.ToString()}");
                            player.svPlayer.SendTextMenu("Class-D", "bonjour class-D, tu à était transférer dans la fondation suite au au contrat que tu à signer, tu doit écouter les chercheur et suivre les ordres donner par ces dernier", xMin: 0.25f, yMin: 0.1f, xMax: 0.75f, yMax: 0.9f);
                            break;
                        //guarde
                        case 6:
                            Vector3 pos1 = new Vector3(-367, 36.1f, 253.1f);
                            Quaternion quaternion1 = new Quaternion(-293.97f, -43.25f, 188.72f, 55);
                            player.svPlayer.SvRestore(pos1, quaternion1, placeIndex: 0);    
                            player.svPlayer.SvUpdateDisplayName($"Garde-{player.username}");
                            break;
                        //scientific
                        case 4:
                            Vector3 pos2 = new Vector3(-357, 36, 57f);
                            Quaternion quaternion2 = new Quaternion(-293.97f, 36, 188.72f, 55);
                            player.svPlayer.SvRestore(pos2, quaternion2, placeIndex: 0);
                            player.svPlayer.SvUpdateDisplayName($"Scientifique-&4{player.username}");
                            break; 
                    }
                }
                else if (Group == true)
                {
                    player.svPlayer.SvTrySetJob(byte.Parse(optionID), true, false);
                    player.svPlayer.SendGameMessage("welcome to the scp fondation");
                    switch (byte.Parse(optionID))
                    {
                       case 2:
                            Vector3 pos = new Vector3(-293.97f, 36, 188.72f);
                            Quaternion quaternion = new Quaternion(-293.97f, 36, 188.72f, 55);
                            player.svPlayer.SvRestore(pos, quaternion, placeIndex: 0);
                            player.svPlayer.SvUpdateDisplayName($"insurection du chaos-{player.username}");
                            break;
                        case 7:
                            Vector3 pos3 = new Vector3(-293.97f, 36, 188.72f);
                            Quaternion quaternion3 = new Quaternion(-293.97f, 36, 188.72f, 55);
                            player.svPlayer.SvRestore(pos3, quaternion3, placeIndex: 0);
                            player.svPlayer.SvUpdateDisplayName($"insurection du chaos-{player.username}");
                            break;
                        case 11:
                            player.svPlayer.SvGodMode();
                            break;
                    }
                }
                else
                {
                    player.svPlayer.SendGameMessage("&4job whitelist");
                    player.svPlayer.SendTextMenu("White List", "les métier sont whitelists, pour y accéder, passe ta whitelist avec le /whitelist", xMin: 0.25f, yMin: 0.1f, xMax: 0.75f, yMax: 0.9f);
                }
            }
        }

        public UiJob()
        {
            CommandHandler.RegisterCommand("job", new Action<ShPlayer>(this.JobList), null, null);
        }
    }
}