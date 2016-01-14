#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.svrPackets;
using wServer.realm.entities;

#endregion

namespace wServer.logic.taunt
{
    internal class RandomTaunt : TauntBase
    {
        private readonly double prob;

        private readonly Random rand = new Random();
        private readonly string taunt;

        public RandomTaunt(double prob, string taunt)
        {
            this.prob = prob;
            this.taunt = taunt;
        }

        protected override bool TickCore(RealmTime time)
        {
            if (rand.NextDouble() > prob) return false;
            Taunt(taunt, false);
            return true;
        }
    }
}