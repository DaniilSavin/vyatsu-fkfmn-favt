using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Game
    {
        GameCaretaker gameCaretaker;
        Random rand;
        int[,] field;
        int size;
        int x0, y0;
        int moves;
        public Game()
        {
            rand = new Random();
            size = 4;
            field = new int[size, size];
        }
        public Game(int _size)
        {
            rand = new Random();
            size = _size;
            field = new int[size, size];
        }
        private int CoordinatesToPosition(int x, int y)
        {
            return y * size + x;
        }
        private void PositionToCoordinates(int position, out int x, out int y)
        {
            y = position / size;
            x = position % size;
        }
        public void Start()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    field[i, j] = CoordinatesToPosition(i, j) + 1;
            x0 = y0 = size - 1;
            field[x0, y0] = 0;
            for (int i = 0; i < 100; i++)
                ShiftRandom();
            moves = 0;
            gameCaretaker = new GameCaretaker();
        }
        public int GetNumber(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            if (x < 0 || x > size || y < 0 || y > size)
                return 0;
            else
                return field[x, y];
        }
        public void Shift(int x, int y)
        {
            field[x0, y0] = field[x, y];
            field[x, y] = 0;
            x0 = x;
            y0 = y;
            moves++;
        }
        public void CheckButton(int position)
        {
            PositionToCoordinates(position, out int x, out int y);
            if (Math.Abs(x - x0) + Math.Abs(y - y0) == 1)
            {
                Save();
                Shift(x, y);
            }
        }
        public void ShiftRandom()
        {
            int a = rand.Next(4);
            int x = x0, y = y0;
            if (a == 0 && x < size - 1) x++;
            else if (a == 1 && x > 0) x--;
            else if (a == 2 && y < size - 1) y++;
            else if (a == 3 && y > 0) y--;
            Shift(x, y);
        }
        public bool CheckWin()
        {
            if (x0 != size - 1 || y0 != size - 1)
                return false;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i != size - 1 && j != size - 1 && field[i, j] != CoordinatesToPosition(i, j) + 1)
                        return false;
            return true;
        }
        public int Moves
        {
            get => moves;
        }

        private void Save()
        {
            gameCaretaker.Save(new GameMemento(field, x0, y0, moves));
        }

        public void Undo()
        {
            GameMemento state = gameCaretaker.Restore();
            this.field = state.field;
            this.x0 = state.x0;
            this.y0 = state.y0;
            this.moves = state.moves;
        }
    }
}