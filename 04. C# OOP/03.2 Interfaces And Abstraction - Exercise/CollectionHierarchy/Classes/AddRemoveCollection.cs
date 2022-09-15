using CollectionHierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy.Classes
{
    public class AddRemoveCollection : StringCollection, IAdd, IRemove
    {
        public AddRemoveCollection()
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
            string removedItem = this.strings.ElementAt(this.strings.Count - 1);
            this.strings.RemoveAt(this.strings.Count - 1);
            return removedItem;
        }
    }
}
