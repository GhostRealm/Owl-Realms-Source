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
        static _ StoneG = Behav()

                 .Init(0x0d78, Behaves("Oryx Stone Guardian Right",
                 new RunBehaviors(
                 SmoothWandering.Instance(2f, 2f),
                 Cooldown.Instance(800, MultiAttack.Instance(200, 40 * (float)Math.PI / 360, 4, 0, projectileIndex: 2)),
                 Cooldown.Instance(900, MultiAttack.Instance(200, 55 * (float)Math.PI / 360, 6, 0, projectileIndex: 1)),
                 Cooldown.Instance(850, MultiAttack.Instance(200, 70 * (float)Math.PI / 360, 4, 0, projectileIndex: 0))
                 ),
                 loot: new LootBehavior(LootDef.Empty,
                 Tuple.Create(100, new LootDef(0, 3, 0, 8,
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Ancient Stone Sword")),
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Deathnaught Quiver")),
                 Tuple.Create(0.1, (ILoot)new ItemLoot("Wine Cellar Incantation")),
                 Tuple.Create(0.06, (ILoot)new ItemLoot("Large Grey Scaly Cloth")),
                 Tuple.Create(0.06, (ILoot)new ItemLoot("Small Stony Cloth"))
                 )))))

                 .Init(0x0d79, Behaves("Oryx Stone Guardian Left",
                 new RunBehaviors(
                 SmoothWandering.Instance(2f, 2f),
                 Cooldown.Instance(800, MultiAttack.Instance(200, 40 * (float)Math.PI / 360, 4, 0, projectileIndex: 2)),
                 Cooldown.Instance(900, MultiAttack.Instance(200, 55 * (float)Math.PI / 360, 6, 0, projectileIndex: 1)),
                 Cooldown.Instance(850, MultiAttack.Instance(200, 70 * (float)Math.PI / 360, 4, 0, projectileIndex: 0))
                 ),
                 loot: new LootBehavior(LootDef.Empty,
                 Tuple.Create(100, new LootDef(0, 3, 0, 8,
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Ancient Stone Sword")),
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Deathnaught Quiver")),
                                         Tuple.Create(0.1, (ILoot)new ItemLoot("Wine Cellar Incantation")),
                 Tuple.Create(0.06, (ILoot)new ItemLoot("Small Grey Scaly Cloth")),
                 Tuple.Create(0.06, (ILoot)new ItemLoot("Large Stony Cloth"))
                 )))));
    }
}