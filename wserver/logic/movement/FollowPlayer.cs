using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.realm.entities;
using wServer.svrPackets;
using Mono.Game;

namespace wServer.logic.movement
{
    class FollowPlayer : Behavior
    {
        public Player player; //player to follow

        public FollowPlayer()
        {
            try
            {
                this.player = Host.Self.PlayerOwner;
            }
            catch
            {
                this.player = null;
            }
        }

        static readonly Dictionary<Player, FollowPlayer> instances = new Dictionary<Player, FollowPlayer>();

        public static FollowPlayer Instance(Player player)
        {
            var key = player;
            FollowPlayer ret;

            if (!instances.TryGetValue(key, out ret))
                ret = instances[key] = new FollowPlayer();
            return ret;
        }

        protected override bool TickCore(RealmTime time)
        {
            this.player = Host.Self.PlayerOwner;
            if (this.player.Client.Character.Pet == -1 || this.player.Client.Character.Pet != Host.Self.ObjectType)
            {
                try
                {
                    Host.Self.Owner.LeaveWorld(Host.Self);
                }
                catch { }
                return false;
            }
            int count = 0;
            foreach (var i in Host.Self.Owner.Players)
            {
                if (i.Value == this.player)
                    break;
                else
                    count++;
            }
            if (count == Host.Self.Owner.Players.Count)
            {
                try
                {
                    Host.Self.Owner.LeaveWorld(Host.Self);
                }
                catch { }
                return false;
            }

            float dist = 1;
            float ddist = Dist(Host.Self, player);

            Random rand = new Random();
            if ((Entity)player != null && dist < ddist)
            {
                var tx = player.X + rand.Next(-2, 2) / 2f;
                var ty = player.Y + rand.Next(-2, 2) / 2f;
                if (tx != Host.Self.X || ty != Host.Self.Y)
                {
                    var x = Host.Self.X;
                    var y = Host.Self.Y;
                    Vector2 vect = new Vector2(tx, ty) - new Vector2(Host.Self.X, Host.Self.Y);
                    vect.Normalize();
                    vect *= (10 / 1.5f) * (time.thisTickTimes / 1000f); //maybe we can change this to have the same speed as the player?
                    ValidateAndMove(Host.Self.X + vect.X, Host.Self.Y + vect.Y);
                    Host.Self.UpdateCount++;
                }
                return true;
            }
            else return false;
        }
    }
}
