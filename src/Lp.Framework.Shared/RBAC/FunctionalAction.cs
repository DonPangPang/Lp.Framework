using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lp.Framework.Shared.RBAC
{
    /// <summary>
    /// 功能操作表
    /// </summary>
    [Table(name: "Lp_Base_FunctionAction")]
    public class FunctionalAction
    {
        [Required]
        public Guid Id { get; set; }
    }
}