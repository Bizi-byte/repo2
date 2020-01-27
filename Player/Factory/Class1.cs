using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class CreatorFactory<Base, Key>
    {
        public delegate Base Del();
        
        private Dictionary<Key, Del> Creators = new Dictionary<Key, Del>();
        public bool Add(Key key, Del creator)
        {
            bool exists = Creators.ContainsKey(key);

            Creators[key] = creator;

            return exists;
            
        }
        
        public Base Create(Key key)
        {
            return (Creators[key]());
        }
    }
}
