//all behaviors is custom --------- :D
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
        static LootDef CandyLoot =            //Drop Rate
            new LootDef(0, 7, 0, 4,
                    Tuple.Create(0.02, (ILoot)new ItemLoot("Potion of Defense")),
                    Tuple.Create(0.02, (ILoot)new ItemLoot("Potion of Attack")),
                    Tuple.Create(0.3, (ILoot)new ItemLoot("Yellow Gumball")),
                    Tuple.Create(0.3, (ILoot)new ItemLoot("Green Gumball")),
                    Tuple.Create(0.3, (ILoot)new ItemLoot("Blue Gumball")),
                    Tuple.Create(0.3, (ILoot)new ItemLoot("Red Gumball")),
                    Tuple.Create(0.3, (ILoot)new ItemLoot("Purple Gumball")),
                    //Tuple.Create(0.009, (ILoot) new ItemLoot("Fairy Playe")),
                    Tuple.Create(0.009, (ILoot)new ItemLoot("Pixie-Enchanted Sword")),
                    //Tuple.Create(0.009, (ILoot) new ItemLoot("Seal of the Enchanted Forest")),
                    Tuple.Create(0.01, (ILoot)new ItemLoot("Candy-Coated Armor")),
                    Tuple.Create(0.01, (ILoot)new ItemLoot("Wine Cellar Incantation")),
                    Tuple.Create(0.005, (ILoot)new ItemLoot("Potion of Defense")),
                    Tuple.Create(0.005, (ILoot)new ItemLoot("Potion of Attack"))
               );
        static _ CandyLand = Behav()
        .Init(0x5e46, Behaves("Desire Troll",
                    SimpleWandering.Instance(5),
                    new RunBehaviors(
                    Cooldown.Instance(3000, ThrowAttack.Instance(6, 8, 200)),
                    new QueuedBehavior(
                    Cooldown.Instance(2100, PredictiveMultiAttack.Instance(15, 5 * (float)Math.PI / 180, 3, 1, 0)),
                    Cooldown.Instance(1950, PredictiveMultiAttack.Instance(15, 10 * (float)Math.PI / 180, 5, 1, 2)),
                    Cooldown.Instance(1950, PredictiveMultiAttack.Instance(15, 0 * (float)Math.PI / 180, 1, 1, 1))
                )),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(1, CandyLoot),
                Tuple.Create(100, new LootDef(0, 7, 0, 4,
                    Tuple.Create(0.04, (ILoot)new TierLoot(6, ItemType.Weapon)),
                    Tuple.Create(0.02, (ILoot)new TierLoot(7, ItemType.Weapon)),
                    Tuple.Create(0.01, (ILoot)new TierLoot(8, ItemType.Weapon)),
                    Tuple.Create(0.04, (ILoot)new TierLoot(7, ItemType.Armor)),
                    Tuple.Create(0.02, (ILoot)new TierLoot(8, ItemType.Armor)),
                    Tuple.Create(0.01, (ILoot)new TierLoot(9, ItemType.Armor)),
                    Tuple.Create(0.015, (ILoot)new TierLoot(3, ItemType.Ring)),
                    Tuple.Create(0.005, (ILoot)new TierLoot(4, ItemType.Ring))
                   )))
                   ))
        .Init(0x5e44, Behaves("Gigacorn",
                    SimpleWandering.Instance(5),
                    Cooldown.Instance(4000, Charge.Instance(2, 10, null)),
                    new RunBehaviors(
                    Cooldown.Instance(2100, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 1)),
                    Cooldown.Instance(2200, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 1)),
                    Cooldown.Instance(2300, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 1)),
                    Cooldown.Instance(2400, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 1)),
                    Cooldown.Instance(4000, PredictiveMultiAttack.Instance(20, 15 * (float)Math.PI / 180, 3, 1, 0)),
                    Cooldown.Instance(2000, PredictiveMultiAttack.Instance(20, 15 * (float)Math.PI / 180, 3, 1, 0))

                ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(1, CandyLoot),
                Tuple.Create(100, new LootDef(0, 7, 0, 4,
                    Tuple.Create(0.04, (ILoot)new TierLoot(6, ItemType.Weapon)),
                    Tuple.Create(0.02, (ILoot)new TierLoot(7, ItemType.Weapon)),
                    Tuple.Create(0.01, (ILoot)new TierLoot(8, ItemType.Weapon)),
                    Tuple.Create(0.04, (ILoot)new TierLoot(7, ItemType.Armor)),
                    Tuple.Create(0.02, (ILoot)new TierLoot(8, ItemType.Armor)),
                    Tuple.Create(0.01, (ILoot)new TierLoot(9, ItemType.Armor)),
                    Tuple.Create(0.015, (ILoot)new TierLoot(3, ItemType.Ring)),
                    Tuple.Create(0.005, (ILoot)new TierLoot(4, ItemType.Ring))
                )))
                   ))
        .Init(0x5e47, Behaves("Spoiled Creampuff", 
                        MaintainDist.Instance(4, 10, 7, null),
                        Cooldown.Instance(4000, ReturnSpawn.Instance(4)),
                                new RunBehaviors(
                                    Cooldown.Instance(1500, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 0)),
                                    Cooldown.Instance(1000, PredictiveMultiAttack.Instance(20, 15 * (float)Math.PI / 180, 5, 1, 1)),
                                    Once.Instance(SpawnMinionImmediate.Instance(0x5e35, 3, 2, 3)
                                    )),
                                        loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(1, CandyLoot),
                Tuple.Create(100, new LootDef(0, 7, 0, 4,
                    Tuple.Create(0.04, (ILoot)new TierLoot(6, ItemType.Weapon)),
                    Tuple.Create(0.02, (ILoot)new TierLoot(7, ItemType.Weapon)),
                    Tuple.Create(0.01, (ILoot)new TierLoot(8, ItemType.Weapon)),
                    Tuple.Create(0.04, (ILoot)new TierLoot(7, ItemType.Armor)),
                    Tuple.Create(0.02, (ILoot)new TierLoot(8, ItemType.Armor)),
                    Tuple.Create(0.01, (ILoot)new TierLoot(9, ItemType.Armor)),
                    Tuple.Create(0.015, (ILoot)new TierLoot(3, ItemType.Ring)),
                    Tuple.Create(0.005, (ILoot)new TierLoot(4, ItemType.Ring))
                )))
                       ))
                .Init(0x5e35, Behaves("Big Creampuff",
                        SimpleWandering.Instance(5),
                                new RunBehaviors(
                                    Cooldown.Instance(1500, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 0)),
                                    Cooldown.Instance(1000, PredictiveMultiAttack.Instance(20, 15 * (float)Math.PI / 180, 5, 1, 1)),
                                    Once.Instance(SpawnMinionImmediate.Instance(0x5e34, 3, 2, 3)
                                    ))))
                    .Init(0x5e34, Behaves("Small Creampuff",
                        SimpleWandering.Instance(5),
                                new RunBehaviors(
                                    Cooldown.Instance(1500, PredictiveMultiAttack.Instance(20, 40 * (float)Math.PI / 180, 1, 1, 0))
                                    )));
    }
}