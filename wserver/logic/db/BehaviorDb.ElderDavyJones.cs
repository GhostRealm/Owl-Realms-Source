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
        private static _ ElderDavyJones = Behav()
            .Init(0x7e32, Behaves("Elder Davy Jones",
                new RunBehaviors(
                    Once.Instance(SetSize.Instance(0)),
                    If.Instance(IsEntityPresent.Instance(6, null), Once.Instance(new SetKey(-1, 1))),
                    IfEqual.Instance(-1, 1,
                        new RunBehaviors(
                            new QueuedBehavior(
                                SetAltTexture.Instance(4),
                                CooldownExact.Instance(125),
                                SetSize.Instance(25),
                                CooldownExact.Instance(125),
                                SetSize.Instance(50),
                                CooldownExact.Instance(125),
                                SetSize.Instance(75),
                                CooldownExact.Instance(125),
                                SetSize.Instance(100),
                                new SetKey(-1, 2)
                                ))),
                    IfEqual.Instance(-1, 2,
                        new RunBehaviors(
                            If.Instance(IsEntityNotPresent.Instance(100, 0x0e35),
                                new SetKey(-1, 3)
                                ),
                            If.Instance(IsEntityPresent.Instance(100, 0x0e35),
                                new SetKey(-1, 4)
                                )
                            ))),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 5, 0, 10,
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Spirit Dagger")),
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Spectral Cloth Armor")),
                     Tuple.Create(0.1, (ILoot)new ItemLoot("Large Purple Bones Cloth")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Small Purple Bones Cloth")),
                            Tuple.Create(0.03, (ILoot)new ItemLoot("Pirate King's Cutlass")),
                      //      Tuple.Create(0.03, (ILoot)new ItemLoot("Doom Cannon")),
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Ghostly Prism")),
                        Tuple.Create(0.99, (ILoot) new ItemLoot("Potion of Wisdom")),
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Captain's Ring"))
                        ))
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathPortal(0x0704, 100, -1)
                })
            );
    }
}