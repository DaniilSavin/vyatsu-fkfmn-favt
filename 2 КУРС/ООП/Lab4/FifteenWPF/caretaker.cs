using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    internal class GameCaretaker
    {
        Stack<GameMemento> states;
        public GameCaretaker()
        {
            states = new Stack<GameMemento>();
        }

        public void Save(GameMemento state)
        {
            states.Push(state);
        }

        public GameMemento Restore()
        {
            if (states.Count == 0)
                throw new ArgumentNullException();
            GameMemento state = states.Pop();
            return state;
        }
    }
}
