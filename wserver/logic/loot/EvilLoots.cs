#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db.data;

#endregion

namespace wServer.logic.loot
{
    internal class EvilLoot : ILoot //Blood of evil hen! :D
    {
        public Item GetLoot(Random rand)
        {
            return XmlDatas.ItemDescs[0x0a22];
        }
    }
}