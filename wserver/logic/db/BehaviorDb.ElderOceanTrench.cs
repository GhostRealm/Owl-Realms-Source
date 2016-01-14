﻿#region

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
        private static _ ElderTrench = Behav()
            .Init(0x7706, Behaves("Elder Thessal the Mermaid Goddess",
                new RunBehaviors(
                    Once.Instance(SpawnMinionImmediate.Instance(0x172f, 1, 1, 1)),
                    HpGreaterEqual.Instance(25000, (new SetKey(-1, 1))),
                    HpLesser.Instance(25000, new SetKey(-1, 2)),
                    Cooldown.Instance(5000, If.Instance(EntityLesserThan.Instance(20, 4, 0x7707),
                        new QueuedBehavior(
                            new RunBehaviors(
                                TossEnemy.Instance(0*(float) Math.PI/180, 10, 0x07707),
                                TossEnemy.Instance(90*(float) Math.PI/180, 10, 0x07707),
                                TossEnemy.Instance(180*(float) Math.PI/180, 10, 0x07707),
                                TossEnemy.Instance(270*(float) Math.PI/180, 10, 0x07707)),
                            Cooldown.Instance(1000),
                            OrderAllEntity.Instance(20, 0x01707, Despawn.Instance),
                            Cooldown.Instance(1000)
                            ))),
                    IfEqual.Instance(-1, 1,
                        new RunBehaviors(
                            Cooldown.Instance(2500, TossEnemyAtPlayer.Instance(20, 0x7702)),
                            Cooldown.Instance(8000, new RunBehaviors(
                                TossEnemy.Instance(45*(float) Math.PI/180, 14, 0x7702),
                                TossEnemy.Instance(135*(float) Math.PI/180, 14, 0x7702),
                                TossEnemy.Instance(225*(float) Math.PI/180, 14, 0x7702),
                                TossEnemy.Instance(315*(float) Math.PI/180, 14, 0x7702))),
                            SmoothWandering.Instance(1f, 1f),
                            new QueuedBehavior(
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(1000),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(1000),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(1000),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                RingAttack.Instance(8, 0, 0, 0),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(8, 0, 0, 0),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(8, 0, 0, 0),
                                Cooldown.Instance(1000)
                                ))
                        ),
                    IfEqual.Instance(-1, 2,
                        new RunBehaviors(
                            SimpleWandering.Instance(1f, 1f),
                            Cooldown.Instance(550, Once.Instance(Flashing.Instance(500, 0x01ADFF2F))),
                            Cooldown.Instance(6000, new RunBehaviors(
                                TossEnemy.Instance(45*(float) Math.PI/180, 14, 0x7702),
                                TossEnemy.Instance(135*(float) Math.PI/180, 14, 0x7702),
                                TossEnemy.Instance(225*(float) Math.PI/180, 14, 0x7702),
                                TossEnemy.Instance(315*(float) Math.PI/180, 14, 0x7702))),
                            Cooldown.Instance(1500, TossEnemyAtPlayer.Instance(20, 0x7702)),
                            new QueuedBehavior(
                                ReturnSpawn.Instance(40),
                                Flashing.Instance(1000, 0x01ADFF2F),
                                RingAttack.Instance(30, 0, 0, 3),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(30, 0, 0, 3),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(30, 0, 0, 3),
                                Cooldown.Instance(1000),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(750),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(750),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(750),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(750),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(0*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(90*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(180*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(270*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(750),
                                new RunBehaviors(
                                    AngleMultiAttack.Instance(45*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(135*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(225*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2),
                                    AngleMultiAttack.Instance(315*(float) Math.PI/180, 20*(float) Math.PI/180, 2, 2)),
                                Cooldown.Instance(500),
                                RingAttack.Instance(16, 0, 0, 0),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(16, 0, 0, 0),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(16, 0, 0, 0),
                                Cooldown.Instance(1000),
                                RingAttack.Instance(16, 0, 0, 0)
                                )))
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new OnDeath(
                        Once.Instance(new RandomDo(20, SpawnMinionImmediate.Instance(0x7704, 1, 1, 1))))
                },
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 5, 2, 5,
                        Tuple.Create(0.1, (ILoot) new ItemLoot("Potion of Max Mana")),
                        Tuple.Create(0.005, (ILoot) new ItemLoot("Wine Cellar Incantation")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Raw Fish of Terror")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Scaled Robe")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Oceans Gift")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Idol of the Fish")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Large Blue Wave Cloth")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Small Blue Wave Cloth"))
                        )))
                ))
            .Init(0x7700, Behaves("Fishman Warrior",
                IfNot.Instance(
                    Chasing.Instance(12, 9, 3, null),
                    IfNot.Instance(
                        Circling.Instance(3, 10, 6, null),
                        SimpleWandering.Instance(4)
                        )
                    ),
                new RunBehaviors(
                    Cooldown.Instance(800, MultiAttack.Instance(100, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0)),
                    Cooldown.Instance(1000, SimpleAttack.Instance(3, 1)),
                    Cooldown.Instance(2000, RingAttack.Instance(5, 10, 0, 2))
                    )
                ))
            .Init(0x770a, Behaves("Sea Mare",
                IfNot.Instance(
                    Charge.Instance(10, 10, null),
                    SimpleWandering.Instance(4)
                    ),
                Cooldown.Instance(500, MultiAttack.Instance(25, 10*(float) Math.PI/180, 5, 0, projectileIndex: 0)),
                Cooldown.Instance(1500, SimpleAttack.Instance(3, 1))
                ))
            .Init(0x770c, Behaves("Giant Squid",
                IfNot.Instance(
                    Chasing.Instance(12, 9, 6, null),
                    SimpleWandering.Instance(4)
                    ),
                Cooldown.Instance(100, SimpleAttack.Instance(10, projectileIndex: 0)),
                Cooldown.Instance(500, MultiAttack.Instance(25, 10*(float) Math.PI/180, 5, 0, 1))
                ))
            .Init(0x770b, Behaves("Ink Bubble",
                Cooldown.Instance(100, RingAttack.Instance(1, 1, 0, projectileIndex: 0))
                ))
            .Init(0x7707, Behaves("Deep Sea Beast",
                SetSize.Instance(100),
                new QueuedBehavior(
                    Cooldown.Instance(50, SimpleAttack.Instance(3, projectileIndex: 0)),
                    Cooldown.Instance(100, SimpleAttack.Instance(3, 1)),
                    Cooldown.Instance(150, SimpleAttack.Instance(3, 2)),
                    Cooldown.Instance(200, SimpleAttack.Instance(3, 3)),
                    CooldownExact.Instance(300)
                    )
                ))
            .Init(0x7709, Behaves("Sea Horse",
                IfNot.Instance(
                    Chasing.Instance(12, 9, 1, 0x770a),
                    SimpleWandering.Instance(4)
                    ),
                Cooldown.Instance(660, MultiAttack.Instance(25, 10*(float) Math.PI/180, 5, 0, projectileIndex: 0))
                ))
            .Init(0x770e, Behaves("Grey Sea Slurp",
                IfNot.Instance(
                    Chasing.Instance(12, 9, 2, 0x770d),
                    SimpleWandering.Instance(4)
                    ),
                Cooldown.Instance(500, SimpleAttack.Instance(8, projectileIndex: 0)),
                Cooldown.Instance(500, RingAttack.Instance(8, 4, 0, 1))
                ))
            .Init(0x770d, Behaves("Sea Slurp Home",
                new QueuedBehavior(
                    Cooldown.Instance(500, RingAttack.Instance(8, 4, 0, projectileIndex: 0)),
                    Cooldown.Instance(500, RingAttack.Instance(8, 2, 0, 1))
                    )
                ))
            .Init(0x772f, Behaves("Thessal Summoner",
                new QueuedBehavior(
                    SetConditionEffect.Instance(ConditionEffectIndex.Invincible),
                    Cooldown.Instance(2000),
                    new SetKey(-1, 1),
                    Cooldown.Instance(5000)),
                IfEqual.Instance(-1, 1,
                    If.Instance(IsEntityNotPresent.Instance(100, 0x7706), Die.Instance)
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathPortal(0x0704, 100, -1)
                }
                ))
            //nostealing
            .Init(0x7705, Behaves("Coral Gift",
                NullBehavior.Instance,
                new QueuedBehavior(
                    SetAltTexture.Instance(1),
                    CooldownExact.Instance(500),
                    SetAltTexture.Instance(2),
                    CooldownExact.Instance(500),
                    SetAltTexture.Instance(0),
                    CooldownExact.Instance(500)
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(360, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.1, (ILoot)new ItemLoot("Potion of Max Mana")),
                        Tuple.Create(0.005, (ILoot)new ItemLoot("Wine Cellar Incantation")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Raw Fish of Terror")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Scaled Robe")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Oceans Gift")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Idol of the Fish")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Large Blue Wave Cloth")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Small Blue Wave Cloth"))
                        )))
                ))
            .Init(0x7702, Behaves("Coral Bomb Big",
                new RunBehaviors(
                    new QueuedBehavior(
                        CooldownExact.Instance(500),
                        new RunBehaviors(
                            TossEnemy.Instance(30*(float) Math.PI/180, 1.5f, 0x7703),
                            TossEnemy.Instance(90*(float) Math.PI/180, 1.5f, 0x7703),
                            TossEnemy.Instance(150*(float) Math.PI/180, 1.5f, 0x7703),
                            TossEnemy.Instance(210*(float) Math.PI/180, 1.5f, 0x7703),
                            TossEnemy.Instance(270*(float) Math.PI/180, 1.5f, 0x7703),
                            TossEnemy.Instance(330*(float) Math.PI/180, 1.5f, 0x7703)
                            ),
                        RingAttack.Instance(5, 0, 30*(float) Math.PI/180, 0),
                        CooldownExact.Instance(500),
                        Despawn.Instance,
                        CooldownExact.Instance(1000)
                        ))
                ))
            .Init(0x7703, Behaves("Coral Bomb Small",
                new RunBehaviors(
                    new QueuedBehavior(
                        CooldownExact.Instance(500),
                        RingAttack.Instance(5, 0, 30*(float) Math.PI/180, 0),
                        CooldownExact.Instance(500),
                        Despawn.Instance,
                        CooldownExact.Instance(1000)
                        ))
                ))
            .Init(0x7704, Behaves("Elder Thessal the Mermaid Goddess Wounded",
                new RunBehaviors(
                    Once.Instance(new SimpleTaunt("Who Rules all things in this realm?")),
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invincible)),
                    Once.Instance(new SetKey(-1, 1)
                        ),
                    new QueuedBehavior(
                        SetAltTexture.Instance(0),
                        Cooldown.Instance(500),
                        SetAltTexture.Instance(1)
                        ),
                    IfEqual.Instance(-1, 1,
                        new RunBehaviors(
                            new QueuedBehavior(
                                CooldownExact.Instance(12000),
                                new SetKey(-1, 3)
                                ))),
                    IfEqual.Instance(-1, 2,
                        new QueuedBehavior(
                            Once.Instance(new SimpleTaunt("Thank you, kind doominite!")),
                            TossEnemy.Instance(60*(float) Math.PI/180, 4, 0x7705),
                            TossEnemy.Instance(180*(float) Math.PI/180, 4, 0x7705),
                            TossEnemy.Instance(300*(float) Math.PI/180, 4, 0x7705),
                            CooldownExact.Instance(4500),
                            Die.Instance
                            )),
                    IfEqual.Instance(-1, 3,
                        new RunBehaviors(
                            Cooldown.Instance(1000, TossEnemy.Instance(0*(float) Math.PI/180, 10, 0x07707)),
                            Cooldown.Instance(1000, TossEnemy.Instance(90*(float) Math.PI/180, 10, 0x07707)),
                            Cooldown.Instance(1000, TossEnemy.Instance(180*(float) Math.PI/180, 10, 0x07707)),
                            Cooldown.Instance(1000, TossEnemy.Instance(270*(float) Math.PI/180, 10, 0x07707)),
                            new QueuedBehavior(
                                Cooldown.Instance(500, RingAttack.Instance(12, 20, projectileIndex: 2)),
                                Cooldown.Instance(500, RingAttack.Instance(6, 20, 60, projectileIndex: 0))
                                ),
                            Cooldown.Instance(1500, RingAttack.Instance(20, 20, projectileIndex: 3)),
                            new QueuedBehavior(
                                Cooldown.Instance(10000),
                                Die.Instance
                                )
                            )
                        )
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new ChatEvent(
                        IfEqual.Instance(-1, 1, new SetKey(-1, 2))
                        ).SetChats(
                        "Doom Rules",
                        "Doom Rules!",
                        "Volmore Rules",
                        "Volmore Rules.",
                        "Volmore Rules!",
                        "XVolmoreX Rules!",
                        "XVolmoreX Rules",
                        "XVolmoreX Rules.",
                        "Doom Rules."
                        )
                }
                ))
            ;
    }
}