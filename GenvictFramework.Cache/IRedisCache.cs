using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace GenvictFramework.Cache
{
    /// <summary>
    /// Redis缓存接口,
    /// 需要在程序App.config或Web.config中配置redis连接字符串
    /// <add key="RedisConnectionString" value="localhost;allowAdmin=true" />
    /// </summary>
    public interface IRedisCache : ICacheBase
    {
    }
}
