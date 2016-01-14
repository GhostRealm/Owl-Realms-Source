#region

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

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ Towers = Behav()
            .Init(0x140b, Behaves("Tower1",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x140c, Behaves("Tower2",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x140d, Behaves("Tower3",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x140e, Behaves("Tower4",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x140f, Behaves("Tower5",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x141a, Behaves("Tower6",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x141b, Behaves("Tower7",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x141c, Behaves("Tower8",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x141d, Behaves("Tower9",
                new RunBehaviors(
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, 0))
                    )
                ))
            .Init(0x5035, Behaves("SpecialTower",
                new RunBehaviors(
                    Cooldown.Instance(100, PetSimpleAttack.Instance(15, 0))
                    )
                ))
            ;
    }
}