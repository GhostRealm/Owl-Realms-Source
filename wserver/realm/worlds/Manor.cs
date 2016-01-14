using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class Manor : World
    {
        public Manor()
        {
            Name = "Manor of the Immortals";
            Background = 0;
            Random r = new Random();
            AllowTeleport = true;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.manor" + r.Next(1, 3 + 1).ToString() + ".wmap"));     
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new Manor());
        }
    }
}
