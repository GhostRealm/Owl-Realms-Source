using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace wServer.realm.setpieces
{
    internal interface ISetPiece
    {
        int Size { get; }
        void RenderSetPiece(World world, IntPoint pos);
    }
}