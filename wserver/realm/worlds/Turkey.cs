using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class TurkeyMap : World
    {
        public TurkeyMap()
        {
            Name = "Turkey Hunting Grounds";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(
                typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.turkey.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new TurkeyMap());
        }
    }
}