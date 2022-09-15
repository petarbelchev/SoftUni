using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Classes
{
    public class AddCollection : StringCollection, IAdd
    {
        public AddCollection()
        {
            this.strings = new List<string>();
        }
        public int Add(string item)
        {
            this.strings.Add(item);
            return this.strings.Count - 1;
        }
    }
}
