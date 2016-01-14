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
        private static _ ElderTomb = Behav()
            .Init(0x7d28, Behaves("Elder Tomb Defender",
                Once.Instance(new SimpleTaunt("THIS WILL NOW BE YOUR TOMB!")),
                new RunBehaviors(
                    new State("idle",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        SetConditionEffect.Instance(ConditionEffectIndex.Armored),
                        HpLesserPercent.Instance(0.99f, SetState.Instance("Quieting"))
                        ),
                    new State("Quieting",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        Once.Instance(new SimpleTaunt("Impudence! I am an immortal, I needn't take you seriously.")),
                        CooldownExact.Instance(5000, RingAttack.Instance(24, 20, 0, 3)),
                        HpLesserPercent.Instance(0.97f, SetState.Instance("active"))
                        ),
                    new State("active",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        Cooldown.Instance(1000, RingAttack.Instance(8, 20, 0, 2)),
                        Cooldown.Instance(3000, RingAttack.Instance(4, 20, 0, 1)),
                        Cooldown.Instance(3100, RingAttack.Instance(6, 20, 0, projectileIndex: 0)),
                        HpLesserPercent.Instance(0.9f, SetState.Instance("active2"))
                        ),
                    new State("active2",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        CooldownExact.Instance(1000, RingAttack.Instance(8, projectileIndex: 2)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(10, 10*(float) Math.PI/180, 8, projectileIndex: 1)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(25, 10*(float) Math.PI/180, 1, 0, projectileIndex: 0)),
                        HpLesserPercent.Instance(0.66f, SetState.Instance("active3"))
                        ),
                    new State("active3",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        CooldownExact.Instance(1000, RingAttack.Instance(8, projectileIndex: 2)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(10, 10*(float) Math.PI/180, 8, projectileIndex: 1)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(25, 10*(float) Math.PI/180, 1, 0, projectileIndex: 0)),
                        HpLesserPercent.Instance(0.50f, SetState.Instance("artifacts"))
                        ),
                    new State("artifacts",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        CooldownExact.Instance(1000, RingAttack.Instance(8, projectileIndex: 2)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(10, 10*(float) Math.PI/180, 8, projectileIndex: 1)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(25, 10*(float) Math.PI/180, 1, 0, projectileIndex: 0)),
                        Once.Instance(new SimpleTaunt("My artifacts shall prove my wall of defense is impenetrable!")),
                        Once.Instance(SpawnMinionImmediate.Instance(0x7d22, 1, 1, 3)),
                        Once.Instance(SpawnMinionImmediate.Instance(0x7d23, 1, 1, 3)),
                        Once.Instance(SpawnMinionImmediate.Instance(0x7d24, 1, 1, 3)),
                        Reproduce.Instance(0x7d24, 4, 1500, 4),
                        Reproduce.Instance(0x7d23, 4, 1500, 4),
                        Reproduce.Instance(0x7d22, 4, 1500, 4),
                        HpLesserPercent.Instance(0.33f, SetState.Instance("active4"))
                        ),
                    new State("active4",
                        Circling.Instance(5, 100, 5, 0x0d25),
                        CooldownExact.Instance(1000, RingAttack.Instance(8, projectileIndex: 2)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(10, 10*(float) Math.PI/180, 8, projectileIndex: 1)),
                        CooldownExact.Instance(5000,
                            MultiAttack.Instance(25, 10*(float) Math.PI/180, 3, 0, projectileIndex: 0)),
                        HpLesserPercent.Instance(0.1f, SetState.Instance("rage"))
                        ),
                    new State("rage",
                        Once.Instance(new SimpleTaunt("The end of your path is here!")),
                        Flashing.Instance(10000, 0xFFFF0000),
                        Chasing.Instance(5, 5, 0, null),
                        CooldownExact.Instance(250,
                            MultiAttack.Instance(10, 10*(float) Math.PI/180, 4, projectileIndex: 4)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(10, 15*(float) Math.PI/180, 8, projectileIndex: 1)),
                        CooldownExact.Instance(4750,
                            MultiAttack.Instance(25, 10*(float) Math.PI/180, 1, 0, projectileIndex: 0)),
                        CooldownExact.Instance(500, SimpleAttack.Instance(10))
                        )
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 5, 0, 8,
                        Tuple.Create(0.05, (ILoot)new ItemLoot("Crusader's Lost Relic")),
                        Tuple.Create(0.1, (ILoot)new ItemLoot("Potion of Max Life")),
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Angel's Hope")),
                        Tuple.Create(0.03, (ILoot)new ItemLoot("Pyramid Artifact Generator")),
                        Tuple.Create(0.5, (ILoot)new ItemLoot("Large Egyptian Cloth")),
                        Tuple.Create(0.5, (ILoot)new ItemLoot("Small Egyptian Cloth"))
                        )))
                ))
            .Init(0x7d22,
                Behaves("Pyramid Artifact 1", Circling.Instance(3, 3, 10, 0x7d26),
                    Cooldown.Instance(5000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0))
                    ))
            .Init(0x7d23,
                Behaves("Pyramid Artifact 2", Circling.Instance(3, 3, 10, 0x7d27),
                    Cooldown.Instance(5000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0))
                    ))
            .Init(0x7d24,
                Behaves("Pyramid Artifact 3", Circling.Instance(3, 3, 10, 0x7d28),
                    Cooldown.Instance(5000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0))
                    ))
                                .Init(0x7d3c, Behaves("Elder Lion Archer",
                IfNot.Instance(
                    Chasing.Instance(11, 8, 6, 0x617),
                    IfNot.Instance(
                        Chasing.Instance(8, 8, 0, null),
                        SimpleWandering.Instance(4)
                        )
                    ),
                new RunBehaviors(
                    Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 1, 0, projectileIndex: 0)),
                    Cooldown.Instance(1200, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 1, 0, 1)),
                    Cooldown.Instance(1300, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 1, 0, 2)),
                    Cooldown.Instance(1000, Once.Instance(RingAttack.Instance(5, 0, 5, 3)))
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 2, 0, 8,
                        Tuple.Create(0.03, (ILoot)HpPotionLoot.Instance),
                        Tuple.Create(0.03, (ILoot)MpPotionLoot.Instance)
                        ))
                ))
            .Init(0x7d3b, Behaves("Elder Jackal Priest",
                IfNot.Instance(
                    Chasing.Instance(12, 9, 6, 0x7d3b),
                    Chasing.Instance(6.5f, 8, 1, null)
                    ),
                Cooldown.Instance(600, SimpleAttack.Instance(10, projectileIndex: 0)),
                Cooldown.Instance(1000, RingAttack.Instance(5, 10, 0, 1)
                    ), new LootBehavior(
                        new LootDef(0, 2, 0, 8,
                            Tuple.Create(0.0001, (ILoot)HpPotionLoot.Instance)
                            ))
                ))
            .Init(0x7d1b, Behaves("Elder Scarab",
                IfNot.Instance(
                    Chasing.Instance(12, 9, 6, 0x7d1b),
                    Chasing.Instance(8.5f, 8, 1, null)
                    ),
                Cooldown.Instance(200, SimpleAttack.Instance(3, projectileIndex: 0)),
                Cooldown.Instance(400, RingAttack.Instance(5, 10, 0, 1)
                    )
                ))
            .Init(0x7d3a, Behaves("Elder Eagle Sentry",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(960, MultiAttack.Instance(900, 15 * (float)Math.PI / 360, 3, 0, projectileIndex: 0)),
                    Cooldown.Instance(1160, MultiAttack.Instance(900, 15 * (float)Math.PI / 360, 3, 0, 1)),
                    Cooldown.Instance(1360, MultiAttack.Instance(900, 15 * (float)Math.PI / 360, 3, 0, 2))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d2b, Behaves("Elder Beam Priestess",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 4, 1, null),
                    Circling.Instance(7, 9, 8, 0x7d2c),
                    Cooldown.Instance(860, MultiAttack.Instance(900, 15 * (float)Math.PI / 360, 3, 0, projectileIndex: 0)),
                    Cooldown.Instance(1100, MultiAttack.Instance(900, 20 * (float)Math.PI / 360, 1, 0, 1))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d2a, Behaves("Elder Beam Priest",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 4, 1, null),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(860, MultiAttack.Instance(966, 15 * (float)Math.PI / 360, 1, 0, projectileIndex: 0)),
                    Cooldown.Instance(1100, MultiAttack.Instance(942, 20 * (float)Math.PI / 360, 3, 0, 1))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d2c, Behaves("Elder Inactive Sarcophagus",
                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                If.Instance(
                    IsEntityPresent.Instance(12, 0x7d2b),
                    IsEntityPresent.Instance(12, 0x7d2a),
                    new Transmute(0x7d29)
                    )
                ))
            .Init(0x7d29, Behaves("Elder Active Sarcophagus",
                new RunBehaviors(
                    Cooldown.Instance(2800, MultiAttack.Instance(966, 30 * (float)Math.PI / 360, 26, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.15, (ILoot)new ItemLoot("Health Potion")),
                        Tuple.Create(0.15, (ILoot)new ItemLoot("Magic Potion")),
                        Tuple.Create(0.09, (ILoot)new ItemLoot("Elder Tomb Key")),
                        Tuple.Create(0.15, (ILoot)new ItemLoot("Tincture of Mana")),
                        Tuple.Create(0.15, (ILoot)new ItemLoot("Tincture of Life")),
                        Tuple.Create(0.15, (ILoot)new ItemLoot("Tincture of Dexterity"))
                        )))
                ))
            .Init(0x7d1a, Behaves("Elder Bloated Mummy",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1860, MultiAttack.Instance(500, 30 * (float)Math.PI / 360, 25, 0, projectileIndex: 0)),
                    Cooldown.Instance(1100, MultiAttack.Instance(600, 60 * (float)Math.PI / 360, 4, 0, 1))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d19, Behaves("Elder Jackal Lord",
                new RunBehaviors(
                    Once.Instance(SpawnMinionImmediate.Instance(0x7d18, 5, 1, 2)),
                    Once.Instance(SpawnMinionImmediate.Instance(0x7d17, 5, 1, 2)),
                    Once.Instance(SpawnMinionImmediate.Instance(0x7d16, 5, 1, 2)),
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(860, MultiAttack.Instance(900, 15 * (float)Math.PI / 360, 3, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d18, Behaves("Elder Jackal Assassin",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(800, MultiAttack.Instance(500, 30 * (float)Math.PI / 360, 6, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d17, Behaves("Elder Jackal Veteran",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1860, MultiAttack.Instance(600, 30 * (float)Math.PI / 360, 4, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d16, Behaves("Elder Jackal Warrior",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1860, MultiAttack.Instance(600, 30 * (float)Math.PI / 360, 3, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d15, Behaves("Elder Blue Swarm Masters",
                new RunBehaviors(
                    Once.Instance(SpawnMinionImmediate.Instance(0x7d14, 5, 2, 3)),
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1260, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 8, 0, projectileIndex: 0)),
                    Cooldown.Instance(1600, MultiAttack.Instance(600, 60 * (float)Math.PI / 360, 2, 0, 1)),
                    Cooldown.Instance(1880, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 2, 0, 2)),
                    Cooldown.Instance(1990, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 2, 0, 3))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d14, Behaves("Elder Blue Swarm Minions",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1860, MultiAttack.Instance(600, 30 * (float)Math.PI / 360, 8, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d13, Behaves("Elder Yellow Swarm Masters",
                new RunBehaviors(
                    Once.Instance(SpawnMinionImmediate.Instance(0x7d14, 5, 2, 3)),
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1260, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 8, 0, projectileIndex: 0)),
                    Cooldown.Instance(1600, MultiAttack.Instance(600, 60 * (float)Math.PI / 360, 2, 0, 1)),
                    Cooldown.Instance(1880, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 2, 0, 2)),
                    Cooldown.Instance(1990, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 2, 0, 3))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d12, Behaves("Elder Yellow Swarm Minions",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1860, MultiAttack.Instance(600, 30 * (float)Math.PI / 360, 8, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d11, Behaves("Elder Red Swarm Masters",
                new RunBehaviors(
                    Once.Instance(SpawnMinionImmediate.Instance(0x7d14, 5, 2, 3)),
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1260, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 8, 0, projectileIndex: 0)),
                    Cooldown.Instance(1600, MultiAttack.Instance(600, 60 * (float)Math.PI / 360, 2, 0, 1)),
                    Cooldown.Instance(1880, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 2, 0, 2)),
                    Cooldown.Instance(1990, MultiAttack.Instance(600, 20 * (float)Math.PI / 360, 2, 0, 3))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d10, Behaves("Elder Red Swarm Minions",
                new RunBehaviors(
                    SmoothWandering.Instance(2f, 2f),
                    Chasing.Instance(8, 11, 1, null),
                    Cooldown.Instance(1860, MultiAttack.Instance(600, 30 * (float)Math.PI / 360, 8, 0, projectileIndex: 0))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 3, 0, 8,
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Health Potion"))
                        )))
                ))
            .Init(0x7d1f, Behaves("Elder Nile Artifact 1",
                IfNot.Instance(
                    Circling.Instance(3, 3, 10, 0x7d26),
                    Chasing.Instance(10, 20, 1, null)
                    ),
                Cooldown.Instance(3000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0))
                ))
            .Init(0x7d20, Behaves("Elder Nile Artifact 2",
                IfNot.Instance(
                    Circling.Instance(3, 3, 10, 0x7d27),
                    Chasing.Instance(10, 20, 1, null)
                    ),
                Cooldown.Instance(3000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0))
                ))
            .Init(0x7d21, Behaves("Elder Nile Artifact 3",
                IfNot.Instance(
                    Circling.Instance(3, 3, 10, 0x7d28),
                    Chasing.Instance(10, 20, 1, null)
                    ),
                Cooldown.Instance(3000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0))
                ))
            .Init(0x7d1c, Behaves("Elder Sphinx Artifact 1",
                IfNot.Instance(
                    Circling.Instance(3, 3, 10, 0x7d26),
                    Chasing.Instance(10, 20, 1, null)
                    ),
                Cooldown.Instance(3000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0)),
                Cooldown.Instance(5000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, 1))
                ))
            .Init(0x7d1d, Behaves("Elder Sphinx Artifact 2",
                IfNot.Instance(
                    Circling.Instance(3, 3, 10, 0x7d27),
                    Chasing.Instance(10, 20, 1, null)
                    ),
                Cooldown.Instance(3000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0)),
                Cooldown.Instance(5000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, 1))
                ))
            .Init(0x7d1e, Behaves("Elder Sphinx Artifact 3",
                IfNot.Instance(
                    Circling.Instance(3, 3, 10, 0x7d28),
                    Chasing.Instance(10, 20, 1, null)
                    ),
                Cooldown.Instance(3000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, projectileIndex: 0)),
                Cooldown.Instance(5000, MultiAttack.Instance(120, 120 * (float)Math.PI / 180, 3, 0, 1))
                ))
            .Init(0x7d3f, Behaves("Elder Bes Statue",
                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                If.Instance(
                    IsEntityNotPresent.Instance(50000, 0x7d29),
                    IsEntityNotPresent.Instance(50000, 0x7d2c),
                    new Transmute(0x7d28)
                    )
                ))
            .Init(0x7d3d, Behaves("Elder Nut Statue",
                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                If.Instance(
                    IsEntityNotPresent.Instance(50000, 0x7d29),
                    IsEntityNotPresent.Instance(50000, 0x7d2c),
                    new Transmute(0x7d26)
                    )
                ))
            .Init(0x7d26, Behaves("Elder Nut",
                new RunBehaviors(
                    HpGreaterEqual.Instance(5000,
                        new RunBehaviors(
                            Circling.Instance(10, 100, 5, 0x0d25),
                            Cooldown.Instance(1000, Heal.Instance(6f, 100, 0x7d28)),
                            Cooldown.Instance(1000, Heal.Instance(6f, 100, 0x7d27))
                            )
                        ),
                    HpLesserPercent.Instance(0.99f,
                        new RunBehaviors(
                            Cooldown.Instance(2000, MultiAttack.Instance(10, 10*(float) Math.PI/180, 1, 0, 5)),
                            Cooldown.Instance(5000, MultiAttack.Instance(10, 10*(float) Math.PI/180, 1, 0, 6)),
                            Cooldown.Instance(3000, MultiAttack.Instance(10, 45*(float) Math.PI/180, 10, 0, 1)),
                            Cooldown.Instance(3500, MultiAttack.Instance(10, 45*(float) Math.PI/180, 10, 0, 2)),
                            Cooldown.Instance(3500, MultiAttack.Instance(10, 45*(float) Math.PI/180, 10, 0, 3)),
                            Cooldown.Instance(3500, MultiAttack.Instance(10, 45*(float) Math.PI/180, 10, 0, 4)),
                            Cooldown.Instance(5000,
                                MultiAttack.Instance(10, 45*(float) Math.PI/180, 7, 0, projectileIndex: 0))
                            )),
                    HpLesserPercent.Instance(0.5f,
                        Once.Instance(
                            new RunBehaviors(
                                True.Instance(
                                    Once.Instance(
                                        new SimpleTaunt(
                                            "My artifacts shall make your lethargic lives end much more switfly!"))),
                                Once.Instance(
                                    new RunBehaviors(
                                        SpawnMinionImmediate.Instance(0x7d1c, 3, 3, 4),
                                        SpawnMinionImmediate.Instance(0x7d1d, 3, 3, 4),
                                        SpawnMinionImmediate.Instance(0x7d1e, 3, 3, 4)
                                        )
                                    )
                                )
                            )
                        ),
                    HpLesserPercent.Instance(0.0625f,
                        new RunBehaviors(
                            Flashing.Instance(500, 0xffff3333),
                            Chasing.Instance(8, 10, 0, null),
                            Cooldown.Instance(3000, MultiAttack.Instance(25, 45*(float) Math.PI/180, 10, 0, 1)),
                            Cooldown.Instance(3500, MultiAttack.Instance(25, 45*(float) Math.PI/180, 10, 0, 2)),
                            Cooldown.Instance(3500, MultiAttack.Instance(25, 45*(float) Math.PI/180, 10, 0, 3)),
                            Cooldown.Instance(500, MultiAttack.Instance(25, 10*(float) Math.PI/180, 5, 0, 8)),
                            Cooldown.Instance(700, MultiAttack.Instance(25, 10*(float) Math.PI/180, 1, 0, 5)),
                            Cooldown.Instance(4000, MultiAttack.Instance(25, 10*(float) Math.PI/180, 2, 0, 6)),
                            Once.Instance(new SimpleTaunt("This cannot be! You shall not succeed!"))
                            ))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 2, 0, 2,
                        Tuple.Create(0.03, (ILoot)new ItemLoot("Burning Amulet")),
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Wine Cellar Incantation")),
                        Tuple.Create(0.1, (ILoot) new ItemLoot("Potion of Max Life")),
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Wings of Natural Bloodlust")),
                        Tuple.Create(0.5, (ILoot)new ItemLoot("Large Egyptian Cloth")),
                        Tuple.Create(0.5, (ILoot)new ItemLoot("Small Egyptian Cloth"))
                        )))
                ))
            .Init(0x7d3e, Behaves("Elder Geb Statue",
                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                If.Instance(
                    IsEntityNotPresent.Instance(50000, 0x7d29),
                    IsEntityNotPresent.Instance(50000, 0x7d2c),
                    new Transmute(0x7d27)
                    )
                ))
            .Init(0x7d27, Behaves("Elder Geb",
                new RunBehaviors(
                    HpGreaterEqual.Instance(9000, //If his HP is greater than 9000 (rage),
                        new RunBehaviors(
                            Circling.Instance(10, 100, 5, 0x0d25)
                            )),
                    HpLesserPercent.Instance(0.99f,
                        new RunBehaviors(
                            Cooldown.Instance(700, MultiAttack.Instance(25, 10*(float) Math.PI/180, 2, 0, 2)),
                            // Multi attack, Multiple projectiles, (same projectile),
                            Cooldown.Instance(3000, MultiAttack.Instance(25, 45*(float) Math.PI/180, 10, 0, 1)),
                            /* Green Slow Rings*/
                            Cooldown.Instance(3100, ThrowAttack.Instance(4, 8, 120)), /* Bomb 1*/
                            Cooldown.Instance(2000, ThrowAttack.Instance(3, 8, 70)), /* Bomb 2*/
                            Cooldown.Instance(2500, ThrowAttack.Instance(10, 12, 40)) /* Anti Spectate Bomb*/
                            )),
                    HpLesserPercent.Instance(0.1f, /*If Hp is less than 10%, activate behaviors (rage)*/
                        new RunBehaviors(
                            Flashing.Instance(500, 0xffff3333), /* Flash red when rage*/
                            MaintainDist.Instance(6, 5, 15, null),
                            /* This creates Geb's Skipping, he is maintaing distance from players*/
                            True.Instance(Once.Instance(SpawnMinionImmediate.Instance(0x7d1f, 1, 1, 4))),
                            //Artifact 1 (Circles Geb)
                            True.Instance(Once.Instance(SpawnMinionImmediate.Instance(0x7d20, 1, 1, 4))),
                            //Artifact 2 (Circles Bes and Nut)
                            True.Instance(Once.Instance(SpawnMinionImmediate.Instance(0x7d21, 1, 1, 4))),
                            //Artifact 3 (chases)
                            Cooldown.Instance(1000, MultiAttack.Instance(25, 10*(float) Math.PI/180, 2, 0, 2)),
                            Cooldown.Instance(4000, RingAttack.Instance(5, 0, 5, projectileIndex: 0)),
                            /*Just some random Black shots during rage.*/
                            Cooldown.Instance(500, AngleAttack.Instance(225)),
                            /*Just some random Black shots during rage.*/
                            Cooldown.Instance(500, AngleAttack.Instance(36)),
                            /*Just some random Black shots during rage.*/
                            Cooldown.Instance(500, AngleAttack.Instance(0)),
                            /*Just some random Black shots during rage.*/
                            Cooldown.Instance(500, AngleAttack.Instance(135)),
                            /*Just some random Black shots during rage.*/
                            Cooldown.Instance(500, AngleAttack.Instance(90)),
                            /*Just some random Black shots during rage.*/
                            Cooldown.Instance(1000, MultiAttack.Instance(25, 10*(float) Math.PI/180, 2, 0, 5)),
                            /*Fire Magic Shots.*/
                            Cooldown.Instance(3000, MultiAttack.Instance(25, 45*(float) Math.PI/180, 10, 0, 1)),
                            /*Green Slow Boomerang*/
                            Once.Instance(new SimpleTaunt("Argh! You shall pay for your crimes!")) /*Taunt for Rage*/
                            )
                        ),
                    HpLesserPercent.Instance(0.5f, /*If HP is less than 50%, run new behaviors*/
                        Once.Instance( /*Run theese commands ONCE, to prevent infinite Spawning.*/
                            new RunBehaviors(
                                Circling.Instance(5, 10, 5, 0x0d25),
                                True.Instance(
                                    Once.Instance(
                                        new SimpleTaunt("My artifacts shall destroy you from your soul to your flesh!"))),
                                /*Artifact Taunt.*/
                                Once.Instance(
                                    new RunBehaviors(
                                        SpawnMinionImmediate.Instance(0x7d1f, 3, 3, 4), //Spawn Artifact 1
                                        SpawnMinionImmediate.Instance(0x7d20, 3, 3, 4), //Spawn Artifact 2
                                        SpawnMinionImmediate.Instance(0x7d21, 3, 3, 4) //Spawn Artifact 3
                                        ))
                                )
                            )
                        )
                    ),
                loot: new LootBehavior(LootDef.Empty, //Class for loot.
                    Tuple.Create(100, new LootDef(0, 2, 0, 2,
                        Tuple.Create(0.01, (ILoot) new ItemLoot("Wine Cellar Incantation")),
                        Tuple.Create(0.1, (ILoot)new ItemLoot("Potion of Max Life")),
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Raw Hope")),
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Large Egyptian Cloth")),
                        Tuple.Create(0.01, (ILoot)new ItemLoot("Small Egyptian Cloth"))
                        ))
                    )
                ));
    }
}