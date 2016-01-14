﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class OceanTrench : World
    {
        public OceanTrench()
        {
            Name = "Ocean Trench";
            Background = 0;
            Random r = new Random();
            AllowTeleport = true;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.oceantrench" + r.Next(1, 6 + 1).ToString() + ".wmap"));             
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new OceanTrench());
        }
    }
}
