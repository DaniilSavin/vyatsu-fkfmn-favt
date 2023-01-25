using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class GameCaretaker
    {
        public Stack<GameMemento> states;

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
