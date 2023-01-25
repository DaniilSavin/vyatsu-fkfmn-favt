using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    internal class GameMemento
    {
        internal GameMemento(int[,] field, int x0, int y0, int counter)
        {
            this.field = (int[,])field.Clone();
            this.x0 = x0;
            this.y0 = y0;
            this.moves = counter;
        }

        internal int[,] field { get; }

        internal int x0 { get; }

        internal int y0 { get; }

        internal int moves { get; }
    }
}
