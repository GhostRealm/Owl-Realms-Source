using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class OryxsChamber : World
    {
        public OryxsChamber()
        {
            Id = OCHAMBER;
            Name = "Oryxs Chamber";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(
                typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.oryxchamber.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new OryxsChamber());
        }
    }
}