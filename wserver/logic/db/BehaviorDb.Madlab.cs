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
        static _ Madlab = Behav()
            .Init(0x0976, Behaves("Dr Terrible",
                    new RunBehaviors(
                        Cooldown.Instance(3000, TossEnemy.Instance(0f, 4f, 0x0978)),
                        Cooldown.Instance(10000, TossEnemy.Instance(0f, 4f, 0x1e25)),
                        Cooldown.Instance(15000, TossEnemy.Instance(0f, 4f, 0x1e24)),
                        Cooldown.Instance(15000, TossEnemy.Instance(0f, 4f, 0x1e23)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "I will kill you")
                        )
                    ),
                        loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Conducting Wand")),
                            Tuple.Create(0.06, (ILoot)new ItemLoot("Large Futuristic Cloth")),
                            Tuple.Create(0.06, (ILoot)new ItemLoot("Small Futuristic Cloth")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Robe of the Mad Scientist")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Experimental Ring")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Scepter of Fulmination"))
                ))),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathPortal(0x0704, 100, -1)
                }
                ))
        .Init(0x5e1c, Behaves("Horrific Creation",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 1)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Blarga"),
                            new RandomTaunt(0.001, "blalklj;fdk")
                        )
                    ),
                        loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 1, 0, 8,
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Conducting Wand")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Robe of the Mad Scientist")),
                            Tuple.Create(0.5, (ILoot)new ItemLoot("Experimental Ring")),
                            Tuple.Create(0.05, (ILoot)new ItemLoot("Horrific Creation Generator")),
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Scepter of Fulmination"))
                ))),
                condBehaviors: new ConditionalBehavior[]
                {
                    new DeathPortal(0x0704, 100, -1)
                }
                ))
        .Init(0x0982, Behaves("Enforcer Bot 3000",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 1)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x0983, Behaves("Crusher Abomination",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 1)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x0979, Behaves("Mini Bot",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x1e25, Behaves("Dr Terrible Mini Bot",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x0980, Behaves("Rampage Cyborg",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x1e24, Behaves("Dr Terrible Rampage Cyborg",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x0981, Behaves("Escaped Experiment",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ))
        .Init(0x1e23, Behaves("Dr Terrible Escaped Experiment",
                    new RunBehaviors(
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 4, 0, projectileIndex: 0)),
                        SimpleWandering.Instance(2, 2)
                    ),
                    Cooldown.Instance(1000,
                        Rand.Instance(
                            new RandomTaunt(0.001, "Die"),
                            new RandomTaunt(0.001, "baa baa")
                        )
                    )
                ));
    }
}