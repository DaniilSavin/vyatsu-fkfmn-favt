using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class GameMemento
    {
        internal int[,] field { get; }

        internal int x0 { get; }

        internal int y0 { get; }

        internal int counter { get; }
        public  GameMemento(int[,] field, int x0, int y0, int counter)
        {
            this.field = (int[,])field.Clone();
            this.x0 = x0;
            this.y0 = y0;
            this.counter = counter;
        }
    }
}
