using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace GenvictFramework.Cache
{
    public class CacheFactory
    {
        private static IContainer container = null;

        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Init();
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception("IOC实例化出错," + ex.Message);
            }
            return container.Resolve<T>();
        }

        private static void Init()
        {
            var builder = new ContainerBuilder();

            var assemblies = Assembly.GetExecutingAssembly();

            var baseType = typeof(ICacheBase);

            //自动注册所有继承至ICacheBase的类,缓存使用单例
            builder.RegisterAssemblyTypes(assemblies).Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();

            container = builder.Build();
        }
    }
}