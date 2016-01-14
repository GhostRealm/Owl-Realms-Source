using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.attack;
using wServer.logic.movement;
using wServer.logic.loot;
using wServer.logic.taunt;
using wServer.logic.cond;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        static _ BeachBum = Behav()
            .Init(0x0e55, Behaves("Beach Bum",
                new RunBehaviors(
                    SimpleWandering.Instance(1, 2f)
                ),
            loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(800, new LootDef(0, 5, 0, 8,
                            Tuple.Create(0.3, (ILoot)new ItemLoot("Davy's Key"))
                        ))
                    ),
                    condBehaviors: new ConditionalBehavior[] {
                        new DeathPortal(0x0742, 100, 30)
                    }
                ));
    }
}