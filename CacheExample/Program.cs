using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenvictFramework.Cache;

namespace CacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IRedisCache cache = CacheFactory.Resolve<IRedisCache>();

                var a = cache.Get("P4");

                Console.WriteLine(a);

                var aa = cache.GetAllKeys();

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                throw new Exception("redis错误", ex);
            }



        }
    }
}
