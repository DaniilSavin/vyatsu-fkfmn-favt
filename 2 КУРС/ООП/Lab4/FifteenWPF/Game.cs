using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class GameLibrary1
    {
        int size;
        int[,] field;
        int x0, y0;
        int moves;
        static Random rand = new Random();
        public GameLibrary1(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            field = new int[size, size];

        }
        private int CoordinatesToPosition(int x, int y)
        {
            if (x < 0)
                x = 0;
            if (x > size - 1)
                x = size - 1;
            if (y < 0)
                y = 0;
            if (y > size - 1)
                y = size - 1;
            return y * size + x;
        }

        private void PositionToCoordinates(int position, out int x, out int y)
        {
            if (position < 0)
                position = 0;
            if (position > size * size - 1)
                position = size * size - 1;
            x = position % size;
            y = position / size;
        }
        public void start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    field[x, y] = CoordinatesToPosition(x, y) + 1;
            x0 = size - 1;
            y0 = size - 1;
            field[x0, y0] = 0;
            moves = 0;
        }
        public int GetNumber(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            if (x < 0 || x >= size)
                return 0;
            if (y < 0 || y >= size)
                return 0;
            return field[x, y];
        }
        public int counter = 0;
        internal object Run;

        public void Shift(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            if (Math.Abs(x0 - x) + Math.Abs(y0 - y) != 1)
                return;
            field[x0, y0] = field[x, y];
            field[x, y] = 0;
            x0 = x;
            y0 = y;
            counter++;
            moves++;
        }
        public void ShiftRandom()
        {
            int a = rand.Next(0, 4);
            int x = x0;
            int y = y0;
            switch (a)
            {
                case 0:
                    x--;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y--;
                    break;
                case 3:
                    y--;
                    break;
            }
            Shift(CoordinatesToPosition(x, y));
        }

        public bool Check()
        {
            if (!(x0 == size - 1 && y0 == size - 1))
                return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))
                        if (field[x, y] != CoordinatesToPosition(x, y) + 1)
                            return false;
            return true;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}