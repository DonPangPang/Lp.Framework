using Lp.Framework.Shared.Extensions;
using Lp.Framework.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lp.Framework.Shared.Base
{
    /// <summary>
    /// 启用标记
    /// </summary>
    public interface IEnableMark
    {
        public bool EnableMark { get; set; }
    }

    /// <summary>
    /// 删除标记
    /// </summary>
    public interface IDeleteMark
    {
        public bool DeleteMark { get; set; }
    }

    /// <summary>
    /// 临时标记
    /// </summary>
    public interface ITemporaryMark
    {
        public bool TemporaryMark { get; set; }
    }

    /// <summary>
    /// 状态标记
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public interface IStateMark<T> where T : Enum
    {
        public T StateMark { get; set; }
    }
}