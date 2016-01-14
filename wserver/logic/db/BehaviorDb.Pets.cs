#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.attack;
using wServer.logic.cond;
using wServer.realm.entities.player;
using wServer.realm.entities;
using wServer.logic.movement;
using wServer.logic.loot;
using wServer.logic.taunt;
using Mono.Game;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ Pets = Behav()
            .InitMany(0x1600, 0x1679, i => Behaves("Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(3000, new PetsHealingHP(10, 60)),
                    Cooldown.Instance(3000, new PetsHealingMP(10, 50)),
                    Cooldown.Instance(3000, new PetAttack(50, 70, 10)
                        ))
                ))
                /*
                .Init(0x5666, Behaves("Gyaradoss",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(3000, new PetsHealingHP(10, 40)),
                    Cooldown.Instance(3000, new PetsHealingMP(10, 20)),
                    Cooldown.Instance(750, PetSimpleAttack.Instance(10, projectileIndex: 0)),
                     Cooldown.Instance(105000,
                        Rand.Instance(
                            new RandomTaunt(1.1, "Gyara! Gyara! Gyarados!"))
                    ))))
                    */
            .Init(0x7664, Behaves("Dark Sonic",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                        Cooldown.Instance(1500, new PetsHealingHP(69, 69)),
                        Cooldown.Instance(1400, new PetsHealingMP(33, 33))
                    )))
            .Init(0x7660, Behaves("Spiritual Defender Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1150, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))
                    ))
            )
                .Init(0x5666, Behaves("Gyaradoss",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(3000, new PetsHealingHP(10, 30)),
                    Cooldown.Instance(3000, new PetsHealingMP(10, 20)),
                    Cooldown.Instance(3000, new PetAttack(50, 70, 10)
                        ))
                ))
                .Init(0x1861, Behaves("Zombie Penguin",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(3000, new PetsHealingHP(10, 90)),
                    Cooldown.Instance(3000, new PetsHealingMP(10, 70)),
                    Cooldown.Instance(3000, new PetAttack(50, 70, 10)
                        ))
                ))
                .Init(0x4441, Behaves("Doomed Nature Beast",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(500, new PetsHealingHP(10, 90)),
                    Cooldown.Instance(500, new PetsHealingMP(10, 90)),
                    Cooldown.Instance(4000, new PetAttack(90, 200, 10)
                        ))
                ))
                .Init(0x5642, Behaves("Minotaur",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(3000, new PetsHealingHP(10, 30)),
                    Cooldown.Instance(3000, new PetsHealingMP(10, 20)),
                    Cooldown.Instance(500, PetSimpleAttack.Instance(10, projectileIndex: 0)
                        ))
                ))
            .Init(0x1763, Behaves("Pumpkinnnnn",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(3000, new PetsHealingHP(10, 30)),
                    Cooldown.Instance(3000, new PetsHealingMP(10, 20)),
                    Cooldown.Instance(3000, new PetAttack(50, 70, 10)
                        ))
                ))
            .Init(0x1680, Behaves("Josh's Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(80, 80)),
                    Cooldown.Instance(1500, new PetsHealingMP(50, 50)),
                    Cooldown.Instance(2000, new PetAttack(400, 500, 7)
                        ))
                ))
            .Init(0x2678, Behaves("Lil' Oryx 3",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(76, 76)),
                    Cooldown.Instance(1500, new PetsHealingMP(38, 38)),
                 Cooldown.Instance(750, PetMultiAttack.Instance(10, 10*(float) Math.PI/180, 5, 0, projectileIndex: 7)
                        ))
                ))
            .Init(0x2675, Behaves("Lil' Oryx 2",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(76, 76)),
                    Cooldown.Instance(1500, new PetsHealingMP(38, 38)),
                 Cooldown.Instance(750, PetMultiAttack.Instance(10, 10*(float) Math.PI/180, 5, 0, projectileIndex: 7)
                        ))
                ))
            .Init(0x1681, Behaves("Skeletal Guardian Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingMP(75, 75))
                    ))
            )
            .Init(0x1682, Behaves("Knight Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(76, 76)),
                    Cooldown.Instance(1500, new PetsHealingMP(38, 38)),
                    Cooldown.Instance(2000, new PetAttack(200, 300, 7)
                        ))
                ))
                .Init(0x1683, Behaves("Lunar's Phoenix",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(60, 70)),
                    Cooldown.Instance(1500, new PetsHealingMP(40, 50))
                        ))
                )
            .Init(0x1684, Behaves("Dallas's Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(69, 69)),
                    Cooldown.Instance(1500, new PetsHealingMP(40, 40))
                    ))
            )
            .Init(0x1685, Behaves("Astro's Griffin",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(76, 76)),
                    Cooldown.Instance(1500, new PetsHealingMP(38, 38))
                    ))
            )
             .Init(0x7599, Behaves("Support Bot",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(86, 86)),
                    Cooldown.Instance(1500, new PetsHealingMP(78, 78))
                    ))
            )
            .Init(0x1686, Behaves("Scootaloo",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(50, 50)),
                    Cooldown.Instance(1500, new PetsHealingMP(60, 60))
                    ))
            )
            .Init(0x1687, Behaves("Twilight Sparkle",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingMP(70, 70)),
                    Cooldown.Instance(1500, PetMultiAttack.Instance(7, 10*(float) Math.PI/180, 4))
                    ))
            )
            .Init(0x1688, Behaves("Kythal the Necromancer",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(45, 75)),
                    Cooldown.Instance(800, new PetsHealingMP(35, 65)),
                    Cooldown.Instance(750, PetMultiAttack.Instance(10, 10*(float) Math.PI/180, 5, 0, projectileIndex: 0)),
                    Cooldown.Instance(800, PetMultiAttack.Instance(10, 10*(float) Math.PI/180, 3, 25, 1))
                    )))
              .Init(0x3564, Behaves("Kythal the Skull",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(45, 75)),
                    Cooldown.Instance(800, new PetsHealingMP(35, 65)),
                    Cooldown.Instance(750, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 0)),
                    Cooldown.Instance(800, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 3, 25, 1))
                    )))
                   .Init(0x3670, Behaves("sphinxxx",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(25, 45)),
                    Cooldown.Instance(800, new PetsHealingMP(55, 95)),
                        Cooldown.Instance(1000, PetRingAttack.Instance(8, 20, 0, 1)),
                        Cooldown.Instance(4750, PetRingAttack.Instance(4, 20, 0, 2)),
                        Cooldown.Instance(5000, PetRingAttack.Instance(6, 20, 0, projectileIndex: 0))
                    
                    )))
                    .Init(0x3647, Behaves("Bess",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(65, 95)),
                    Cooldown.Instance(800, new PetsHealingMP(15, 45)),
                        Cooldown.Instance(1000, PetRingAttack.Instance(8, 20, 0, 2)),
                        Cooldown.Instance(4750, PetRingAttack.Instance(4, 20, 0, 0)),
                        Cooldown.Instance(5000, PetRingAttack.Instance(6, 20, 0, projectileIndex: 1))
                    )))
                   .Init(0x3649, Behaves("Nutt",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(25, 45)),
                    Cooldown.Instance(800, new PetsHealingMP(65, 95)),
                            Cooldown.Instance(2000, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 1, 0, 5)),
                            Cooldown.Instance(5000, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 1, 0, 6)),
                            Cooldown.Instance(3000, PetMultiAttack.Instance(10, 45 * (float)Math.PI / 180, 10, 0, 1)),
                            Cooldown.Instance(3500, PetMultiAttack.Instance(10, 45 * (float)Math.PI / 180, 10, 0, 2)),
                            Cooldown.Instance(3500, PetMultiAttack.Instance(10, 45*(float) Math.PI/180, 10, 0, 3)),
                            Cooldown.Instance(3500, PetMultiAttack.Instance(10, 45*(float) Math.PI/180, 10, 0, 4)),
                            Cooldown.Instance(5000,
                                PetMultiAttack.Instance(10, 45*(float) Math.PI/180, 7, 0, projectileIndex: 0))
                            
                    )))
            .Init(0x1699, Behaves("Shroom",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(45, 75)),
                    Cooldown.Instance(800, new PetsHealingMP(35, 65)),
                    Cooldown.Instance(750, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 0)),
                    Cooldown.Instance(800, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 3, 25, 1))
                    )))
            .Init(0x5679, Behaves("Cookiee",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(45, 95)),
                    Cooldown.Instance(800, new PetsHealingMP(35, 75)),
                    Cooldown.Instance(750, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 0)),
                    Cooldown.Instance(800, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 3, 25, 1))
                    )))
             .Init(0x7699, Behaves("Cerberus Skull",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(45, 65)),
                    Cooldown.Instance(800, new PetsHealingMP(35, 95)),
                    Cooldown.Instance(750, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 0))
//                    Cooldown.Instance(800, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 3, 25, 1))
                    )))

             .Init(0x7659, Behaves("Zenco The Undead God",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(45, 65)),
                    Cooldown.Instance(800, new PetsHealingMP(35, 95)),
                    Cooldown.Instance(750, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 0)),
                                Cooldown.Instance(800, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 3, 25, 1))
                    )))
            .Init(0x1787, Behaves("Nightmareee",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1000, new PetsHealingHP(25, 35)),
                    Cooldown.Instance(1000, new PetsHealingMP(35, 55)),
                Cooldown.Instance(1000, PetSimpleAttack.Instance(10, projectileIndex: 0))
                    )))
//            .Init(0x1689, Behaves("Cube Pet",
//                new RunBehaviors(
//                    Cooldown.Instance(750,
//                        PetPredictiveMultiAttack.Instance(25, 10*(float) Math.PI/180, 9, 1, projectileIndex: 0)),
//                    Cooldown.Instance(1500, PetPredictiveMultiAttack.Instance(25, 10*(float) Math.PI/180, 4, 1, 1)),
//                    If.Instance(new PetBehaves(), PetChasing.Instance(8, 10, 3))
//                    )))
            .InitMany(0x1690, 0x1691, (i) => Behaves("Elite Pet",
            new RunBehaviors(
                new Switch(new IfValue("Speed", "Value", If.Instance(new PetBehaves(), PetChasing.Instance(new GetTag(i).GetInt("Speed", "Value", 10), new GetTag(i).GetInt("Speed", "Value", 10), 3))),
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3))),
                Cooldown.Instance(new GetTag(i).GetInt("HP", "Cooldown", 1000), new IfTag("HP", new PetsHealingHP(new GetTag(i).GetInt("HP", "Min", 50), new GetTag(i).GetInt("HP", "Max", 100)))),
                Cooldown.Instance(new GetTag(i).GetInt("MP", "Cooldown", 1000), new IfTag("MP", new PetsHealingMP(new GetTag(i).GetInt("MP", "Min", 30), new GetTag(i).GetInt("MP", "Max", 60)))),
                Cooldown.Instance(new GetTag(i).GetInt("Dmg", "Cooldown", 1000), new IfTag("Dmg", new PetAttack(new GetTag(i).GetInt("Dmg", "Min", 50), new GetTag(i).GetInt("Dmg", "Max", 70), new GetTag(i).GetInt("Dmg", "Range", 10))))
                //Cooldown.Instance(1000, ThrowAttackPet.Instance(4, 10, 40, 70))
            )))
            .InitMany(0x6101, 0x61fe, i => Behaves("Donator Pet",
                new RunBehaviors(
                        If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(new GetTag(i).GetInt("HP", "Cooldown", 1000),
                        new IfTag("HP",
                            new PetsHealingHP(new GetTag(i).GetInt("HP", "Min", 0),
                                new GetTag(i).GetInt("HP", "Max", 0)))),
                    Cooldown.Instance(new GetTag(i).GetInt("MP", "Cooldown", 0),
                        new IfTag("MP",
                            new PetsHealingMP(new GetTag(i).GetInt("MP", "Min", 30),
                                new GetTag(i).GetInt("MP", "Max", 60)))),
                                Cooldown.Instance(1200, PetSimpleAttack.Instance(10))
                    )))
            .InitMany(0x61ff, 0x61ff, i => Behaves("Aceaku's Pet",
                new RunBehaviors(
                        If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(new GetTag(i).GetInt("HP", "Cooldown", 1000),
                        new IfTag("HP",
                            new PetsHealingHP(new GetTag(i).GetInt("HP", "Min", 0),
                                new GetTag(i).GetInt("HP", "Max", 0)))),
                    Cooldown.Instance(new GetTag(i).GetInt("MP", "Cooldown", 0),
                        new IfTag("MP",
                            new PetsHealingMP(new GetTag(i).GetInt("MP", "Min", 30),
                                new GetTag(i).GetInt("MP", "Max", 60))))
                    )))
                .Init(0x171f, Behaves("Valentine",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(200, 300))
                    ))
            )
            .Init(0x2721, Behaves("Lil' Oryx",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(100, 200)),
                    Cooldown.Instance(800, new PetsHealingMP(100, 200)),
         //           Cooldown.Instance(750, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 0)),
         //           Cooldown.Instance(800, PetMultiAttack.Instance(10, 10 * (float)Math.PI / 180, 3, 25, 1)),
                     Cooldown.Instance(105000,
                        Rand.Instance(
                            new RandomTaunt(1.1, "You should be following ME!"),
                            new RandomTaunt(4.9, "Owl is the most powerful being in the universe!"),
                            new RandomTaunt(1.1, "Doomleader is the most powerful being in the universe!"),
                            new RandomTaunt(1.1, "I am the most powerful being in the universe!"),
                            new RandomTaunt(1.01, "I will destroy you all."),
                            new RandomTaunt(1.1, "You call that FIGHTING!"))
                    ))))
                    /*
                                            .Init(0x6119, Behaves("Willper's White Bag",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(10, 10, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(25, 25)),
                    Cooldown.Instance(1500, new PetsHealingMP(15, 15)),
                Cooldown.Instance(1000, PetSimpleAttack.Instance(10, projectileIndex: 0))
                    )))
                     */
                                .Init(0x7f60, Behaves("Cotton's Pet",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(800, new PetsHealingHP(80, 80)),
                    Cooldown.Instance(800, new PetsHealingMP(70, 70)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0)),
                     Cooldown.Instance(60000,
                        Rand.Instance(
                            new RandomTaunt(1.0, "/spit Oryx the Mad God"))
                    ))))
                                .Init(0x7f61, Behaves("Coolio's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(90, 90)),
                    Cooldown.Instance(1500, new PetsHealingMP(50, 50)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                                                    .Init(0x7f62, Behaves("Willper's White Bag",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(25, 25)),
                    Cooldown.Instance(1500, new PetsHealingMP(15, 15)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                              .Init(0x7f63, Behaves("Obama's Phoenix Lord",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(25, 25)),
                    Cooldown.Instance(1500, new PetsHealingMP(15, 15)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                                .Init(0x7f64, Behaves("xXBottedXx's Candy Gnome",
                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(35, 35)),
                    Cooldown.Instance(1500, new PetsHealingMP(20, 20)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0)),
                     Cooldown.Instance(60000,
                        Rand.Instance(
                            new RandomTaunt(1.0, "Bring him the photo"))
                    ))))
                                                  .Init(0x7f65, Behaves("Mike's Goblin",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(60, 60)),
                    Cooldown.Instance(1500, new PetsHealingMP(55, 55))

                    )))
                                                  .Init(0x7f66, Behaves("LightningI's Geb",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(25, 25)),
                    Cooldown.Instance(1500, new PetsHealingMP(15, 15)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                                                  .Init(0x7f67, Behaves("SuperRyGuy's Troll",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(20, 20)),
                    Cooldown.Instance(1500, new PetsHealingMP(10, 10)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                                                  .Init(0x7f68, Behaves("Levelx100's lil' Bes",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(20, 20)),
                    Cooldown.Instance(1500, new PetsHealingMP(10, 10)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                                                  .Init(0x7f69, Behaves("Versified's Pirate",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(10, 10)),
                    Cooldown.Instance(1500, new PetsHealingMP(5, 5)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f70, Behaves("Filenub's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(90, 90)),
                    Cooldown.Instance(1500, new PetsHealingMP(50, 50)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f71, Behaves("Lelipwnnoob's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(40, 40)),
                    Cooldown.Instance(1500, new PetsHealingMP(35, 35)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f72, Behaves("IFoxy's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(60, 60)),
                    Cooldown.Instance(1500, new PetsHealingMP(35, 35)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f73, Behaves("Purple's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(60, 60)),
                    Cooldown.Instance(1500, new PetsHealingMP(35, 35)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f74, Behaves("Blue's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(35, 35)),
                    Cooldown.Instance(1500, new PetsHealingMP(20, 20)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f75, Behaves("Recluse's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(5, 5)),
                    Cooldown.Instance(1500, new PetsHealingMP(1, 1))

                    )))
                    .Init(0x7f76, Behaves("Stefive's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(25, 25)),
                    Cooldown.Instance(1500, new PetsHealingMP(15, 15)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0)),
                                         Cooldown.Instance(60000,
                        Rand.Instance(
                            new RandomTaunt(1.0, "Other frogs say Ribbit, I say Rabbit"))
                    )

                    )))
                    .Init(0x7f77, Behaves("Iole's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(25, 25)),
                    Cooldown.Instance(1500, new PetsHealingMP(15, 15)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0)),
                                         Cooldown.Instance(60000,
                        Rand.Instance(
                            new RandomTaunt(1.0, "How does a man die better than facing fearful odds for the ashes of his fathers and the temples of his gods"))
                    )

                    )))
                    .Init(0x7f78, Behaves("Bricksix's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(90, 90)),
                    Cooldown.Instance(1500, new PetsHealingMP(85, 85))

                    )))
                    .Init(0x7f79, Behaves("ZGPepsi's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(10, 10)),
                    Cooldown.Instance(1500, new PetsHealingMP(5, 5))

                    )))
                    .Init(0x7f80, Behaves("NinjaCookie's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(20, 20)),
                    Cooldown.Instance(1500, new PetsHealingMP(10, 10)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
                    .Init(0x7f81, Behaves("Musashi's Pet",
                                                new RunBehaviors(
                    If.Instance(new PetBehaves(), PetChasing.Instance(13, 8, 3)),
                    Cooldown.Instance(1500, new PetsHealingHP(100, 100)),
                    Cooldown.Instance(1500, new PetsHealingMP(75, 75)),
                    Cooldown.Instance(1200, PetSimpleAttack.Instance(9.2f, projectileIndex: 0))

                    )))
            ;
    }
}