#region

using System.Linq;
using System.Text;
using wServer.svrPackets;
using System;
using System.Collections.Generic;
using Mono.Game;
using wServer.realm;
using wServer.realm.entities;

#endregion

namespace wServer.logic.movement
{
    internal class Chasing : Behavior
    {
        private static readonly Dictionary<Tuple<float, float, float, short?>, Chasing> instances =
            new Dictionary<Tuple<float, float, float, short?>, Chasing>();

        private readonly short? objType;

        private readonly float radius;
        private readonly Random rand = new Random();
        private readonly float speed;
        private readonly float targetRadius;

        private Chasing(float speed, float radius, float targetRadius, short? objType)
        {
            this.speed = speed;
            this.radius = radius;
            this.targetRadius = targetRadius;
            this.objType = objType;
        }

        public static Chasing Instance(float speed, float radius, float targetRadius, short? objType)
        {
            var key = new Tuple<float, float, float, short?>(speed, radius, targetRadius, objType);
            Chasing ret;
            if (!instances.TryGetValue(key, out ret))
                ret = instances[key] = new Chasing(speed, radius, targetRadius, objType);
            return ret;
        }

        protected override bool TickCore(RealmTime time)
        {
            if (Host.Self.HasConditionEffect(ConditionEffects.Paralyzed)) return true;
            var speed = this.speed*GetSpeedMultiplier(Host.Self);

            var dist = radius;
            var entity = GetNearestEntity(ref dist, objType);
            if (entity != null && dist > targetRadius)
            {
                var tx = entity.X + rand.Next(-2, 2)/2f;
                var ty = entity.Y + rand.Next(-2, 2)/2f;
                if (tx != Host.Self.X || ty != Host.Self.Y)
                {
                    var x = Host.Self.X;
                    var y = Host.Self.Y;
                    var vect = new Vector2(tx, ty) - new Vector2(Host.Self.X, Host.Self.Y);
                    vect.Normalize();
                    vect *= (speed/1.5f)*(time.thisTickTimes/1000f);
                    ValidateAndMove(Host.Self.X + vect.X, Host.Self.Y + vect.Y);
                    Host.Self.UpdateCount++;
                }
                return true;
            }
            return false;
        }
    }

    internal class PetChasingEnemy : Behavior
    {
        private static readonly Dictionary<Tuple<float, float, float>, PetChasingEnemy> instances =
            new Dictionary<Tuple<float, float, float>, PetChasingEnemy>();

        private readonly float radius;
        private readonly Random rand = new Random();
        private readonly float speed;
        private readonly float targetRadius;

        private PetChasingEnemy(float speed, float radius, float targetRadius)
        {
            this.speed = speed;
            this.radius = radius;
            this.targetRadius = targetRadius;
        }

        public static PetChasingEnemy Instance(float speed, float radius, float targetRadius)
        {
            var key = new Tuple<float, float, float>(speed, radius, targetRadius);
            PetChasingEnemy ret;
            if (!instances.TryGetValue(key, out ret))
                ret = instances[key] = new PetChasingEnemy(speed, radius, targetRadius);
            return ret;
        }

        protected override bool TickCore(RealmTime time)
        {
            if (Host.Self.HasConditionEffect(ConditionEffects.Paralyzed)) return true;
            var speed = this.speed*GetSpeedMultiplier(Host.Self);

            var dist = radius;
            var entity = GetNearestEntityPet(ref dist);
            if (entity != null && dist > targetRadius)
            {
                var tx = entity.X + rand.Next(-2, 2)/2f;
                var ty = entity.Y + rand.Next(-2, 2)/2f;
                if (tx != Host.Self.X || ty != Host.Self.Y)
                {
                    var x = Host.Self.X;
                    var y = Host.Self.Y;
                    var vect = new Vector2(tx, ty) - new Vector2(Host.Self.X, Host.Self.Y);
                    vect.Normalize();
                    vect *= (speed/1.5f)*(time.thisTickTimes/1000f);
                    ValidateAndMove(Host.Self.X + vect.X, Host.Self.Y + vect.Y);
                    Host.Self.UpdateCount++;
                }
                return true;
            }
            return false;
        }
    }

    internal class PetChasing : Behavior
    {
        private static readonly Dictionary<Tuple<float, float, float>, PetChasing> instances =
            new Dictionary<Tuple<float, float, float>, PetChasing>();

        private readonly float radius;
        private readonly Random rand = new Random();
        private readonly float speed;
        private readonly float targetRadius;

        private PetChasing(float speed, float radius, float targetRadius)
        {
            this.speed = speed;
            this.radius = radius;
            this.targetRadius = targetRadius;
        }

        public static PetChasing Instance(float speed, float radius, float targetRadius)
        {
            var key = new Tuple<float, float, float>(speed, radius, targetRadius);
            PetChasing ret;
            if (!instances.TryGetValue(key, out ret))
                ret = instances[key] = new PetChasing(speed, radius, targetRadius);
            return ret;
        }

        protected override bool TickCore(RealmTime time)
        {
            if (Host.Self.HasConditionEffect(ConditionEffects.Paralyzed)) return true;
            var speed = this.speed*GetSpeedMultiplier(Host.Self);

            var dist = radius;
            Entity entity = Host.Self.PlayerOwner;
            if (entity != null && dist > targetRadius)
            {
                var tx = entity.X + rand.Next(-2, 2)/2f;
                var ty = entity.Y + rand.Next(-2, 2)/2f;
                if (tx != Host.Self.X || ty != Host.Self.Y)
                {
                    var x = Host.Self.X;
                    var y = Host.Self.Y;
                    var vect = new Vector2(tx, ty) - new Vector2(Host.Self.X, Host.Self.Y);
                    vect.Normalize();
                    vect *= (speed/1.5f)*(time.thisTickTimes/1000f);
                    ValidateAndMove(Host.Self.X + vect.X, Host.Self.Y + vect.Y);
                    Host.Self.UpdateCount++;
                }
                return true;
            }
            return false;
        }
    }

    internal class PetBehaves : Behavior
    {
        private Random rand = new Random();

        protected override bool TickCore(RealmTime time)
        {
            if (Host.Self.PlayerOwner != null)
            {
                if (Host.Self.PlayerOwner.Owner != null)
                {
                    var distance = Vector2.Distance(new Vector2(Host.Self.X, Host.Self.Y),
                        new Vector2(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y));
                    if (distance > 12)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 22)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 32)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 42)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 52)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 62)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 72)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 82)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 92)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 102)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 112)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 122)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 132)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 142)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 152)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 162)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 172)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 182)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 192)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 202)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 212)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 222)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 232)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 242)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 252)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 262)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 272)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 282)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 292)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 302)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 312)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 322)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 332)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 342)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 352)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 362)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 372)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 382)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 392)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 402)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 412)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 422)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 432)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 442)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 452)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 462)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 472)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 482)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 492)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 502)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 512)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 522)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 532)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 542)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 552)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 562)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 572)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 582)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 592)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 602)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 612)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 622)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 632)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 642)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 652)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 662)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 672)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 682)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 692)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 702)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 712)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 722)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 732)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 742)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 752)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 762)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 772)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 782)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 792)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 802)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 812)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 822)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 832)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 842)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 852)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 862)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 872)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 882)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 892)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 902)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 912)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 922)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 932)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 942)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 952)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 962)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 972)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 982)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 992)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1012)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1022)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1032)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1042)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1052)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1062)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1072)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1082)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1092)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1102)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1112)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1122)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1132)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1142)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1152)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1162)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1172)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1182)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1192)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1202)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1212)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1222)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1232)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1242)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1252)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1262)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1272)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1282)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1292)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1302)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1312)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1322)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1332)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1342)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1352)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1362)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1372)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1382)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1392)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1402)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1412)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1422)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1432)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1442)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1452)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1462)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1472)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1482)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1492)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1502)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1512)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1522)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1532)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1542)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1552)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1562)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1572)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1582)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 1592)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2012)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2022)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2032)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2042)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2052)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2062)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2072)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2082)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 2092)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3012)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3022)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3032)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3042)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3052)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3062)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3072)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3082)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 3092)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4012)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4022)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4032)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4042)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4052)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4062)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4072)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4082)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 4092)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5012)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5022)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5032)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5042)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5052)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5062)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5072)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5082)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 5092)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 6002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 7002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 8002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 9002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 10002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 11002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 12002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 13002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 14002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 15002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 16002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 17002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 18002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 19002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 20002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 21002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 22002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 23002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 24002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 25002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 26002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 27002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 28002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 29002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 30002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 31002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 32002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 33002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 34002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance > 35002)
                    {
                        Host.Self.Move(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y);
                    }
                    if (distance >= 1)
                        return true;
                    return false;
                }
            }
            else
            {
                Host.Self.Owner.LeaveWorld(Host.Self);
            }
            var enemy = Host as Enemy;
            enemy.DamageCounter.Death();
            foreach (var i in enemy.CondBehaviors)
                if ((i.Condition & BehaviorCondition.OnDeath) != 0)
                    i.Behave(BehaviorCondition.OnDeath, Host, null, enemy.DamageCounter);
            try
            {
                enemy.Owner.LeaveWorld(enemy);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Out.WriteLine("Crash halted! - Nonexistent entity tried to die!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return false;
        }
    }
}