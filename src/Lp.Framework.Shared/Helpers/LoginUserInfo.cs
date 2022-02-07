using Lp.Framework.Shared.RBAC;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lp.Framework.Shared.Helpers
{
    public static class LoginUserInfo
    {
        private static Action<User>? SetUserInfoFunc = null!;
        private static Func<IApplicationBuilder, User?>? GetUserInfoFunc = null!;
        private static IApplicationBuilder App = null!;

        public static void Configure(Action<User> setUserInfoFunc, Func<IApplicationBuilder, User?> getUserInfoFunc)
        {
            if (setUserInfoFunc is null)
            {
                throw new ArgumentNullException(nameof(setUserInfoFunc));
            }

            if (getUserInfoFunc is null)
            {
                throw new ArgumentNullException(nameof(getUserInfoFunc));
            }

            SetUserInfoFunc = setUserInfoFunc;
            GetUserInfoFunc = getUserInfoFunc;
        }

        public static void Configure(IApplicationBuilder app, Func<IApplicationBuilder, User?> getUserInfoFunc)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (getUserInfoFunc is null)
            {
                throw new ArgumentNullException(nameof(getUserInfoFunc));
            }

            GetUserInfoFunc = getUserInfoFunc;
        }

        [Obsolete("丢弃该方式", true)]
        public static void Set(User user)
        {
            if (SetUserInfoFunc is null)
            {
                throw new ArgumentNullException(nameof(SetUserInfoFunc), "请添加设置UserInfo的方法");
            }
            SetUserInfoFunc(user);
        }

        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <returns> </returns>
        /// <exception cref="ArgumentNullException"> </exception>
        public static User? Get()
        {
            if (GetUserInfoFunc is null)
            {
                return null;
                throw new ArgumentNullException(nameof(GetUserInfoFunc), "请添加获取UserInfo的方法.");
            }
            return GetUserInfoFunc(App);
        }

        /// <summary>
        /// 使用用户登录信息
        /// </summary>
        /// <param name="app">  </param>
        /// <param name="func"> </param>
        /// <returns> </returns>
        public static IApplicationBuilder UseLoginUserInfo(this IApplicationBuilder app, Func<IApplicationBuilder, User?> func)
        {
            Configure(app, func);

            return app;
        }
    }
}