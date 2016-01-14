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
        private static _ NexusCrier = Behav()
            .Init(0x0e78, Behaves("Nexus Crier",
                            new RunBehaviors(
                /*Cooldown.Instance(30000,
                    new SimpleTaunt(
                        "Welcome everybody! I hope you enjoy this server, please note this is a legit server and we'll not spawn or give items."))*/
                                     Cooldown.Instance(20000,
                                            Rand.Instance(
                            new RandomTaunt(1.0, "Welcome to Doomed Realms Private Server."),
                            new RandomTaunt(1.0, "If you find any bugs/exploits please report it to a Founder, Owner, Super Founder or on the Forums."),
                            new RandomTaunt(1.0, "If you have any suggestions for the server you can post it on the Forums."),
                            new RandomTaunt(1.0, "Please test stuff by doing dungeons and playing the game in general."),
                            new RandomTaunt(1.0, "Don't beg! We don't give away items."),
                            new RandomTaunt(1.0, "/rules tells you the rules, you have no excuse"),
                            new RandomTaunt(1.0, "Any glitch abuse, such as items in the wrong slots, or selling an item while trading, is a bannable offense without warning."))
                ))));
    }
}