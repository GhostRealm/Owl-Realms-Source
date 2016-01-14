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
        
        static _ HPets = Behav()
            .InitMany(0x5600, 0x5661, Behaves("Pet",
                     If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3),
                     Cooldown.Instance(2400, new NexusHealHp()
                        
                            ))
            ));
    }
}
