using System.Collections.Generic;

namespace Lab6.Memento
{
    internal class ChangesHistory
    {
        public Stack<AddPageMemento> States = new();
    }
}
