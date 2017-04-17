using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91itsoft.Domain.Entities
{
    public class Category: BaseEntity
    {
        public long CategoryId { get; set; }
        public long ParentId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }
    }
}
