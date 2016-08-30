using System;
using Xunit;
using NJLFramework.Redis;

namespace NJLFramework.Test
{
    public class CacheTest
    {
        [Fact]
        public void GetCache()
        {
            int a = 0;
            a++;
            RedisWebConnection rc = new RedisWebConnection("10.0.169.83",8888);
            var dd = rc.ServerInfo();
            Console.Write(a);
            Assert.Equal(a , 32);
        }

        
    }
}
