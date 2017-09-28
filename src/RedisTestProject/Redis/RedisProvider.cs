using System;
using System.Collections.Generic;
using StackExchange.Redis;


namespace RedisTestProject.Redis
{
    public abstract class RedisProvider : IRedisUtil
    {
        /// <summary>
        /// 缓存连接字符串
        /// </summary>
        protected string redisClientHosts
        { get; set; }

        private string[] _writeClientHosts;
        /// <summary>
        /// 写数据Redis服务IP地址端口号
        /// </summary>
        protected string[] WriteClientHosts
        {
            get
            {
                if (null == _writeClientHosts)
                {
                    string writeClientHostsString = redisClientHosts.Split('|')[0];
                    _writeClientHosts = writeClientHostsString.Split(',');
                }
                return _writeClientHosts;
            }
        }

        private string[] _readClientHosts;
        /// <summary>
        /// 读数据Redis服务IP地址端口号
        /// </summary>
        protected string[] ReadClientHosts
        {
            get
            {
                if (null == _readClientHosts)
                {
                    string readClientHostsString = redisClientHosts.Split('|')[1];
                    _readClientHosts = readClientHostsString.Split(',');
                }
                return _readClientHosts;
            }
        }

        /// <summary>
        /// RedisClient链接池管理
        /// </summary>
        protected ConnectionMultiplexer RedisClientManager
        { set; get; }

        /// <summary>
        /// 创建缓存客户端链接池管理
        /// </summary>
        /// <param name="readWriteHosts">读写服务器Host</param>
        /// <param name="readOnlyHosts">只读数据库Host</param>
        /// <returns></returns>
        protected ConnectionMultiplexer CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            //支持读写分离，均衡负载
            return ConnectionMultiplexer.Connect("localhost");
        }

        /// <summary>
        /// 得到用于读取的客户端对象
        /// </summary>
        /// <returns>只读客户端对象</returns>
        private IDatabase GetReadClient()
        {
            return RedisClientManager.GetDatabase();
        }

        /// <summary>
        /// 得到用于写入的客户端对象
        /// </summary>
        /// <returns></returns>
        private IRedisClient GetWriteClient()
        {
            return RedisClientManager.GetClient();
        }


        #region 接口实现方法

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            using (IRedisClient client = GetWriteClient())
            {
                return client.Set<T>(key, value);
            }
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="objectSerializer">True：转换为Byte后写入缓存，False：直接写入缓存数据</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, bool objectSerializer)
        {
            using (IRedisClient client = GetWriteClient())
            {
                if (objectSerializer)
                {
                    var objSer = new ObjectSerializer();
                    return client.Set<byte[]>(key, objSer.Serialize(value));
                }
                else
                {
                    return client.Set<T>(key, value);
                }
            }
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes">缓存保留时间（单位：分钟）</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, int minutes)
        {
            using (IRedisClient client = GetWriteClient())
            {
                return client.Set<T>(key, value, DateTime.Now.AddMinutes(minutes));
            }
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes">缓存保留时间（单位：分钟）</param>
        /// <param name="objectSerializer">True：转换为Byte后写入缓存，False：直接写入缓存数据</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, int minutes, bool objectSerializer)
        {
            using (IRedisClient client = GetWriteClient())
            {
                if (objectSerializer)
                {
                    var objSer = new ObjectSerializer();
                    return client.Set<byte[]>(key, objSer.Serialize(value), DateTime.Now.AddMinutes(minutes));
                }
                else
                {
                    return client.Set<T>(key, value, DateTime.Now.AddMinutes(minutes));
                }
            }
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts">时间间隔</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan ts)
        {
            using (IRedisClient client = GetWriteClient())
            {
                return client.Set<T>(key, value, ts);
            }
        }

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts">时间间隔</param>
        /// <param name="objectSerializer">True：转换为Byte后写入缓存，False：直接写入缓存数据</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan ts, bool objectSerializer)
        {
            using (IRedisClient client = GetWriteClient())
            {
                if (objectSerializer)
                {
                    var objSer = new ObjectSerializer();
                    return client.Set<byte[]>(key, objSer.Serialize(value), ts);
                }
                else
                {
                    return client.Set<T>(key, value, ts);
                }
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            try
            {
                using (IRedisClient client = GetReadClient())
                {
                    return client.Get<object>(key);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("key:" + key + " | 错误信息:" + ZException.GetExceptionMessage(ex));
                return null;
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="objectDeserialize">True：获取数据为Byte，转换为对象后返回，False：直接获取缓存数据</param>
        /// <returns></returns>
        public object Get(string key, bool objectDeserialize)
        {
            try
            {
                using (IRedisClient client = GetReadClient())
                {
                    if (objectDeserialize)
                    {
                        var objSer = new ObjectSerializer();
                        return objSer.Deserialize(client.Get<byte[]>(key));
                    }
                    else
                    {
                        return client.Get<object>(key);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("key:" + key + " | 错误信息:" + ZException.GetExceptionMessage(ex));
                return null;
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            try
            {
                using (IRedisClient client = GetReadClient())
                {
                    return client.Get<T>(key);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("key:" + key + " | 错误信息:" + ZException.GetExceptionMessage(ex));
                return default(T);
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="objectDeserialize">True：获取数据为Byte，转换为T指定类型后返回，False：直接获取缓存数据</param>
        /// <returns></returns>
        public T Get<T>(string key, bool objectDeserialize)
        {
            try
            {
                using (IRedisClient client = GetReadClient())
                {
                    if (objectDeserialize)
                    {
                        var objSer = new ObjectSerializer();
                        return (T)objSer.Deserialize(client.Get<byte[]>(key));
                    }
                    else
                    {
                        return client.Get<T>(key);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("key:" + key + " | 错误信息:" + ZException.GetExceptionMessage(ex));
                return default(T);
            }
        }

        /// <summary>
        /// 获取指定Key的所有数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public List<T> GetAll<T>(List<string> keys)
        {
            try
            {
                using (IRedisClient client = GetReadClient())
                {
                    return client.GetValues<T>(keys);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("key:" + string.Join(",", keys) + " | 错误信息:" + ZException.GetExceptionMessage(ex));
                return null;
            }
        }

        /// <summary>
        /// 按前缀模糊查询获取数据
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="cacheKeyPrefix">缓存Key前缀</param>
        /// <returns></returns>
        public List<T> GetAll<T>(string cacheKeyPrefix)
        {
            try
            {
                using (IRedisClient client = GetReadClient())
                {
                    var keys = client.SearchKeys("*" + cacheKeyPrefix + "*");
                    return client.GetValues<T>(keys);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("key:" + cacheKeyPrefix + " | 错误信息:" + ZException.GetExceptionMessage(ex));
                return null;
            }
        }

        /// <summary>
        /// 获取所有的Key
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKey()
        {
            using (IRedisClient client = GetReadClient())
            {
                return client.GetAllKeys();
            }

        }

        /// <summary>
        /// 按前缀获取所有的Key
        /// </summary>
        /// <param name="cacheKeyPrefix"></param>
        /// <returns></returns>
        public List<string> GetAllKey(string cacheKeyPrefix)
        {
            using (IRedisClient client = GetReadClient())
            {
                return client.SearchKeys("*" + cacheKeyPrefix + "*");
            }

        }

        /// <summary>
        /// 移除缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            using (IRedisClient client = GetWriteClient())
            {
                return client.Remove(key);
            }
        }

        /// <summary>
        /// 移除缓存数据
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveAll(List<string> keys)
        {
            using (IRedisClient client = GetWriteClient())
            {
                foreach (var key in keys)
                {
                    client.Remove(key);
                }
            }
        }

        /// <summary>
        /// 按前缀移除缓存数据
        /// </summary>
        /// <param name="cacheKeyPrefix"></param>
        public void RemoveAll(string cacheKeyPrefix)
        {
            using (IRedisClient client = GetWriteClient())
            {
                var keys = client.SearchKeys("*" + cacheKeyPrefix + "*");
                foreach (var key in keys)
                {
                    client.Remove(key);
                }
            }
        }

        /// <summary>
        /// 是否存在缓存Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            using (IRedisClient client = GetReadClient())
            {
                return client.ContainsKey(key);
            }
        }

        /// <summary>
        /// 删除所有现有的数据库
        /// </summary>
        public void FlushAll()
        {
            using (IRedisClient client = GetWriteClient())
            {
                client.FlushAll();
            }
        }

        /// <summary>
        /// 持久化保存缓存数据
        /// </summary>
        public void Save()
        {
            using (IRedisClient client = GetWriteClient())
            {
                client.Save();
            }
        }

        #endregion




    }
}
