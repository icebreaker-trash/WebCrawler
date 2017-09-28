using System;
using System.Collections.Generic;


namespace RedisTestProject.Redis
{

    public interface IRedisUtil
    {
        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="value">数据值</param>
        /// <returns>是否写入成功</returns>
        bool Set<T>(string key, T value);

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="value">数据值</param>
        /// <param name="objectSerializer">是否序列化后进行Set存储</param>
        /// <returns>是否写入成功</returns>
        bool Set<T>(string key, T value, bool objectSerializer);

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="value">数据值</param>
        /// <param name="minutes">缓存保留时间（分钟）</param>
        /// <returns>是否写入成功</returns>
        bool Set<T>(string key, T value, int minutes);

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="value">数据值</param>
        /// <param name="minutes">缓存保留时间（分钟）</param>
        /// <param name="objectSerializer">是否序列化后进行Set存储</param>
        /// <returns>是否写入成功</returns>
        bool Set<T>(string key, T value, int minutes, bool objectSerializer);

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="value">数据值</param>
        /// <param name="ts">缓存保留时间间隔</param>
        /// <returns>是否写入成功</returns>
        bool Set<T>(string key, T value, TimeSpan ts);

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="value">数据值</param>
        /// <param name="ts">缓存保留时间间隔</param>
        /// <param name="objectSerializer">是否序列化后进行Set存储</param>
        /// <returns>是否写入成功</returns>
        bool Set<T>(string key, T value, TimeSpan ts, bool objectSerializer);

        /// <summary>
        /// 获得缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Get(string key);

        /// <summary>
        /// 获得缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="objectDeserialize">是否反序列化后进行获取对象</param>
        /// <returns></returns>
        object Get(string key, bool objectDeserialize);

        /// <summary>
        /// 获得指定类型的缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 获得指定类型的缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="objectDeserialize">是否反序列化后进行获取对象</param>
        /// <returns></returns>
        T Get<T>(string key, bool objectDeserialize);

        /// <summary>
        /// 根据List<Key>获得指定类型的List对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        List<T> GetAll<T>(List<string> keys);

        /// <summary>
        /// 根据Key获得指定类型的List对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="cacheKeyPrefix">Key前缀</param>
        /// <returns></returns>
        List<T> GetAll<T>(string cacheKeyPrefix);

        /// <summary>
        /// 获得缓存中所有的Key
        /// </summary>
        /// <returns></returns>
        List<string> GetAllKey();

        /// <summary>
        /// 根据前缀，获得缓存中所有的KEY
        /// </summary>
        /// <param name="cacheKeyPrefix"></param>
        /// <returns></returns>
        List<string> GetAllKey(string cacheKeyPrefix);

        /// <summary>
        /// 根据KEY，删除缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(string key);

        /// <summary>
        /// 根据List，删除一批缓存数据
        /// </summary>
        /// <param name="keys"></param>
        void RemoveAll(List<string> keys);

        /// <summary>
        /// 根据前缀，删除缓存数据
        /// </summary>
        /// <param name="cacheKeyPrefix"></param>
        void RemoveAll(string cacheKeyPrefix);

        /// <summary>
        /// 缓存中是否存在Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// 删除所有现有的缓存数据库
        /// </summary>
        void FlushAll();

        /// <summary>
        /// 持久化缓存数据
        /// </summary>
        void Save();

    }

}
