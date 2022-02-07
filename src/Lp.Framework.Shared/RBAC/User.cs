using Lp.Framework.Shared.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lp.Framework.Shared.RBAC
{
    public class User : EntityBase<Guid>, IEnableMark, IDeleteMark
    {
        public bool EnableMark { get; set; }
        public bool DeleteMark { get; set; }
    }
}