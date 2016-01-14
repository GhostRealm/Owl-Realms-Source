using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class ElderTombMap : World
    {
        public ElderTombMap()
        {
            Name = "Elder Tomb of the Ancients";
            Background = 0;
            Random r = new Random();
            AllowTeleport = false;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.eldertomb.wmap"));  
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new ElderTombMap());
        }
    }
}
