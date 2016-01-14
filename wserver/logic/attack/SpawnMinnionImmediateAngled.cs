using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.realm.entities;
using wServer.svrPackets;

namespace wServer.logic.attack
{
    class SpawnMinnionImmediateAngled : Behavior
    {
        float angle;
        float range;
        short objType;
        int minCount;
        int maxCount;
        private SpawnMinnionImmediateAngled(float angle, float range, short objType, int minCount, int maxCount)
        {
            this.angle = angle;
            this.range = range;
            this.objType = objType;
            this.minCount = minCount;
            this.maxCount = maxCount;
        }
        static readonly Dictionary<Tuple<float, float, short, int, int>, SpawnMinnionImmediateAngled> instances = new Dictionary<Tuple<float, float, short, int, int>, SpawnMinnionImmediateAngled>();
        public static SpawnMinnionImmediateAngled Instance(float angle, float range, short objType, int minCount, int maxCount)
        {
            var key = new Tuple<float, float, short, int, int>(angle, range, objType, minCount, maxCount);
            SpawnMinnionImmediateAngled ret;
            if (!instances.TryGetValue(key, out ret))
                ret = instances[key] = new SpawnMinnionImmediateAngled(angle, range, objType, minCount, maxCount);
            return ret;
        }

        Random rand = new Random();
        protected override bool TickCore(RealmTime time)
        {
            var chr = Host as Character;
            Position target = new Position()
            {
                X = Host.Self.X,
                Y = Host.Self.Y
            };
            target.X += (float)Math.Cos(angle) * range;
            target.Y += (float)Math.Sin(angle) * range;

            int count = rand.Next(minCount, maxCount + 1);
            for (int i = 0; i < count; i++)
            {
                Entity entity = Entity.Resolve(objType);
                entity.Move(target.X, target.Y);
                (entity as Enemy).Terrain = (chr as Enemy).Terrain;
                Host.Self.Owner.EnterWorld(entity);
            }
            return true;
        }
    }
}
