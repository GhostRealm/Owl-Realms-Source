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
        static LootDef CPetBag =
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
        
        static _ COryxpet = Behav()
            .Init(0x4d84, Behaves("Christmas Oryx Pet",   //I WIN!!
                    SimpleWandering.Instance(1),
                    loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(1, new LootDef(100, 30, 38, 36,
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Potion of Oryx")),
                            Tuple.Create(0.3, (ILoot)new TierLoot(14, ItemType.Weapon)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(15, ItemType.Weapon)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(15, ItemType.Armor)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(16, ItemType.Armor)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(7, ItemType.Ability)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(8, ItemType.Ability)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(9, ItemType.Ability)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(5, ItemType.Ring)),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Hide Robe")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Hide Armor")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Scale Armor")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Ring of Oryx")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Backpack")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Dagger of the Mallard King")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Amulet of the Mallard King")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Cloak of the Mallard")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Mallard Hide")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Shroom Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Aceaku's Pet Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Kythal the Skull Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Drake Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Scootaloo Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Astro's Griffin Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Dallas's Pet Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Josh's Pet Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Skeletal Guardian Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Twilight Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Lunar's Phoenix Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Knight Generator")),
                            Tuple.Create(0.09, (ILoot)new ItemLoot("Crown")),
                            Tuple.Create(0.2, (ILoot)new StatPotionsLoot(1, 2, 3))
                        ))
                    )
                ));
    }
}