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
        private static _ Undead = Behav()
            .Init(0x3f09, Behaves("Undead Monster",
                new RunBehaviors(
                    Chasing.Instance(4, 100, 100, 0x3f0a)
                    )))
            .Init(0x3f0a, Behaves("Undead Bait",
                new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invincible))
                    )
                ));
    }
}