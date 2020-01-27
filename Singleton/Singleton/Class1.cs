using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonUtil
{
    public class Singleton<T> where T : class, new()
    {
        static T Instance = default;
        static readonly object o = new object();
        
        public static T Create()
        {
            if (null == Instance)
            lock(o)
            {
                    if(null == Instance)
                    {
                        Instance = new T();
                    }

            }
            return Instance;
        }
    }

}
