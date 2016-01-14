﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class ArenaMap : World
    {
        public ArenaMap()
        {
            Id = ARENA;
            Name = "Arena";
            Background = 1;
            AllowTeleport = true;
            base.FromWorldMap(typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.arena.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new ArenaMap());
        }
    }
}