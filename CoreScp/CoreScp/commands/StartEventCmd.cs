using BrokeProtocol.API;
using BrokeProtocol.Managers;
using System;

namespace CoreEssential.commands
{
    internal class StartEventCmd : IScript
    {
        public StartEventCmd()
        {
            CommandHandler.RegisterCommand("breach", new Action<SvManager>(this.breach), null, null);
            CommandHandler.RegisterCommand("stopbreach", new Action<SvManager>(this.stopbreach), null, null);
        }

        public void breach(SvManager manager)
        {
            manager.SvSetDayFraction(1.50f);
            ChatHandler.SendToAll("&4Début d'une breach de confinement !");
        }

        public void stopbreach(SvManager manager)
        {
            manager.SvSetDayFraction(1.30f);
            ChatHandler.SendToAll("&4fin de la breach !");
        }
    }
}