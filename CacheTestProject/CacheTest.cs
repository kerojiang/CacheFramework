using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenvictFramework.Cache;

namespace CacheTestProject
{
    class CacheTest
    {

        IRedisCache cache = CacheFactory.Resolve<IRedisCache>();


        public void Test()
        {
            cache.Insert("1", "2");
        }


    }
}
