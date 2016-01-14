#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;
using System.Net;
using terrain;

#endregion

namespace wServer.realm.worlds
{
    public class XmlWorld : World
    {
        private readonly DungeonDesc _d;

        public XmlWorld(DungeonDesc desc)
        {
            _d = desc;
            var json = new WebClient().DownloadString(desc.Json);

            Name = desc.Name;
            Background = desc.Background;
            AllowTeleport = desc.AllowTeleport;
            base.FromWorldMap(new MemoryStream(Json2Wmap.Convert(json)));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new XmlWorld(_d));
        }
    }
}