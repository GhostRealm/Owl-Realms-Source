using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class SnakePit : World
    {
        public SnakePit()
        {
            Name = "Snake Pit";
            Background = 0;
            Random r = new Random();
            AllowTeleport = true;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.snakepit" + r.Next(1, 2 + 1).ToString() + ".wmap"));           
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new SnakePit());
        }
    }
}