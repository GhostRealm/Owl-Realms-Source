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
        static _ ElderSpiderDen = Behav()
            .Init(0x5936, Behaves("Elder Arachna the Spider Queen",
            new RunBehaviors(
                Cooldown.Instance(5000, ReturnSpawn.Instance(3)),
               If.Instance(IsEntityPresent.Instance(10, null), Once.Instance(new SetKey(-1, 1))),
                IfEqual.Instance(-1, 1,
                new QueuedBehavior(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                    Once.Instance(TossEnemy.Instance(0 * (float)Math.PI / 180, 6, 0x593d)),
                    Once.Instance(TossEnemy.Instance(120 * (float)Math.PI / 180, 6, 0x593e)),
                    Once.Instance(TossEnemy.Instance(240 * (float)Math.PI / 180, 6, 0x593f)),
                    Once.Instance(TossEnemy.Instance(0 * (float)Math.PI / 180, 10, 0x5937)),
                    Once.Instance(TossEnemy.Instance(60 * (float)Math.PI / 180, 10, 0x5938)),
                    Once.Instance(TossEnemy.Instance(120 * (float)Math.PI / 180, 10, 0x5939)),
                    Once.Instance(TossEnemy.Instance(180 * (float)Math.PI / 180, 10, 0x593a)),
                    Once.Instance(TossEnemy.Instance(240 * (float)Math.PI / 180, 10, 0x593b)),
                    Once.Instance(TossEnemy.Instance(300 * (float)Math.PI / 180, 10, 0x593c)),
                    Cooldown.Instance(3000),
                    Once.Instance(UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                    new SetKey(-1, 2),
                    Cooldown.Instance(5000)
                    )
                ),
                IfEqual.Instance(-1, 2,
                new RunBehaviors(
                    SimpleWandering.Instance(4, 3f),
                    Cooldown.Instance(3000, RingAttack.Instance(12, 0, 0, projectileIndex: 0)),
                    Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)),
                    Cooldown.Instance(2000, SimpleAttack.Instance(10, projectileIndex: 1))
                    )
                    )
                ),

                loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 0, 10,
                        Tuple.Create(0.5, (ILoot)new ItemLoot("Sword Shield")),
                        Tuple.Create(0.5, (ILoot)new ItemLoot("Log Slog"))
                            ))),
                        condBehaviors: new ConditionalBehavior[] {
                        new DeathPortal(0x6827, 100, 100)
                    }
                    ))
            .Init(0x5937, Behaves("Elder Arachna Web Spoke 1",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(180 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(120 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(240 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
            .Init(0x5938, Behaves("Elder Arachna Web Spoke 2",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(240 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(180 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(300 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
           .Init(0x5939, Behaves("Elder Arachna Web Spoke 3",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(300 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(240 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(0 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
           .Init(0x593a, Behaves("Elder Arachna Web Spoke 4",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(0 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(60 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(300 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
            .Init(0x593b, Behaves("Elder Arachna Web Spoke 5",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(60 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(0 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(120 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
           .Init(0x593c, Behaves("Elder Arachna Web Spoke 6",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(120 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(60 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(180 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
            .Init(0x593d, Behaves("Elder Arachna Web Spoke 7",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(180 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(120 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(240 * (float)Math.PI / 180, projectileIndex: 0))
                                )
                                ))
            .Init(0x593e, Behaves("Elder Arachna Web Spoke 8",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(360 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(240 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(300 * (float)Math.PI / 180, projectileIndex: 0))
                                )))
            .Init(0x593f, Behaves("Elder Arachna Web Spoke 9",
            new RunBehaviors(
                    Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                                Cooldown.Instance(150, AngleAttack.Instance(0 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(60 * (float)Math.PI / 180, projectileIndex: 0)),
                                Cooldown.Instance(150, AngleAttack.Instance(120 * (float)Math.PI / 180, projectileIndex: 0))
                                )))
            .Init(0x521c, Behaves("Elder Green Den Spider Hatchling",
            new RunBehaviors(
                SimpleWandering.Instance(2, 2f),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0))
                )))
            .Init(0x521d, Behaves("Elder Black Den Spider",
            new RunBehaviors(
                SimpleWandering.Instance(4, 3f),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0))
                )))
            .Init(0x521e, Behaves("Elder Red Spotted Den Spider",
            new RunBehaviors(
                SimpleWandering.Instance(4, 3f),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0))
                ),
                loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 0, 10,
                        Tuple.Create(0.2, (ILoot)new ItemLoot("Healing Ichor"))
                        ))))
                        )
             .Init(0x521f, Behaves("Elder Black Spotted Den Spider",
             new RunBehaviors(
                 SimpleWandering.Instance(4, 2f),
                 Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0))
                 ),
                 loot: new LootBehavior(LootDef.Empty,
                     Tuple.Create(100, new LootDef(0, 5, 0, 10,
                         Tuple.Create(0.2, (ILoot)new ItemLoot("Healing Ichor"))
                         ))))
                         )
             .Init(0x5220, Behaves("Elder Brown Den Spider",
             new RunBehaviors(
                 SimpleWandering.Instance(4, 3f),
                 Cooldown.Instance(1000, MultiAttack.Instance(10, 0, 3, 0, projectileIndex: 0))
                 ),
                 loot: new LootBehavior(LootDef.Empty,
                     Tuple.Create(100, new LootDef(0, 5, 0, 10,
                         Tuple.Create(0.6, (ILoot)new ItemLoot("Healing Ichor"))
                         ))))
                         )
             .Init(0x521b, Behaves("Elder Spider Egg Sac",
                 condBehaviors: new ConditionalBehavior[]
                 {
                 new DeathTransmute(0x521c, 3, 5)}
                 ))

                             .Init(0x5202, Behaves("Elder Red Spider",
                SimpleWandering.Instance(8),
                Cooldown.Instance(1000, SimpleAttack.Instance(9)),
                Reproduce.Instance(0x0202, 3, 45000, 15), new LootBehavior(
                    new LootDef(0, 2, 0, 8,
                        Tuple.Create(0.03, (ILoot)HpPotionLoot.Instance),
                        Tuple.Create(0.02, (ILoot)MpPotionLoot.Instance)
                        )
                    )
                ));
    }
}
