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
        private static _ ElderUndeadLair = Behav()
            .Init(0x5d90, Behaves("Elder Septavius the Ghost God",
                Once.Instance(SpawnMinionImmediate.Instance(0x6730, 0, 1, 1)),
                If.Instance(IsEntityPresent.Instance(8, null),
                    new RunBehaviors(
                        new RunBehaviors(
                            SmoothWandering.Instance(0.5f, 0.5f),
                            Once.Instance(SpawnMinionImmediate.Instance(0x0db0, 0, 4, 6)),
                            Once.Instance(SpawnMinionImmediate.Instance(0x0db1, 0, 4, 6)),
                            Once.Instance(SpawnMinionImmediate.Instance(0x0db2, 0, 4, 6))
                            ),
                        Once.Instance(IsEntityPresent.Instance(1, null)),
                        new QueuedBehavior(

                            #region Circle Attack 1

                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 0*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 18*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 36*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 54*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 72*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 90*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 108*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 126*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 144*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 162*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 180*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 198*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 216*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 234*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 252*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 270*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 288*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 306*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 324*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 342*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(250),
                            new RunBehaviors(
                                UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                RingAttack.Instance(3, offset: 360*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(100),

                            #endregion

                            #region Circle Attack 2
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 0*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 18*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 36*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 54*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 72*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 90*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 108*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 126*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 144*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 162*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 180*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 198*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 216*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 234*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 252*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                SimpleAttack.Instance(5, 3),
                                RingAttack.Instance(3, offset: 270*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                RingAttack.Instance(3, offset: 288*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 306*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 324*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(150),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 342*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(250),
                            new RunBehaviors(
                                RingAttack.Instance(3, offset: 360*(float) Math.PI/180)
                                ),
                            Cooldown.Instance(100),

                            #endregion
                            //not used
                            #region Circle Attack 3
                            /*Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),*/
                            #endregion

                            #region Circle Attack 4
                            /*Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),*/
                            #endregion
                            //end

                            #region RingAttack + Flashing 1

                            new QueuedBehavior(
                                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                Flashing.Instance(500, 0x0000FF0C),
                                Flashing.Instance(500, 0x0000FF0C),
                                Flashing.Instance(500, 0x0000FF0C),
                                Flashing.Instance(500, 0x0000FF0C),
                                Cooldown.Instance(2500, RingAttack.Instance(12, 10, 12, 3)),
                                Cooldown.Instance(2500, RingAttack.Instance(12, 10, 12, 3)),
                                Cooldown.Instance(2500, RingAttack.Instance(12, 10, 12, 3)),
                                Cooldown.Instance(2500, RingAttack.Instance(12, 10, 12, 3)),

                                #endregion

                                #region Flashing 2

                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                Flashing.Instance(200, 0x0000FF0C),
                                UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),

                                #endregion

                                #region Quite + Confuse
                                //confuse
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                //end confuse
                                //quite
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 0*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 90*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 180*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 270*(float) Math.PI/180, 1)),
                                //end quite
                                //confuse
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                //end confuse
                                //quite
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 360*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 0*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 90*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 180*(float) Math.PI/180, 1)),
                                //end quite
                                //confuse
                                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                //end confuse
                                //quite
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 270*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 360*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 0*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 90*(float) Math.PI/180, 1)),
                                //end quite
                                //confuse
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                //end confuse
                                //quite
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 180*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 270*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 360*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 0*(float) Math.PI/180, 1)),
                                //end quite
                                //confuse
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                //end confuse
                                //quite
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 90*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 180*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 270*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 360*(float) Math.PI/180, 1)),
                                //end quite
                                //confuse
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                //end confuse
                                //quite
                                SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 0*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 90*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 180*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 270*(float) Math.PI/180, 1)),
                                //end quite
                                //confuse
                                MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 2),
                                //end confuse
                                //quite
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 360*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 0*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 90*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 180*(float) Math.PI/180, 1)),
                                Cooldown.Instance(500, RingAttack.Instance(10, 10, 270*(float) Math.PI/180, 1)),
                                //end quite

                                Cooldown.Instance(1500),
                                UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),

                                #endregion


                                #region Spawn Minions + Circleshoot

                                #region Spawn Minions

                                //SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                                //IsEntityNotPresent.Instance(100, 0x0db0),
                                //IsEntityNotPresent.Instance(100, 0x0db1),
                                //IsEntityNotPresent.Instance(100, 0x0db2),
                                //UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),

                                SpawnMinionImmediate.Instance(0x0db0, 0, 4, 6),
                                SpawnMinionImmediate.Instance(0x0db1, 0, 4, 6),
                                SpawnMinionImmediate.Instance(0x0db2, 0, 4, 6),

                                #endregion

                                #region Circleshoot

                                #region Circle Attack 1

                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 0*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 18*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 36*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 54*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 72*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 90*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 108*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 126*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 144*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 162*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 180*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 198*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 216*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 234*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 252*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 270*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 288*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 306*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 324*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 342*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(250),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 360*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(100),

                                #endregion

                                #region Circle Attack 2

                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 0*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 18*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 36*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 54*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 72*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 90*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 108*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 126*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 144*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 162*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 180*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 198*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 216*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 234*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 252*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    MultiAttack.Instance(5, 1*(float) Math.PI/30, 3, 0, 4),
                                    RingAttack.Instance(3, offset: 270*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 288*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 306*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 324*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(150),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 342*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(250),
                                new RunBehaviors(
                                    RingAttack.Instance(3, offset: 360*(float) Math.PI/180)
                                    ),
                                Cooldown.Instance(1100))
                            #endregion

                            #endregion

                            #endregion

                            ))),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(800, new LootDef(0, 5, 1, 2,
                        Tuple.Create(0.001, (ILoot) new ItemLoot("Double Doom Bow")),
                        Tuple.Create(0.001, (ILoot)new ItemLoot("Seal of the Fallen Angel")),
                        Tuple.Create(0.0001, (ILoot)new ItemLoot("Sword of Ghostly Power")),
                        Tuple.Create(0.0005, (ILoot)new ItemLoot("Soul Mask")),
                        Tuple.Create(0.0004, (ILoot)new ItemLoot("Soul Spawned Armor")),
                        Tuple.Create(0.0009, (ILoot)new ItemLoot("Soul Tipped Dirk")),
                        Tuple.Create(0.005, (ILoot) new ItemLoot("Wine Cellar Incantation")),
                        Tuple.Create(1.0, (ILoot)new ItemLoot("Potion of Max Wisdom")),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(4, ItemType.Ring)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ability)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(4, ItemType.Ability)),
                        Tuple.Create(0.01, (ILoot) new TierLoot(5, ItemType.Ability))
                        ))
                    )
                    ,
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathPortal(0x6837, 100, -1)
                }
                ))
            .Init(0x5dab, Behaves("Elder Lair Ghost Warrior",
                new RunBehaviors(
                    Chasing.Instance(8, 10, 1, null),
                    Cooldown.Instance(500, SimpleAttack.Instance(12))
                    )
                ))
            .Init(0x5db0, Behaves("Elder Ghost Warrior of Septavius",
                IfNot.Instance(
                    Chasing.Instance(12, 7, 1, null),
                    IfNot.Instance(
                        Chasing.Instance(10, 7, 1, 0x5d90),
                        SimpleWandering.Instance(4f)
                        )
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.6, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5db1, Behaves("Elder Ghost Mage of Septavius",
                IfNot.Instance(
                    Chasing.Instance(12, 7, 1, null),
                    IfNot.Instance(
                        Chasing.Instance(10, 7, 1, 0x5d90),
                        SimpleWandering.Instance(4f)
                        )
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.6, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5db2, Behaves("Elder Ghost Rogue of Septavius",
                IfNot.Instance(
                    Chasing.Instance(12, 7, 1, null),
                    IfNot.Instance(
                        Chasing.Instance(10, 7, 1, 0x5d90),
                        SimpleWandering.Instance(4f)
                        )
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.6, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d91, Behaves("Elder Lair Skeleton",
                IfNot.Instance(
                    Chasing.Instance(13, 7, 1, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d95, Behaves("Elder Lair Skeleton King",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 7, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.3, (ILoot) new TierLoot(5, ItemType.Armor))
                        ),
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(6, ItemType.Weapon)),
                        Tuple.Create(0.1, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.09, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(6, ItemType.Armor)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(7, ItemType.Armor)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(3, ItemType.Ability))
                        )
                        ))
                ))
            .Init(0x5d94, Behaves("Elder Lair Skeleton Mage",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 7, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d93, Behaves("Elder Lair Skeleton Veteran",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 7, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d92, Behaves("Elder Lair Skeleton Swordsman",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 1, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d96, Behaves("Elder Lair Mummy",
                IfNot.Instance(
                    Chasing.Instance(12, 10, 7, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d97, Behaves("Elder Lair Mummy King",
                IfNot.Instance(
                    Chasing.Instance(12, 10, 7, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d98, Behaves("Elder Lair Mummy Pharaoh",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 1, null),
                    SimpleWandering.Instance(4f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.3, (ILoot) new TierLoot(5, ItemType.Armor))
                        ),
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(6, ItemType.Weapon)),
                        Tuple.Create(0.1, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.09, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(6, ItemType.Armor)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(7, ItemType.Armor)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(3, ItemType.Ability))
                        )
                        ))
                ))
            .Init(0x5d9e, Behaves("Elder Lair Big Brown Slime",
                new RunBehaviors(
                    SimpleWandering.Instance(2f),
                    Cooldown.Instance(500, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0))
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathTransmute(0x5d9f, 6, 6)
                }
                ))
            .Init(0x5d9f, Behaves("Elder Lair Little Brown Slime",
                IfNot.Instance(
                    Chasing.Instance(12, 10, 1, 0x5d9e),
                    SimpleWandering.Instance(2f)
                    ),
                Cooldown.Instance(500, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d9b, Behaves("Elder Lair Big Black Slime",
                new RunBehaviors(
                    SimpleWandering.Instance(2f),
                    Cooldown.Instance(500, SimpleAttack.Instance(10, projectileIndex: 0))
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathTransmute(0x5d9c, 4, 4)
                }
                ))
            .Init(0x5d9c, Behaves("Elder Lair Medium Black Slime",
                IfNot.Instance(
                    Chasing.Instance(12, 10, 1, 0x5d9b),
                    SimpleWandering.Instance(2f)
                    ),
                Cooldown.Instance(500, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathTransmute(0x5d9d, 4, 4)
                }
                ))
            .Init(0x5d9d, Behaves("Elder Lair Little Black Slime",
                IfNot.Instance(
                    Chasing.Instance(12, 10, 1, 0x5d9b),
                    IfNot.Instance(
                        Chasing.Instance(12, 10, 1, 0x5d9c),
                        SimpleWandering.Instance(2f)
                        )
                    ),
                Cooldown.Instance(500, SimpleAttack.Instance(10, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5d99, Behaves("Elder Lair Construct Giant",
                new RunBehaviors(
                    IfNot.Instance(
                        Chasing.Instance(13, 10, 7, null),
                        SimpleWandering.Instance(4f)
                        ),
                    Cooldown.Instance(1000, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0)),
                    Cooldown.Instance(1000, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 1))
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.3, (ILoot) new TierLoot(5, ItemType.Armor))
                        ),
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(6, ItemType.Weapon)),
                        Tuple.Create(0.1, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.09, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(6, ItemType.Armor)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(7, ItemType.Armor)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(3, ItemType.Ability)),
                        Tuple.Create(0.005, (ILoot) new ItemLoot("Purple Drake Egg"))
                        )
                        ))
                ))
            .Init(0x5d9a, Behaves("Elder Lair Construct Titan",
                new RunBehaviors(
                    IfNot.Instance(
                        Chasing.Instance(13, 10, 7, null),
                        SimpleWandering.Instance(4f)
                        ),
                    Cooldown.Instance(1000, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, projectileIndex: 0)),
                    Cooldown.Instance(1000, MultiAttack.Instance(10, 1*(float) Math.PI/30, 3, 0, 1))
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.3, (ILoot) new TierLoot(5, ItemType.Armor))
                        ),
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(6, ItemType.Weapon)),
                        Tuple.Create(0.1, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.09, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(6, ItemType.Armor)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(7, ItemType.Armor)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(3, ItemType.Ability)),
                        Tuple.Create(0.005, (ILoot) new ItemLoot("Purple Drake Egg"))
                        )
                        ))
                ))
            .Init(0x5da0, Behaves("Elder Lair Brown Bat",
                new RunBehaviors(
                    IfNot.Instance(
                        Cooldown.Instance(2000, Charge.Instance(40, 10, null)),
                        SimpleWandering.Instance(2f)
                        ),
                    Cooldown.Instance(1000, SimpleAttack.Instance(2, projectileIndex: 0))
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5da1, Behaves("Elder Lair Ghost Bat",
                new RunBehaviors(
                    IfNot.Instance(
                        Cooldown.Instance(2000, Charge.Instance(40, 10, null)),
                        SimpleWandering.Instance(2f)
                        ),
                    Cooldown.Instance(1000, SimpleAttack.Instance(2, projectileIndex: 0))
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                        ))
                ))
            .Init(0x5da4, Behaves("Elder Lair Reaper",
                IfNot.Instance(
                    Chasing.Instance(15, 10, 1, null),
                    SimpleWandering.Instance(2f)
                    ),
                Cooldown.Instance(1000, SimpleAttack.Instance(3, projectileIndex: 0)
                    ),
                loot: new LootBehavior(
                    new LootDef(0, 1, 0, 8,
                        Tuple.Create(0.3, (ILoot) new TierLoot(5, ItemType.Armor))
                        ),
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(6, ItemType.Weapon)),
                        Tuple.Create(0.1, (ILoot) new TierLoot(7, ItemType.Weapon)),
                        Tuple.Create(0.09, (ILoot) new TierLoot(8, ItemType.Weapon)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(6, ItemType.Armor)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(7, ItemType.Armor)),
                        Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                        Tuple.Create(0.2, (ILoot) new TierLoot(3, ItemType.Ability))
                        )
                        ))
                ))
            .Init(0x5da5, Behaves("Elder Lair Vampire",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 1, null),
                    SimpleWandering.Instance(2f)
                    ),
                Cooldown.Instance(500, SimpleAttack.Instance(20, projectileIndex: 0)),
                Cooldown.Instance(1000, SimpleAttack.Instance(2, 1)
                    ), new LootBehavior(
                        new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot) PotionLoot.Instance)
                            ))
                ))
            .Init(0x5da6, Behaves("Elder Lair Vampire King",
                IfNot.Instance(
                    Chasing.Instance(13, 10, 1, null),
                    SimpleWandering.Instance(2f)
                    ),
                Cooldown.Instance(500, SimpleAttack.Instance(20, projectileIndex: 0)),
                Cooldown.Instance(1000, SimpleAttack.Instance(2, 1)
                    ), new LootBehavior(
                        new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.3, (ILoot) new TierLoot(5, ItemType.Armor))
                            ),
                        Tuple.Create(100, new LootDef(0, 1, 0, 2,
                            Tuple.Create(0.2, (ILoot) new TierLoot(6, ItemType.Weapon)),
                            Tuple.Create(0.1, (ILoot) new TierLoot(7, ItemType.Weapon)),
                            Tuple.Create(0.09, (ILoot) new TierLoot(8, ItemType.Weapon)),
                            Tuple.Create(0.3, (ILoot) new TierLoot(6, ItemType.Armor)),
                            Tuple.Create(0.2, (ILoot) new TierLoot(7, ItemType.Armor)),
                            Tuple.Create(0.3, (ILoot) new TierLoot(3, ItemType.Ring)),
                            Tuple.Create(0.2, (ILoot) new TierLoot(3, ItemType.Ability))
                            )
                            ))
                ))
            .Init(0x5da7, Behaves("Elder Lair Grey Spectre",
                new RunBehaviors(
                    SimpleWandering.Instance(2f),
                    Cooldown.Instance(1000, SimpleAttack.Instance(14, projectileIndex: 0)),
                    Cooldown.Instance(1000, ThrowAttack.Instance(2, 8, 50))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(4, ItemType.Ability))
                        )))
                ))
            .Init(0x5da8, Behaves("Elder Lair Blue Spectre",
                new RunBehaviors(
                    SimpleWandering.Instance(2f),
                    Cooldown.Instance(1000, SimpleAttack.Instance(14, projectileIndex: 0)),
                    Cooldown.Instance(1000, ThrowAttack.Instance(2, 8, 90))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(4, ItemType.Ability))
                        )))
                ))
            .Init(0x5da9, Behaves("Elder Lair White Spectre",
                new RunBehaviors(
                    SimpleWandering.Instance(2f),
                    Cooldown.Instance(1000, SimpleAttack.Instance(14, projectileIndex: 0)),
                    Cooldown.Instance(1000, ThrowAttack.Instance(2, 8, 90))
                    ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 1, 0, 2,
                        Tuple.Create(0.2, (ILoot) new TierLoot(4, ItemType.Ability))
                        )))
                ))
            .Init(0x5da3, Behaves("Elder Lair Blast Trap",
                attack: new RunBehaviors(
                    If.Instance(
                        IsEntityPresent.Instance(5, null),
                        new QueuedBehavior(
                            MultiAttack.Instance(8, 10*(float) Math.PI/180, 6),
                            Die.Instance
                            )
                        )
                    )
                ))
            .Init(0x5da2, Behaves("Elder Lair Burst Trap",
                attack: new RunBehaviors(
                    If.Instance(
                        IsEntityPresent.Instance(5, null),
                        new QueuedBehavior(
                            MultiAttack.Instance(8, 10*(float) Math.PI/180, 6),
                            Die.Instance
                            )
                        )
                    )
                ))
            .Init(0x6730, Behaves("Elder Septavius Summoner",
                new QueuedBehavior(
                    SetConditionEffect.Instance(ConditionEffectIndex.Invincible),
                    Cooldown.Instance(2000),
                    new SetKey(-1, 1)),
                IfEqual.Instance(-1, 1,
                    If.Instance(IsEntityNotPresent.Instance(100, 0x5d90), Die.Instance)
                    ),
                condBehaviors: new ConditionalBehavior[]
                {
           //         new DeathPortal(0x6837, 100, -1)
                }
                ))
            ;
    }
}