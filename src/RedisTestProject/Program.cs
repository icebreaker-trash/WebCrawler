using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //RedisDbPool dbpool = new RedisDbPool();
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            
            IServer server = redis.GetServer("localhost", 6379);
            IDatabase db = redis.GetDatabase();
            db.StringGetSet("测","大");
        }
    }
}
