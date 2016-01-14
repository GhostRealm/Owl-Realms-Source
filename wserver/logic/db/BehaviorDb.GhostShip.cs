//by pLolz
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
        static _ Ghosting = Behav()
            .Init(0x0e4f, Behaves("Water Mine",
            IfNot.Instance(
            Chasing.Instance(3, 4, 1, null),
            SimpleWandering.Instance(3, 1f)
            ),
            new RunBehaviors(
                Once.Instance(new SetKey(-1,0)),

                IfEqual.Instance(-1,0,
                new QueuedBehavior(
                    CooldownExact.Instance(900),
                    new SetKey(-1,1)
                    )),
                IfEqual.Instance(-1,1,If.Instance(IsEntityPresent.Instance(4, null), new SetKey(-1, 2)
                )),
                IfEqual.Instance(-1, 2,
                new QueuedBehavior(
                    RingAttack.Instance(10, 15, 0, 0),
                    CooldownExact.Instance(1),
                    Die.Instance
                    ))
                )
                    
            ))
            .Init(0x0e3c, Behaves("Beach Spectre Spawner",
            new RunBehaviors(
                SetConditionEffect.Instance(ConditionEffectIndex.Invincible),
                If.Instance(And.Instance(IsEntityPresent.Instance(40,null),EntityLesserThan.Instance(10,1,0x0e3d)), SpawnMinion.Instance(0x0e3d, 1, 100, 1000, 1500))
                )
            ))
            .Init(0x0e3d, Behaves("Beach Spectre",
            new RunBehaviors(
                Once.Instance(new SetKey(-1, 1)),
                IfEqual.Instance(-1, 1,
                new QueuedBehavior(
                    SetSize.Instance(60),
                    CooldownExact.Instance(300),
                    SetSize.Instance(80),
                    CooldownExact.Instance(300),
                    SetSize.Instance(100),
                    CooldownExact.Instance(350),
                    new SetKey(-1, 2),
                    CooldownExact.Instance(-1)
                    )),
                IfEqual.Instance(-1, 2,
                new RunBehaviors(
                    CooldownExact.Instance(1500, MultiAttack.Instance(9, 15 * (float)Math.PI / 360, 3, 0, 0))
                    )),
                IfEqual.Instance(-1, 2, SimpleWandering.Instance(2, .2f)
                   ),
                IfEqual.Instance(-1,2, Circling.Instance((float)1.2,5,(float)0.3,0xe3c)
                 )
                )
            ))
            .Init(0x0e39, Behaves("Vengeful Spirit",
            Circling.Instance(6, 10, 12, 0x0e37),
            new RunBehaviors(
                Once.Instance(SetSize.Instance(100)),
                Cooldown.Instance(1500, MultiAttack.Instance(9, 15 * (float)Math.PI / 360, 3, 0, 0))
                )
            ))
            .Init(0x0e37, Behaves("Ghost Ship",
            new RunBehaviors(


                HpLesser.Instance(65000, Once.Instance(new SetKey(-1, 1))

                ),
                   #region EffectParams
                    HpLesser.Instance(65000, new QueuedBehavior(
                    If.Instance(EntityLesserThan.Instance(30,6,0x0e4f),SpawnMinionImmediate.Instance(0x0e4f, 1, 1, 2)),
                    SetAltTexture.Instance(2),
                    CooldownExact.Instance(800),
                    SetAltTexture.Instance(0),
                    CooldownExact.Instance(4000)
                    )),
               HpLesser.Instance(65000, new QueuedBehavior(
                    If.Instance(EntityLesserThan.Instance(30,3,0x0e39),SpawnMinionImmediate.Instance(0x0e39, 1, 1, 1)),
                    SetAltTexture.Instance(2),
                    CooldownExact.Instance(800),
                    SetAltTexture.Instance(0),
                    CooldownExact.Instance(7900)
                    )),
#endregion
                   #region movement params
               IfEqual.Instance(-1,1, SmoothWandering.Instance(0,0)),
               IfEqual.Instance(-1,2, SmoothWandering.Instance(5,2)),
               IfEqual.Instance(-1,3, SmoothWandering.Instance(5,2)),
               IfEqual.Instance(-1,4, SmoothWandering.Instance(4,2)),
               IfEqual.Instance(-1,5, SmoothWandering.Instance(5,2)),
               IfEqual.Instance(-1,6, SmoothWandering.Instance(5,2)),
               IfEqual.Instance(-1,7, SmoothWandering.Instance(5,2)),
               IfEqual.Instance(-1,8, SmoothWandering.Instance(0,0)),
               IfEqual.Instance(-1,8, ReturnSpawn.Instance(20)),
                      #endregion

                IfEqual.Instance(-1, 1,
                new QueuedBehavior(
                    SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                    CooldownExact.Instance(1100),
                    new SetKey(-1, 2),
                    CooldownExact.Instance(-1)
                    )),
                IfEqual.Instance(-1, 2,
                new QueuedBehavior(
                    new SimpleTaunt("Fire at will!!!"),
                    CooldownExact.Instance(10),
                    new SetKey(-1, 3),
                    CooldownExact.Instance(-1)
                    )),
                IfEqual.Instance(-1, 3,
                new RunBehaviors(
                    new QueuedBehavior(
                        CooldownExact.Instance(3000),
                        UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)
                        ),
                    new QueuedBehavior(
                   CooldownExact.Instance(700),
                   SimpleAttack.Instance(15, 0),
                   CooldownExact.Instance(700),
                   SimpleAttack.Instance(15, 0),
                   CooldownExact.Instance(700),
                   SimpleAttack.Instance(15, 0),
                   CooldownExact.Instance(700),
                   MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 0)
                   ),
                   new QueuedBehavior(
                       CooldownExact.Instance(9000),
                       new SetKey(-1, 4)
                       ),
                       new QueuedBehavior(
                        HpLesser.Instance(30000, new SetKey(-1, 5)
                        ))
                    )
                ),
                IfEqual.Instance(-1, 4,
                new RunBehaviors(
                    new QueuedBehavior(
                        CooldownExact.Instance(700),        //a pretty weird thingy her
                        RingAttack.Instance(4, 15, 0, 0),
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0),
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 1)
                        ),
                    new QueuedBehavior(
                        HpLesser.Instance(30000, new SetKey(-1, 5)
                        )),
                    new QueuedBehavior(
                        CooldownExact.Instance(5600),
                        new SetKey(-1,3)
                        ))
                    ),
                IfEqual.Instance(-1, 5,
                new RunBehaviors(
                    Once.Instance(OrderAllEntity.Instance(15, 0x0e38,new SetKey(-1,1))),
                    new QueuedBehavior(

                        RingAttack.Instance(4, 15, 0, 0), //1
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 1), //4

                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //1
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 1), //4

                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //1
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 2, 0, 1), //4

                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 1),
                        CooldownExact.Instance(700),

                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 2, 0, 1),
                        CooldownExact.Instance(700),

                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 1)
                        ),
                        new QueuedBehavior(
                            HpLesser.Instance(25000, OrderAllEntity.Instance(50, 0x0e38, new SetKey(-1, 5))
                            )
                        ),
                        new QueuedBehavior(
                            CooldownExact.Instance(6500),
                            new SetKey(-1, 6)
                    ),
                      new QueuedBehavior(
                          SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          CooldownExact.Instance(5000),
                          UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          CooldownExact.Instance(4000)
                          )
                )),
                IfEqual.Instance(-1, 6,
                new RunBehaviors(
                    new QueuedBehavior(
        #region Ring-Simple
                        RingAttack.Instance(4, 15, 0, 0), //1
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 1),

                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //1 
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 1), //4

                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //1
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0),//2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 35 * (float)Math.PI / 360, 3, 0, 1),

                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //1
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //2
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //3
                        CooldownExact.Instance(700),
                        RingAttack.Instance(4, 15, 0, 0), //4
                        SimpleAttack.Instance(15, 1), //5/4
        #endregion
                        CooldownExact.Instance(700),
        #region Simple-Multi
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 1),
                        CooldownExact.Instance(700),

                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 1),
                        CooldownExact.Instance(700),

                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 1),
                        CooldownExact.Instance(700),

                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        SimpleAttack.Instance(15, 0),
                        CooldownExact.Instance(700),
                        MultiAttack.Instance(15, 15 * (float)Math.PI / 360, 3, 0, 1),
                        CooldownExact.Instance(700)
        #endregion
                       ),
                      new QueuedBehavior(
                          CooldownExact.Instance(11000),
                          new SetKey(-1, 7)
                          ),
                      new QueuedBehavior(
                          SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          CooldownExact.Instance(5000),
                          UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          CooldownExact.Instance(4000)
                          )
                       )),

        #region aim fire
                    IfEqual.Instance(-1, 7,
                    new QueuedBehavior(
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        new SimpleTaunt("Ready.."),
                        CooldownExact.Instance(1000),
                        new SimpleTaunt("Aim..."),
                        CooldownExact.Instance(1000),
                        new SimpleTaunt("FIRE!!!"),
                        CooldownExact.Instance(10),
                        UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        new SetKey(-1, 8),
                        CooldownExact.Instance(-1) // ANTI REPEAT
                        )),
               IfEqual.Instance(-1, 8,
               new RunBehaviors(
                   new QueuedBehavior(
                   RingAttack.Instance(10, 15, 0, 0),
                   CooldownExact.Instance(500),
                   RingAttack.Instance(10, 15, 0, 0),
                   CooldownExact.Instance(500),
                   RingAttack.Instance(10, 15, 0, 0),
                   CooldownExact.Instance(300),
                   RingAttack.Instance(4, 15, 0, 1),
                   CooldownExact.Instance(300),
                   RingAttack.Instance(4, 15, 0, 1),
                   CooldownExact.Instance(900)
                   ),
                   new QueuedBehavior(
                       CooldownExact.Instance(2100),
                       new SetKey(-1, 6)
                )
            )
        )
        #endregion
            //<Object type="0x0e38" id="Ghost Ship Anchor">
),
                loot: new LootBehavior(LootDef.Empty,
                       Tuple.Create(360, new LootDef(0, 2, 0, 1,
                            Tuple.Create(0.5, (ILoot)new ItemLoot("Ghost Pirate Rum"))
                            )),
                        Tuple.Create(360, new LootDef(0, 3, 0, 2,
                            Tuple.Create(0.5, (ILoot)new StatPotionLoot(StatPotion.Wis)),

                            Tuple.Create(0.025, (ILoot)new TierLoot(11, ItemType.Weapon)),
                            Tuple.Create(0.025, (ILoot)new TierLoot(12, ItemType.Armor)),
                            Tuple.Create(0.025, (ILoot)new TierLoot(5, ItemType.Ability))

                            )))
                        ))
                    .Init(0x0e38, Behaves("Ghost Ship Anchor",
                    new RunBehaviors(
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(0 * (float)Math.PI / 180, 9.5f, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(90 * (float)Math.PI / 180, 9.5f, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(180 * (float)Math.PI / 180, 9.5f, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(270 * (float)Math.PI / 180, 9.5f, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(45 * (float)Math.PI / 180, 10, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(135 * (float)Math.PI / 180, 10, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(225 * (float)Math.PI / 180, 10, 0x0e3c, 1, 1)),
                        Once.Instance(SpawnMinnionImmediateAngled.Instance(315 * (float)Math.PI / 180, 10, 0x0e3c, 1, 1)),
                        Once.Instance(new SetKey(-1,0)),
                        IfEqual.Instance(-1,0,
                        new QueuedBehavior(
                            SetConditionEffect.Instance(ConditionEffectIndex.Invincible)
                            )),
                        IfEqual.Instance(-1,1,
                        new QueuedBehavior(
                            SpawnMinnionImmediateAngled.Instance(0 * (float)Math.PI / 180, 9.5f,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(90 * (float)Math.PI / 180, 9.5f,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(180 * (float)Math.PI / 180, 9.5f,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(270 * (float)Math.PI / 180, 9.5f,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(45 * (float)Math.PI / 180, 10,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(135 * (float)Math.PI / 180, 10,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(225 * (float)Math.PI / 180, 10,0x0e3b,1,1),
                            SpawnMinnionImmediateAngled.Instance(315 * (float)Math.PI / 180, 10,0x0e3b,1,1),
                            new SetKey(-1,2),
                            CooldownExact.Instance(-1)
                            ))
                        )
                ))

                .Init(0x0e3b, Behaves("Tempest Cloud",
                new RunBehaviors(
                    Once.Instance(new SetKey(-1,0)),

                    IfEqual.Instance(-1,0, //ENLARGE MA MINNION!!!!
                    new QueuedBehavior(
                        SetConditionEffect.Instance(ConditionEffectIndex.Invincible),
                        SetSize.Instance(139),
                        SetAltTexture.Instance(1),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(2),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(3),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(4),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(5),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(6),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(7),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(8),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(9),
                        CooldownExact.Instance(150),
                        new SetKey(-1,1),
                        CooldownExact.Instance(-1) // Never repeat ma friend....
                        )),

                        IfEqual.Instance(-1,2, StrictCircling.Instance(9.5f,2,0x0e38)),

                        IfEqual.Instance(-1,1,
                        new QueuedBehavior(
                            CooldownExact.Instance(650),
                            new SetKey(-1,2),
                            CooldownExact.Instance(-1)
                            )),
                           IfEqual.Instance(-1,2,
                           new RunBehaviors(
                             new RunBehaviors(
                            CooldownExact.Instance(1000, RingAttack.Instance(5,15,0,0))
                            ),
                             new RunBehaviors(
                                 If.Instance(IsEntityNotPresent.Instance(15, 0x0e37), new SetKey(-1,3))
                                 ))
                                ),
                            IfEqual.Instance(-1,3,
                            new QueuedBehavior(
                           SetAltTexture.Instance(8),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(7),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(6),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(5),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(4),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(3),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(2),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(1),
                        CooldownExact.Instance(150),
                        SetAltTexture.Instance(0),
                        CooldownExact.Instance(150),
                        Die.Instance
                          ))
                        )
                ))
                        
                        

            ;
    }
}   
