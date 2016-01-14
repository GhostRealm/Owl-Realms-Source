using System;
using wServer.logic.attack;
using wServer.logic.loot;
using wServer.logic.movement;
using wServer.logic.taunt;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ Belladonna = Behav()
            .Init(0x738c, Behaves("vlntns Botany Bella",
                  new RunBehaviors(
                      Once.Instance(new SetKey(-1, 1)),
                      IfEqual.Instance(-1, 1,
                          new RunBehaviors(
                              SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                              If.Instance(IsEntityPresent.Instance(3, null), new SetKey(-1, 2))
                              )),
                      IfEqual.Instance(-1, 2,
                          new RunBehaviors(
                              UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                              Once.Instance(new SimpleTaunt("You are nothing more than nutiment for my roots.")),
                              CooldownExact.Instance(1000, PredictiveMultiAttack.Instance(10, 40 * (float)Math.PI / 180, 4, 7, 0)),
                              CooldownExact.Instance(1000, PredictiveMultiAttack.Instance(10, 40 * (float)Math.PI / 180, 4, 7, 3)),
                              new RunBehaviors(HpLesserPercent.Instance(0.9f, new SetKey(-1, 3)))
                              )),
                      IfEqual.Instance(-1, 3,
                          new RunBehaviors(
                              SmoothWandering.Instance(0.5f, 10),
                              CooldownExact.Instance(5000, RingAttack.Instance(12, 10, 0, 1)),
                              CooldownExact.Instance(3000, RingAttack.Instance(12, 10, 0, 1)),
                              new RunBehaviors(HpLesserPercent.Instance(0.7f, new SetKey(-1, 4)))
                              )),
                       IfEqual.Instance(-1, 4,
                          new RunBehaviors(
                              Once.Instance(RingAttack.Instance(12, 10, 0, 0)),
                              CooldownExact.Instance(800, new SetKey(-1, 5))
                              )),
                       IfEqual.Instance(-1, 5,
                           new RunBehaviors(
                               InfiniteSpiralAttack.Instance(250, 6, 22.5f, 2),
                               CooldownExact.Instance(1750, new SetKey(-1,6))
                               )),
                       IfEqual.Instance(-1, 6,
                           new RunBehaviors(
                               InfiniteSpiralAttack.Instance(250, 6, -22.5f, 2),
                               CooldownExact.Instance(1750, new SetKey(-1,7))
                               )),
                       IfEqual.Instance(-1, 7,
                           new RunBehaviors(
                               Once.Instance(MultiAttack.Instance(10, 30 * (float)Math.PI / 180, 2, 0, 3)),
                               Once.Instance(new SetKey(-1, 8))
                               )),
                       IfEqual.Instance(-1, 8,
                           new RunBehaviors(
                               Once.Instance(new SimpleTaunt("You will be as food for my children!")),
                               Flashing.Instance(5000, 0xf0e68c),
                               ReturnSpawn.Instance(1),
                               CooldownExact.Instance(5000, new SetKey(-1, 9))
                               ))

                      )
                ));
    }
}



