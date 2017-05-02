using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITsoft.Domain.QueryModel
{
    public class BaseQueryModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}
