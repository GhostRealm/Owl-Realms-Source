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
        static _ EPcave = Behav()
            .Init(0x6927, Behaves("Elder Dreadstump the Pirate King",
                SmoothWandering.Instance(2f, 2f),
                  HpGreaterEqual.Instance(640, NullBehavior.Instance),
                    HpLesserPercent.Instance(0.8f,
                        new RunBehaviors(
                            Cooldown.Instance(5000, new SimpleTaunt("arrr...")),
                            Cooldown.Instance(10000, new SimpleTaunt("eat cannonballs!")),
                            Cooldown.Instance(15000, new SimpleTaunt(" I will drink my rum out of your skull!")),
                        Cooldown.Instance(500, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
//                            Cooldown.Instance(500, SimpleAttack.Instance(10, projectileIndex: 0)),
                            Cooldown.Instance(500, SimpleAttack.Instance(10, projectileIndex: 1))
                        )
                    ),
                    loot: new LootBehavior(
                        new LootDef(0, 1, 0, 8,

                            Tuple.Create(0.15, (ILoot)new TierLoot(1, ItemType.Armor)),
                            Tuple.Create(0.5, (ILoot)new TierLoot(1, ItemType.Ring)),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Monkey Generator")),

                            Tuple.Create(0.20, (ILoot)new TierLoot(2, ItemType.Armor)),
                            Tuple.Create(0.2, (ILoot)new TierLoot(2, ItemType.Weapon)),

                            Tuple.Create(0.25, (ILoot)new TierLoot(3, ItemType.Armor)),
                            Tuple.Create(0.3, (ILoot)new TierLoot(3, ItemType.Weapon)),

                            Tuple.Create(0.30, (ILoot)new TierLoot(4, ItemType.Armor)),
                            Tuple.Create(0.4, (ILoot)new TierLoot(4, ItemType.Weapon))
                            ),
                            Tuple.Create(100, new LootDef(0, 1, 0, 2,
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Pirate Rum"))
                            ))),
                        condBehaviors: new ConditionalBehavior[] {
                        new DeathPortal(0x6817, 100, 100)
                    }
            ))
            .Init(0x6687, Behaves("Elder Cave Pirate Brawler",
                IfNot.Instance(
                    Chasing.Instance(8, 11, 1, null),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.01, (ILoot)HpPotionLoot.Instance)
                            ))
            ))
            .Init(0x6688, Behaves("Elder Cave Pirate Sailor",
                IfNot.Instance(
                    Chasing.Instance(8, 11, 1, null),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.01, (ILoot)HpPotionLoot.Instance)
                            ))
            ))
            .Init(0x6689, Behaves("Elder Cave Pirate Veteran",
                IfNot.Instance(
                    Chasing.Instance(8, 11, 1, null),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.01, (ILoot)HpPotionLoot.Instance)
                            ))
            ))
            .Init(0x668f, Behaves("Elder Cave Pirate Cabin Boy",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot)new TierLoot(1, ItemType.Weapon))
                            ))
            ))
            .Init(0x668e, Behaves("Elder Cave Pirate Hunchback",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot)new TierLoot(1, ItemType.Ability))
                            ))
            ))
            .Init(0x668c, Behaves("Elder Cave Pirate Macaw",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot)new TierLoot(1, ItemType.Ability))
                            ))
            ))
            .Init(0x668a, Behaves("Elder Cave Pirate Moll",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot)new TierLoot(1, ItemType.Ability))
                            ))
            ))
            .Init(0x668d, Behaves("Elder Cave Pirate Monkey",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Monkey Generator")),
                            Tuple.Create(0.1, (ILoot)new TierLoot(1, ItemType.Ability))
                            ))
            ))
            .Init(0x668b, Behaves("Elder Cave Pirate Parrot",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot)new TierLoot(1, ItemType.Ability))
                            ))
            ))
            .Init(0x6686, Behaves("Elder Pirate Admiral",
                IfNot.Instance(
                    Circling.Instance(3, 10, 6, 0x0927),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                            new LootDef(0, 1, 0, 8,
                                Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Armor)),
                                Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Ring)),
                                Tuple.Create(0.2, (ILoot)new TierLoot(2, ItemType.Weapon)),
                                Tuple.Create(0.1, (ILoot)new TierLoot(3, ItemType.Weapon))
                                ),
                                Tuple.Create(100, new LootDef(0, 1, 0, 2,
                                Tuple.Create(0.01, (ILoot)new ItemLoot("Pirate Rum"))
                           )))
            ))
            .Init(0x6685, Behaves("Elder Pirate Captain",
                IfNot.Instance(
                    Circling.Instance(3, 10, 6, 0x0927),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                       new LootDef(0, 1, 0, 8,
                           Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Armor)),
                           Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Ring)),
                           Tuple.Create(0.2, (ILoot)new TierLoot(2, ItemType.Weapon)),
                           Tuple.Create(0.1, (ILoot)new TierLoot(3, ItemType.Weapon))
                           ),
                           Tuple.Create(100, new LootDef(0, 1, 0, 2,
                           Tuple.Create(0.01, (ILoot)new ItemLoot("Pirate Rum"))
                           )))
            ))
            .Init(0x6684, Behaves("Elder Pirate Commander",
                IfNot.Instance(
                    Circling.Instance(3, 10, 6, 0x0927),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                       new LootDef(0, 1, 0, 8,
                           Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Armor)),
                           Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Ring)),
                           Tuple.Create(0.2, (ILoot)new TierLoot(2, ItemType.Weapon)),
                           Tuple.Create(0.1, (ILoot)new TierLoot(3, ItemType.Weapon))
                           ),
                           Tuple.Create(100, new LootDef(0, 1, 0, 2,
                           Tuple.Create(0.01, (ILoot)new ItemLoot("Pirate Rum"))
                           )))
            ))
                        .Init(0x6600, Behaves("Elder Pirate",
                    IfNot.Instance(
                        Chasing.Instance(8.5f, 6, 0, null), SimpleWandering.Instance(4)),
                    Cooldown.Instance(2500, SimpleAttack.Instance(3)),
                    loot: new LootBehavior(
                        new LootDef(0, 2, 0, 8,
                            Tuple.Create(0.2, (ILoot)new TierLoot(1, ItemType.Weapon)),
                            Tuple.Create(0.03, (ILoot)HpPotionLoot.Instance)
                        )
                    )
                ))
            .Init(0x6601, Behaves("Elder Piratess",
                    IfNot.Instance(
                        Once.Instance(
                            SpawnMinionImmediate.Instance(0x600, 3, 2, 5)
                        ),
                        IfNot.Instance(
                            Chasing.Instance(11f, 6, 1, null),
                            SimpleWandering.Instance(6))
                    ),
                    Cooldown.Instance(2500, SimpleAttack.Instance(3)),
                    Rand.Instance(
                        Reproduce.Instance(0x600, 5),
                        Reproduce.Instance(0x601, 5)
                    ),
                    loot: new LootBehavior(
                        new LootDef(0, 2, 0, 8,
                            Tuple.Create(0.2, (ILoot)new TierLoot(1, ItemType.Armor)),
                            Tuple.Create(0.03, (ILoot)HpPotionLoot.Instance)
                        )
                    )
                ))
            .Init(0x6683, Behaves("Elder Pirate Lieutenant",
                IfNot.Instance(
                    Circling.Instance(3, 10, 6, 0x0927),
                    SimpleWandering.Instance(2)
                    ),
                    Cooldown.Instance(500, MultiAttack.Instance(100, 1 * (float)Math.PI / 30, 1, 0, projectileIndex: 0)
                    ),
                    loot: new LootBehavior(
                       new LootDef(0, 1, 0, 8,
                           Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Armor)),
                           Tuple.Create(0.3, (ILoot)new TierLoot(1, ItemType.Ring)),
                           Tuple.Create(0.2, (ILoot)new TierLoot(2, ItemType.Weapon)),
                           Tuple.Create(0.1, (ILoot)new TierLoot(3, ItemType.Weapon))
                           ),
                           Tuple.Create(100, new LootDef(0, 1, 0, 2,
                           Tuple.Create(0.01, (ILoot)new ItemLoot("Pirate Rum"))
                           )))
            ));
    }
}
