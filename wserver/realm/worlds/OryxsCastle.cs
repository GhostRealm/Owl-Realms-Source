using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class OryxsCastle : World
    {
        public OryxsCastle()
        {
            Id = OCASTLE;
            Name = "Oryxs Castle";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(
                typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.oryxcastle.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new OryxsCastle());
        }
    }
}