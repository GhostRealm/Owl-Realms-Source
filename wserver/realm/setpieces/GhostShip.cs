using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.logic.loot;
using wServer.realm.entities;
using db.data;

namespace wServer.realm.setpieces
{
    class GhostShip : ISetPiece
    {
        public int Size
        {
            get { return 50; }
        }

        static readonly byte Tree = (byte)XmlDatas.IdToType["Tree Jungle"];
        static readonly byte Water = (byte)XmlDatas.IdToType["GhostWater"];
        static readonly byte Sand = (byte)XmlDatas.IdToType["Ghost Water Beach"];


       Random rand = new Random();
       public void RenderSetPiece(World world, IntPoint pos)
       {
           int DarkGrassradiu = 17;
           int sandRadius = 17;
           int waterRadius = 14;

           List<IntPoint> border = new List<IntPoint>();

           int[,] o = new int[Size, Size];
           int[,] t = new int[Size, Size];

           for (int x = 0; x < Size; x++)                      //Trees
               for (int y = 0; y < Size; y++)
               {
                   double dx = x - (Size / 2.0);
                   double dy = y - (Size / 2.0);
                   double r = Math.Sqrt(dx * dx + dy * dy) + rand.NextDouble() * 4 - 2;
                   if (r <= DarkGrassradiu)
                       t[x, y] = 1;
               }

           for (int y = 0; y < Size; y++)      //Outer
               for (int x = 0; x < Size; x++)
               {
                   double dx = x - (Size / 2.0);
                   double dy = y - (Size / 2.0);
                   double r = Math.Sqrt(dx * dx + dy * dy);
                   if (r <= sandRadius)
                       t[x, y] = 2;
               }
           for (int y = 0; y < Size; y++)      //Water
               for (int x = 0; x < Size; x++)
               {
                   double dx = x - (Size / 2.0);
                   double dy = y - (Size / 2.0);
                   double r = Math.Sqrt(dx * dx + dy * dy);
                   if (r <= waterRadius)
                   {
                       t[x, y] = 3;
                   }
               }

           for (int x = 0; x < Size; x++)                  //Plants
               for (int y = 0; y < Size; y++)
               {
                   if (((x > 5 && x < DarkGrassradiu) || (x < Size - 5 && x > Size - DarkGrassradiu) ||
                        (y > 5 && y < DarkGrassradiu) || (y < Size - 5 && y > Size - DarkGrassradiu)) &&
                       o[x, y] == 0 && t[x, y] == 1)
                   {
                           t[x, y] = 4;
                   }
               }
           for (int x = 0; x < Size; x++)
               for (int y = 0; y < Size; y++)
               {
                   if (t[x, y] == 1)
                   {
                       var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                       tile.TileId = Tree; tile.ObjType = 0;
                       world.Obstacles[x + pos.X, y + pos.Y] = 0;
                       world.Map[x + pos.X, y + pos.Y] = tile;
                   }
                   else if (t[x, y] == 2)
                   {
                       var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                       tile.TileId = Sand; tile.ObjType = 0;
                       world.Obstacles[x + pos.X, y + pos.Y] = 0;
                       world.Map[x + pos.X, y + pos.Y] = tile;
                   }
                   else if (t[x, y] == 3)
                   {
                       var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                       tile.TileId = Water; tile.ObjType = 0;
                       world.Obstacles[x + pos.X, y + pos.Y] = 0;
                       world.Map[x + pos.X, y + pos.Y] = tile;
                   }
                   else if (t[x, y] == 4)
                   {
                       var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                       tile.ObjType = Tree;
                       if (tile.ObjId == 0) tile.ObjId = world.GetNextEntityId();
                       world.Obstacles[x + pos.X, y + pos.Y] = 0;
                       world.Map[x + pos.X, y + pos.Y] = tile;
                   }
               }
           Entity Gship = Entity.Resolve(0x0e37);

           Entity Gshipsum = Entity.Resolve(0x0e38);

           Gship.Move(pos.X + 24.5f, pos.Y + 24.5f);
           world.EnterWorld(Gship);

           Gshipsum.Move(pos.X + 25.5f, pos.Y + 25.5f);
           world.EnterWorld(Gshipsum);
          
       }
        

    }
}
