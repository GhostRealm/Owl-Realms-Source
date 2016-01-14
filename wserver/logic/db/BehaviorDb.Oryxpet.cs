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
        static LootDef PetBag =
            new LootDef(0, 2, 0, 8,
                Tuple.Create(0.20, (ILoot)new TierLoot(9, ItemType.Weapon)),
                Tuple.Create(0.05, (ILoot)new TierLoot(10, ItemType.Weapon)),
                Tuple.Create(0.03, (ILoot)new TierLoot(11, ItemType.Weapon)),

                Tuple.Create(0.20, (ILoot)new TierLoot(9, ItemType.Armor)),
                Tuple.Create(0.10, (ILoot)new TierLoot(10, ItemType.Armor)),
                Tuple.Create(0.05, (ILoot)new TierLoot(11, ItemType.Armor)),
                Tuple.Create(0.03, (ILoot)new TierLoot(12, ItemType.Armor)),

                Tuple.Create(0.15, (ILoot)new TierLoot(4, ItemType.Ring)),
                Tuple.Create(0.05, (ILoot)new TierLoot(5, ItemType.Ring)),
                Tuple.Create(0.20, (ILoot)new TierLoot(5, ItemType.Ability))
            );
        
        static _ Oryxpet = Behav()
            .Init(0x0d84, Behaves("Oryx Pet",   //I WIN!!
                    SimpleWandering.Instance(1),
                    loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(1, new LootDef(100, 1, 8, 16,
                          
                            
                         Tuple.Create(0.3, (ILoot)new TierLoot(12, ItemType.Weapon)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(13, ItemType.Armor)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(6, ItemType.Ability)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(5, ItemType.Ability)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(5, ItemType.Ring)),
                            Tuple.Create(0.3, (ILoot)new StatPotionsLoot(1, 2, 3)),
                             Tuple.Create(0.3, (ILoot)new ItemLoot("Potion of Maxy"))
                        ))
                    )
                ));
    }
}