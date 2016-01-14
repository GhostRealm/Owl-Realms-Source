//added for test... maked by sparzinrotmg
//find in xml f.e.r.a.l. and change damage in projectiles
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
        static _ FERAL = Behav()
            .Init(0x099a, Behaves("F.E.R.A.L.",

            new RunBehaviors(
                MaintainDist.Instance(2, 2, 3, null),
                Cooldown.Instance(1500, RingAttack.Instance(10, 7, 0, projectileIndex: 1)),
                  HpLesserPercent.Instance(0.3f,
                     new RunBehaviors(
                         Once.Instance(SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                         Cooldown.Instance(1500, Once.Instance(new SimpleTaunt("F.E.R.A.L.  Rage Mode Activated!"))),
                         Cooldown.Instance(1500, Once.Instance(UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable))),
                         //Cooldown.Instance(1000, RingAttack.Instance(10, 7, 0, projectileIndex: 2)), BUG = CRASHING WSERVER\\
                         Charge.Instance(7, 7, null)

                    )
                )
                ),
                loot: new LootBehavior(LootDef.Empty,
                    Tuple.Create(100, new LootDef(0, 2, 0, 2,
                        Tuple.Create(0.5, (ILoot) new StatPotionLoot(StatPotion.Def)),
                        Tuple.Create(0.5, (ILoot) new StatPotionLoot(StatPotion.Vit)),
                        Tuple.Create(0.5, (ILoot) new StatPotionLoot(StatPotion.Wis)),
                        Tuple.Create(0.5, (ILoot) new StatPotionLoot(StatPotion.Dex)),
                        Tuple.Create(0.5, (ILoot) new StatPotionLoot(StatPotion.Att)),
                        Tuple.Create(0.5, (ILoot) new StatPotionLoot(StatPotion.Spd))
                        )))

            ));
    }
}