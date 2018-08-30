using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenvictFramework.Common;

namespace GenvictFramework.Cache
{
    public class RedisCache : IRedisCache
    {
        private ConnectionMultiplexer redis = null;
        private IDatabase db = null;
        private IServer server = null;

        public int Count => server.Keys().Count();

        public RedisCache()
        {
            try
            {
                redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisConnectionString"].Trim());
                db = redis.GetDatabase();

                server = redis.GetServer(redis.GetEndPoints()[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("初始化Redis对象失败", ex);
            }
        }

        public bool Exists(string key)
        {
            return db.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            var result = db.StringGet(key);
            if (!string.IsNullOrWhiteSpace(result))
            {
                return JsonHelper<T>.ConvertToObj(result);
            }
            return default(T);
        }

        public string Get(string key)
        {
            return db.StringGet(key);
        }

        public bool Insert<T>(string key, T value)
        {
            var insertStr = JsonHelper<T>.ConvertToStr(value);
            return db.StringSet(key, insertStr);
        }

        public bool Insert(string key, string value)
        {
            return db.StringSet(key, value);
        }

        public bool InsertOrUpdate(string key, string value)
        {
            return db.StringSet(key, value);
        }

        public bool InsertOrUpdate<T>(string key, T value)
        {
            var insertStr = JsonHelper<T>.ConvertToStr(value);
            return db.StringSet(key, insertStr);
        }

        public bool InsertOrUpdate(string key, string value, int timeout)
        {
            var flag = false;

            if (db.StringSet(key, value) && db.KeyExpire(key, DateTime.Now.AddSeconds(timeout)))
            {
                flag = true;
            }
            return flag;
        }

        public bool InsertOrUpdate<T>(string key, T value, int timeout)
        {
            var flag = false;

            var insertStr = JsonHelper<T>.ConvertToStr(value);

            if (db.StringSet(key, insertStr) && db.KeyExpire(key, DateTime.Now.AddSeconds(timeout)))
            {
                flag = true;
            }

            return flag;
        }

        public bool Insert<T>(string key, T value, int timeout)
        {
            var flag = false;

            var insertStr = JsonHelper<T>.ConvertToStr(value);

            if (db.StringSet(key, insertStr) && db.KeyExpire(key, DateTime.Now.AddSeconds(timeout)))
            {
                flag = true;
            }

            return flag;
        }

        public bool Insert(string key, string value, int timeout)
        {
            var flag = false;

            if (db.StringSet(key, value) && db.KeyExpire(key, DateTime.Now.AddSeconds(timeout)))
            {
                flag = true;
            }
            return flag;
        }

        public bool Delete(string key)
        {
            return db.KeyDelete(key);
        }

        public bool Update<T>(string key, T value)
        {
            var updateStr = JsonHelper<T>.ConvertToStr(value);
            return db.StringSet(key, updateStr);
        }

        public bool Update(string key, string value)
        {
            return db.StringSet(key, value);
        }

        public List<string> GetAllKeys()
        {
            List<string> keyList = new List<string>();
            var keys = server.Keys().ToArray();

            foreach (var key in keys)
            {
                keyList.Add(key);
            }

            return keyList;
        }

        public void Clear()
        {
            server.FlushDatabase();
        }
    }
}