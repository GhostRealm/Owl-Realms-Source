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
        static _ Egg = Behav()
            .Init(0x0e18, Behaves("April Fools Egg",
            new RunBehaviors(
                 HpLesser.Instance(630000,
                     SetAltTexture.Instance(1)),
                     HpLesser.Instance(610000,
                     SetAltTexture.Instance(2)),
                     HpLesser.Instance(590000,
                     SetAltTexture.Instance(3)),
                     HpLesser.Instance(570000,
                     SetAltTexture.Instance(4))
                     ),
                         new QueuedBehavior(
                         HpLesser.Instance(569999,
                       Once.Instance(SpawnMinionImmediate.Instance(0x0e17, 1, 1, 1))
                       ))
                     ))
                     .Init(0x0e17, Behaves("April Fools Chicken",
                     new RunBehaviors(
                         SimpleWandering.Instance(1, 2f),
                         OrderAllEntity.Instance(20, 0x0e18, Despawn.Instance),
                         Cooldown.Instance(400, (MultiAttack.Instance(5, 0, 2, projectileIndex: 1))),
                         Cooldown.Instance(4000, (RingAttack.Instance(4, 0, 2, projectileIndex: 2))),
                         Cooldown.Instance(1000, (PredictiveMultiAttack.Instance(15, 15 * (float)Math.PI / 180, 2, 1, projectileIndex: 3))),
                         Cooldown.Instance(750, PredictiveRingAttack.Instance(5, .5f, 12, 4)),
                         Cooldown.Instance(1250, PredictiveMultiAttack.Instance(12, 10 * (float)Math.PI / 180, 5, 8))
                         ),
                        loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 2, 8,
                            Tuple.Create(0.1, (ILoot)new TierLoot(5, ItemType.Ability)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(12, ItemType.Armor)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(11, ItemType.Weapon)),

                            Tuple.Create(0.1, (ILoot)new TierLoot(4, ItemType.Ring)),

                            Tuple.Create(0.2, (ILoot)new TierLoot(4, ItemType.Ability)),
                            Tuple.Create(0.2, (ILoot)new TierLoot(11, ItemType.Armor)),
                            Tuple.Create(0.2, (ILoot)new TierLoot(10, ItemType.Weapon)),

                            Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Att)),
                            Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Wis)),
                            Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Vit)),
                            Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Def)),

                            Tuple.Create(0.3, (ILoot)new ItemLoot("Chicken Leg of Doom")),
                            Tuple.Create(0.3, (ILoot)new ItemLoot("Anatis Staff"))
                    )))
                        ));

    }
}
