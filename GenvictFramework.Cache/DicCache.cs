using System;
using System.Collections.Generic;
using System.Timers;

namespace GenvictFramework.Cache
{
    public class DicCache : IDicCache
    {
        private Timer timer = null;
        private Dictionary<string, object> dic = null;
        private Dictionary<string, DateTime> timeDic = null;

        public DicCache()
        {
            dic = new Dictionary<string, object>();
            timeDic = new Dictionary<string, DateTime>();
        }

        private object locker = new object();

        public int Count => dic.Count;

        private void Timer_Elapsed(object sender, ElapsedEventArgs e, string key, int timeOut)
        {
            lock (locker)
            {
                if (timeDic.ContainsKey(key))
                {
                    var lastTime = timeDic[key];
                    if (DateTime.Compare(lastTime.AddSeconds(timeOut), DateTime.Now) < 0)
                    {
                        //此缓存已经过期,应该删除
                        Delete(key);
                    }
                }
            }
        }

        public void Clear()
        {
            if (dic != null)
            {
                dic.Clear();
            }
            if (timeDic != null)
            {
                timeDic.Clear();
            }

            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        public List<string> GetAllKeys()
        {
            List<string> dataList = new List<string>();

            foreach (string key in dic.Keys)
            {
                dataList.Add(key);
            }

            return dataList;
        }

        public bool Exists(string key)
        {
            return dic.ContainsKey(key);
        }

        public T Get<T>(string key)
        {
            return (T)dic[key];
        }

        public string Get(string key)
        {
            return dic[key].ToString();
        }

        public bool Insert<T>(string key, T value)
        {
            bool flag = false;
            try
            {
                dic.Add(key, value);
                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool InsertOrUpdate<T>(string key, T value)
        {
            bool flag = false;
            try
            {
                if (dic.ContainsKey(key))
                {
                    dic[key] = value;
                }
                else
                {
                    dic.Add(key, value);
                }

                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool InsertOrUpdate(string key, string value)
        {
            bool flag = false;
            try
            {
                if (dic.ContainsKey(key))
                {
                    dic[key] = value;
                }
                else
                {
                    dic.Add(key, value);
                }

                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool Insert(string key, string value)
        {
            bool flag = false;
            try
            {
                dic.Add(key, value);
                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool InsertOrUpdate<T>(string key, T value, int timeout)
        {
            bool flag = false;

            try
            {
                if (dic.ContainsKey(key))
                {
                    dic[key] = value;
                    timeDic[key] = DateTime.Now;
                }
                else
                {
                    dic.Add(key, value);
                    timeDic.Add(key, DateTime.Now);
                }

                //初始化定时器，开始执行
                timer = new Timer(1000);
                timer.Elapsed += new ElapsedEventHandler((s, e) => Timer_Elapsed(s, e, key, timeout));
                timer.Start();

                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool InsertOrUpdate(string key, string value, int timeout)
        {
            bool flag = false;

            try
            {
                if (dic.ContainsKey(key))
                {
                    dic[key] = value;
                    timeDic[key] = DateTime.Now;
                }
                else
                {
                    dic.Add(key, value);
                    timeDic.Add(key, DateTime.Now);
                }

                //初始化定时器，开始执行
                timer = new Timer(1000);
                timer.Elapsed += new ElapsedEventHandler((s, e) => Timer_Elapsed(s, e, key, timeout));
                timer.Start();

                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool Insert<T>(string key, T value, int timeout)
        {
            bool flag = false;

            try
            {
                dic.Add(key, value);
                timeDic.Add(key, DateTime.Now);
                //初始化定时器，开始执行
                timer = new Timer(1000);
                timer.Elapsed += new ElapsedEventHandler((s, e) => Timer_Elapsed(s, e, key, timeout));
                timer.Start();

                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool Insert(string key, string value, int timeout)
        {
            bool flag = false;

            try
            {
                dic.Add(key, value);
                timeDic.Add(key, DateTime.Now);
                //初始化定时器，开始执行
                timer = new Timer(1000);
                timer.Elapsed += new ElapsedEventHandler((s, e) => Timer_Elapsed(s, e, key, timeout));
                timer.Start();

                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加缓存失败", ex);
            }

            return flag;
        }

        public bool Delete(string key)
        {
            if (timeDic.ContainsKey(key))
            {
                timeDic.Remove(key);
            }

            return dic.Remove(key);
        }

        public bool Update<T>(string key, T value)
        {
            bool flag = false;
            try
            {
                dic[key] = value;

                if (timeDic.ContainsKey(key))
                {
                    timeDic[key] = DateTime.Now;
                }
                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("更新缓存失败", ex);
            }
            return flag;
        }

        public bool Update(string key, string value)
        {
            bool flag = false;
            try
            {
                dic[key] = value;

                if (timeDic.ContainsKey(key))
                {
                    timeDic[key] = DateTime.Now;
                }
                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("更新缓存失败", ex);
            }
            return flag;
        }
    }
}