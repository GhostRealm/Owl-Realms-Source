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
        static _ Manor = Behav()
           .Init(0x1720, Behaves("Lord Ruthven",
                               new RunBehaviors(
                                    IfExist.Instance(-1,
                                      IfGreater.Instance(-1, 0,
                                        NullBehavior.Instance
                                                        )
                                                    ),

        #region Initiation Phases

 If.Instance(IsEntityPresent.Instance(20, null),
                                           Once.Instance(new SetKey(-1, 1))
                                          ),
                               IfEqual.Instance(-1, 1,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 3, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),

        #endregion

        #region Bat Phase before Damage Detection

 IfEqual.Instance(-1, 2,
                                                     new RunBehaviors(
                                                    If.Instance(IsEntityPresent.Instance(20, null),
                                                         Chasing.Instance(8, 20, 2, null)
                                                        ),
                                                    IfNot.Instance(Chasing.Instance(8, 20, 2, null),
                                                         SimpleWandering.Instance(2, 1)
                                                        )
                                                     )
                                                    ),
                               IfEqual.Instance(-1, 2,
                                                new QueuedBehavior(
                                                 SetConditionEffect.Instance(ConditionEffectIndex.Paralyzed),
                                                 SetAltTexture.Instance(2),
                                                 CooldownExact.Instance(500),
                                                 SetAltTexture.Instance(2),
                                                 CooldownExact.Instance(250),
                                                 SetAltTexture.Instance(2),
                                                 SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                                 RingAttack.Instance(20, 20, 0, projectileIndex: 1),
                                                 CooldownExact.Instance(700),
                                                 RingAttack.Instance(6, 20, 0, projectileIndex: 1),
                                                 CooldownExact.Instance(800),
                                                 RingAttack.Instance(15, 20, 0, projectileIndex: 1),
                                                 CooldownExact.Instance(400),
                                                 RingAttack.Instance(25, 20, 0, projectileIndex: 1),
                                                 new RunBehaviors(
                                                  TossEnemy.Instance(90 * (float)Math.PI / 180, 12, 0x1722),
                                                  TossEnemy.Instance(180 * (float)Math.PI / 180, 12, 0x1722),
                                                  TossEnemy.Instance(270 * (float)Math.PI / 180, 12, 0x1722),
                                                  TossEnemy.Instance(360 * (float)Math.PI / 180, 12, 0x1722)
                                                 ),
                                                 CooldownExact.Instance(4000),
                                                 UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                                 CooldownExact.Instance(1000),
                                                 new RunBehaviors(
                                                  SpawnMinionImmediate.Instance(0x1721, 2, 10, 15),
                                                  SpawnMinionImmediate.Instance(0x1724, 2, 10, 15),
                                                  SetAltTexture.Instance(1)
                                                 ),
                                                 UnsetConditionEffect.Instance(ConditionEffectIndex.Paralyzed),
                                                 SetConditionEffect.Instance(ConditionEffectIndex.Invincible),
                                                 CooldownExact.Instance(5000),
                                                 UnsetConditionEffect.Instance(ConditionEffectIndex.Invincible),

        #endregion

        #region Damage Detection phase changes

 DamageLesserEqual.Instance(1000,
                                                  new SetKey(-1, 1),
                                                  DamageLesserEqual.Instance(2000,
                                                   new SetKey(-1, 3),
                                                   DamageLesserEqual.Instance(5000,
                                                    new SetKey(-1, 4),
                                                    DamageLesserEqual.Instance(10000,
                                                     new SetKey(-1, 5),
                                                     DamageLesserEqual.Instance(20000,
                                                      new SetKey(-1, 6),
                                                      DamageLesserEqual.Instance(30000,
                                                       new SetKey(-1, 7),
                                                       DamageLesserEqual.Instance(40000,
                                                        new SetKey(-1, 8),
                                                        DamageLesserEqual.Instance(50000,
                                                         new SetKey(-1, 9),
                                                         DamageLesserEqual.Instance(60000,
                                                          new SetKey(-1, 10),
                                                          DamageLesserEqual.Instance(70000,
                                                           new SetKey(-1, 11),
                                                           DamageLesserEqual.Instance(80000,
                                                            new SetKey(-1, 12),
                                                            DamageLesserEqual.Instance(90000,
                                                             new SetKey(-1, 13),
                                                             DamageLesserEqual.Instance(100000,
                                                              new SetKey(-1, 14),
                                                              DamageLesserEqual.Instance(110000,
                                                               new SetKey(-1, 15),
                                                               DamageLesserEqual.Instance(119999,
                                                                new SetKey(-1, 16)
                                                               )))))))))))))))
        #endregion


)),
        #region Damage Detection SetKeys (-1,3) to (-1,17)


 IfEqual.Instance(-1, 3,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 4, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                               IfEqual.Instance(-1, 4,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 5, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 5,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 6, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 6,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 7, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 7,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 8, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 8,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 9, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 9,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 10, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 10,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 11, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 11,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 12, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 12,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 13, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 13,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 14, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 14,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 15, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 15,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 16, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 16,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 17, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                )),
                                  IfEqual.Instance(-1, 17,
                                                new RunBehaviors(
                                                        OrderEntity.Instance(50, 0x1724, Die.Instance),
                                                    SetAltTexture.Instance(0),
                                               new RunBehaviors(
                                                 SmoothWandering.Instance(1, 1),
                                                 Cooldown.Instance(700, MultiAttack.Instance(30, 20 * (float)Math.PI / 360, 18, 0, projectileIndex: 0))
                                                ),
                                                new QueuedBehavior(
                                                 CooldownExact.Instance(9101),
                                                 new SetKey(-1, 2)
                                                )
                                                ))
        #endregion
),


                    loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 2, 0, 2,
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Wine Cellar Incantation")),
                            Tuple.Create(0.08, (ILoot)new ItemLoot("Tome of Purification")),
                            Tuple.Create(0.5, (ILoot)new ItemLoot("Holy Water")),
                            Tuple.Create(0.4, (ILoot)new ItemLoot("Broken Glass Sword")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("St. Abraham's Wand")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Chasuble of Holy Light")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Scepter of Zeus")),
                            Tuple.Create(0.04, (ILoot)new ItemLoot("Rare Ore")),
                            Tuple.Create(0.12, (ILoot)new ItemLoot("Ring of Divine Faith"))
                    ))),
                        condBehaviors: new ConditionalBehavior[] {
                        new DeathPortal(0x071c, 100, 100)
                    }

                                 ))

            .Init(0x1721, Behaves("Vampire Bat",
                                  new RunBehaviors(
                                    If.Instance(IsEntityPresent.Instance(20, null),
                                                Chasing.Instance(8, 20, 2, null)
                                               ),
                                    IfNot.Instance(Chasing.Instance(8, 20, 2, null),
                                    SimpleWandering.Instance(2, 1)
                                  ),
                                    Cooldown.Instance(900, SimpleAttack.Instance(1, projectileIndex: 0))
                                  )
                             ))

            .Init(0x1737, Behaves("Coffin",
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathTransmute(0x1727)
                },
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(800, new LootDef(0, 5, 0, 2,
                        Tuple.Create(0.009, (ILoot) new ItemLoot("St. Abraham's Wand")),
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Bone Dagger")),
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Chasuble of Holy Light")),
                        Tuple.Create(0.05, (ILoot) new ItemLoot("Ring of Divine Faith")),
                        Tuple.Create(0.005, (ILoot) new ItemLoot("Tome of Purification")),
                        Tuple.Create(0.1, (ILoot) new ItemLoot("Wine Cellar Incantation")),
                        Tuple.Create(0.25, (ILoot) new ItemLoot("Holy Water")),
                        Tuple.Create(0.03, (ILoot) new TierLoot(9, ItemType.Weapon)),
                        Tuple.Create(0.03, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.03, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.03, (ILoot) new TierLoot(6, ItemType.Armor)),
                        Tuple.Create(0.03, (ILoot) new TierLoot(5, ItemType.Ability)),
                        Tuple.Create(0.03, (ILoot) new TierLoot(4, ItemType.Ability)),
                        Tuple.Create(0.03, (ILoot) new TierLoot(4, ItemType.Ring))
                        )))
                ))
                            .Init(0x1724, Behaves("Vampire Bat Swarmer 1",
                                  new RunBehaviors(
                                    Chasing.Instance(8, 20, 4, 0x1720),
                                    If.Instance(IsEntityPresent.Instance(5, 0x1720),
                                               SimpleWandering.Instance(2, 1)
                                              ),
                                    Cooldown.Instance(900, SimpleAttack.Instance(1, projectileIndex: 0))
                                  ),
                                  If.Instance(IsEntityNotPresent.Instance(200, 0x1720),
                                             new QueuedBehavior(
                                                CooldownExact.Instance(2000),
                                              Die.Instance
                                             ))

                             ))

        .Init(0x1738, Behaves("Lil Feratu",
                              new RunBehaviors(
                                SimpleWandering.Instance(1, 1),
                                Cooldown.Instance(1200, MultiAttack.Instance(7, 18 * (float)Math.PI / 360, 5, 0, projectileIndex: 0))
                              )
                             ));
    }
}
    
