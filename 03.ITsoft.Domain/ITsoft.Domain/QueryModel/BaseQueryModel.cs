using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITsoft.Domain.QueryModel
{
    public class BaseQueryModel
    {
        public BaseQueryModel()
        {
            this.page = 1;
            this.rows = 50;
        }
        public int? page { get; set; }
        public int? rows { get; set; }

    }
}
