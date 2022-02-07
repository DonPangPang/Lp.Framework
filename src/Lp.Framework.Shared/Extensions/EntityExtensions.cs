using Lp.Framework.Shared.Helpers;
using Lp.Framework.Shared.Base;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Lp.Framework.Shared.Extensions
{
    /// <summary>
    /// 配置Id生成器
    /// </summary>
    /// <typeparam name="T"> Id的类型 </typeparam>
    public static class EntityExtensions<T>
    {
        private static Func<T> IdCreator = null!;

        public static void Configure(Func<T> func)
        {
            IdCreator = func;
        }

        public static T GetNext()
        {
            if (IdCreator is null)
            {
                throw new ArgumentNullException(nameof(IdCreator), "请配置Id生成器.");
            }
            return IdCreator();
        }
    }

    /// <summary>
    /// 添加Id生成器
    /// </summary>
    public static class EntityExtensions
    {
        public static IServiceCollection AddIdCreator<T>(this IServiceCollection services, Func<T> func)
        {
            EntityExtensions<T>.Configure(func);

            return services;
        }

        public static IApplicationBuilder UseIdCreator<T>(this IApplicationBuilder app, Func<T> func)
        {
            EntityExtensions<T>.Configure(func);

            return app;
        }
    }
}