using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Classes
{
    public class MyList : StringCollection, IAdd, IRemove, IUsed
    {
        public int Used => this.strings.Count;

        public MyList()
        {
            this.strings = new List<string>();
        }

        public int Add(string item)
        {
            this.strings.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removedItem = this.strings[0];
            this.strings.RemoveAt(0);
            return removedItem;
        }
    }
}
