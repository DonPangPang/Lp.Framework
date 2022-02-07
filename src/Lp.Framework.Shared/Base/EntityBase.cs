using Lp.Framework.Shared.Extensions;
using Lp.Framework.Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lp.Framework.Shared.Base
{
    /// <summary>
    /// 基本类型
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class EntityBase<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Required]
        public T Id { get; set; } = default!;

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        public T? CreateUserId { get; set; }
        public string? CreateUserName { get; set; }
        public DateTime? CreateDate { get; set; }

        public T? ModifyUserId { get; set; }
        public string? ModifyUserName { get; set; }
        public DateTime? ModifyDate { get; set; }

        public void Create()
        {
            Id = EntityExtensions<T>.GetNext();
            CreateDate = DateTime.Now;
            if (LoginUserInfo.Get() is { } loginUserInfo)
            {
                CreateUserId = (T)(object)loginUserInfo.Id;
                CreateUserName = loginUserInfo.Name;
            }
        }

        public void Modify()
        {
            ModifyDate = DateTime.Now;
            if (LoginUserInfo.Get() is { } loginUserInfo)
            {
                ModifyUserId = (T)(object)loginUserInfo.Id;
                ModifyUserName = loginUserInfo.Name;
            }
        }
    }
}