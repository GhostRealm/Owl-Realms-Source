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
        static _ Present = Behav()
            .Init(0x5318, Behaves("Christmas Present",
                new RunBehaviors(
                    HpGreaterEqual.Instance(945000,
                        Cooldown.Instance(5000, Heal.Instance(1, 1000000, 0x0935))),
            /*This is the standard healing behavior. */
                    Once.Instance(new SetKey(-1, 1)),

        #region HpLesserPercent

            /* These lines we're completely wrong, so I rewrote them.*/
            /*If.Instance(
      And.Instance(HpLesser.Instance(999000, NullBehavior.Instance), HpGreaterEqual.Instance(1000000, NullBehavior.Instance)),
        new SetKey(-1, 2)  //
    ),
    If.Instance(
      And.Instance(HpLesser.Instance(998000, NullBehavior.Instance), HpGreaterEqual.Instance(999000, NullBehavior.Instance)),
        new SetKey(-1, 3)  //
    ),
    If.Instance(
      And.Instance(HpLesser.Instance(997000, NullBehavior.Instance), HpGreaterEqual.Instance(998000, NullBehavior.Instance)),
        Once.Instance(new SetKey(-1, 7))   //break
    ),*/
            /* Cooldown.Instance(5000, HpLesserPercent.Instance(0.9f, new SetKey(-1, 2))), 
    Cooldown.Instance(5000, HpLesserPercent.Instance(0.85f, new SetKey(-1, 3))),
    Cooldown.Instance(5000, HpLesserPercent.Instance(0.8f, new SetKey(-1, 7))), */
                    Cooldown.Instance(4000, HpLesser.Instance(995000, new SetKey(-1, 2))),
                    Cooldown.Instance(4000, HpLesser.Instance(985000, new SetKey(-1, 3))),
                    Cooldown.Instance(4000, HpLesser.Instance(945000, new SetKey(-1, 7))),

        #endregion
 IfEqual.Instance(-1, 1,
                        new QueuedBehavior(
                            Cooldown.Instance(100),
                            True.Instance(Rand.Instance(
                                new RandomTaunt(0.5, "Break the present for great rewards..."),
                                new RandomTaunt(0.5, "Merry Christmas")
                                )
                                ),
                            CooldownExact.Instance(10000, new SetKey(-1, 1))
                            )
                        ),
                    IfEqual.Instance(-1, 2,
                        new QueuedBehavior(
                            Cooldown.Instance(0, Flashing.Instance(1000, 0xffffffff)),
                            Cooldown.Instance(1100, Flashing.Instance(1000, 0xffffffff)),
                            True.Instance(Rand.Instance(
                                new RandomTaunt(0.5, "Fire upon this present with all your might for 5 seconds"),
                                new RandomTaunt(0.5, "If your attacks are weak, the present magically heals"),
                                new RandomTaunt(0.5, "Gather a large group to smash it open")
                                )
                                ),
                            Cooldown.Instance(5000, new SetKey(-1, 1))
                            )
                        ),
                    IfEqual.Instance(-1, 3,
                        new QueuedBehavior(
                            Cooldown.Instance(100),
                            True.Instance(Rand.Instance(
                                new RandomTaunt(0.5, "Sweet treasure awaits for powerful adventurers!"),
                                new RandomTaunt(0.5, "Yes!  Smash your present for great rewards!")
                                )
                                ),
                            Cooldown.Instance(5000, new SetKey(-1, 4))
                            )
                        ),
                    IfEqual.Instance(-1, 4,
                        new QueuedBehavior(
                            Cooldown.Instance(100),
                            True.Instance(Rand.Instance(
                                new RandomTaunt(0.5, "If you are not very strong, this could kill you"),
                                new RandomTaunt(0.5, "If you are not yet powerful, stay away from the Present"),
                                new RandomTaunt(0.5, "New adventurers should stay away"),
                                new RandomTaunt(0.5, "That's the spirit. Lay your fire upon me."),
                                new RandomTaunt(0.5, "So close...")
                                )
                                ),
                            Cooldown.Instance(5000, new SetKey(-1, 5))
                            )
                        ),
                    IfEqual.Instance(-1, 5,
                        new QueuedBehavior(
                            Cooldown.Instance(100),
                            True.Instance(Rand.Instance(
                                new RandomTaunt(0.5, "I think you need more people..."),
                                new RandomTaunt(0.5, "Call all your friends to help you break open the present!")
                                )
                                ),
                            CooldownExact.Instance(10000, new SetKey(-1, 6))
                            )
                        ),
                    IfEqual.Instance(-1, 6,
            /*Changed runbehaviors to queuedbehavior here so that the ringattack would not be repeated infinitely*/
                        new RunBehaviors(
                            new QueuedBehavior(
                                new SimpleTaunt("Perhaps you need a bigger group. Ask others to join you!"),
                                Cooldown.Instance(0, Flashing.Instance(1000, 0xffffffff)),
                                RingAttack.Instance(16, 22, 16, projectileIndex: 0),
                                Cooldown.Instance(1100, Flashing.Instance(1000, 0xffffffff)),
                                CooldownExact.Instance(5000, new SetKey(-1, 1))
                                ))
                        ),
                    IfEqual.Instance(-1, 7,
                        new QueuedBehavior(
                            SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                            Once.Instance(new SimpleTaunt("You cracked the present! Soon you shall be rewarded!")),
                            Cooldown.Instance(1000, SetSize.Instance(95)),
                            Cooldown.Instance(1000, SetSize.Instance(90)),
                            Cooldown.Instance(1000, SetSize.Instance(85)),
                            Cooldown.Instance(1000, SetSize.Instance(80)),
                            Flashing.Instance(1000, 0xffffffff),
                            Flashing.Instance(1000, 0xffffffff),
                            CooldownExact.Instance(4000, new SetKey(-1, 8))
                            )
                        ),
                    IfEqual.Instance(-1, 8,
                        new QueuedBehavior(
                            Once.Instance(
                                new SimpleTaunt("MERRY CHRISTMAS!!!!!")),
                            Once.Instance(RingAttack.Instance(16, 22, 16, projectileIndex: 0)),
                            Once.Instance(SpawnMinionImmediate.Instance(0x5317, 0, 1, 1)),
                            Once.Instance(Despawn.Instance)
                            ))
                    )
                ))
                     .Init(0x5317, Behaves("Christmas Oryx",
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
                        Tuple.Create(100, new LootDef(10, 15, 12, 18,
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Doom Bow")),
                            Tuple.Create(0.2, (ILoot)new TierLoot(8, ItemType.Ability)),
                            Tuple.Create(0.2, (ILoot)new TierLoot(15, ItemType.Armor)),
                            Tuple.Create(0.2, (ILoot)new TierLoot(14, ItemType.Weapon)),
                            Tuple.Create(0.009, (ILoot)new ItemLoot("Crown")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Tooth Sword")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Doom Dirk")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Platinum Sword")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Hide Robe")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Hide Armor")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Oryx Scale Armor")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Ring of Oryx")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Doom Poison")),
                            Tuple.Create(0.9, (ILoot)new ItemLoot("Potion of Oryx")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Oceanic Nova")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Great Coil Snake Generator")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Lil' Oryx 3 Generator")),
            //                            Tuple.Create(0.1, (ILoot)new ItemLoot("Turkey Leg of Doom")),
            //                            Tuple.Create(0.1, (ILoot)new ItemLoot("Helm of the Pumpkin")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Flying Doom Daggers")),
                           Tuple.Create(0.3, (ILoot)new ItemLoot("Candy Cane Sword")),
                           Tuple.Create(0.3, (ILoot)new ItemLoot("The Snowball")),
                           Tuple.Create(0.3, (ILoot)new ItemLoot("Santa's Hat")),
                            Tuple.Create(0.3, (ILoot)new ItemLoot("The Agressive Caroller"))
                    ))),
                    condBehaviors: new ConditionalBehavior[] {
                    new DeathPortal(0x0721, 100, 100)
                                                                   }
                        ));

    }
}
