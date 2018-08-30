using System.Collections.Generic;

namespace GenvictFramework.Cache
{
    public interface ICacheBase
    {
        /// <summary>
        /// 是否存在缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// 缓存数量
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// 根据Key获取对应的缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 根据Key获取对应的缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 新增缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Insert<T>(string key, T value);

        /// <summary>
        /// 新增缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Insert(string key, string value);

        /// <summary>
        /// 新增缓存,并设置失效时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">失效时间(秒)</param>
        /// <returns></returns>
        bool Insert<T>(string key, T value, int timeout);

        /// <summary>
        /// 新增缓存,并设置失效时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">失效时间(秒)</param>
        /// <returns></returns>
        bool Insert(string key, string value, int timeout);

        /// <summary>
        /// 新增或更新缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool InsertOrUpdate<T>(string key, T value);

        /// <summary>
        /// 新增或更新缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool InsertOrUpdate(string key, string value);

        /// <summary>
        ///  新增或更新缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        bool InsertOrUpdate(string key, string value, int timeout);

        /// <summary>
        ///  新增或更新缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        bool InsertOrUpdate<T>(string key, T value, int timeout);

        /// <summary>
        /// 删除指定缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Delete(string key);

        /// <summary>
        /// 更新指定缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="vlaue"></param>
        /// <returns></returns>
        bool Update<T>(string key, T value);

        /// <summary>
        /// 更新指定缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Update(string key, string value);

        /// <summary>
        /// 获取所有缓存key
        /// </summary>
        /// <returns></returns>
        List<string> GetAllKeys();

        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        void Clear();
    }
}