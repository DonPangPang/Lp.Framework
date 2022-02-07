using Lp.Framework.Shared.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lp.Framework.Shared.RBAC
{
    /// <summary>
    /// 文件资源
    /// </summary>
    public class FileResource : EntityBase<Guid>
    {
        /// <summary>
        /// 文件资源
        /// </summary>
        [Required]
        public string FileSource { get; set; } = null!;
    }
}