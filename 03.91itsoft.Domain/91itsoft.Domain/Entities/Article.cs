using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91itsoft.Domain.Entities
{
    public class Article : BaseEntity
    {
        public long ArticleId { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
    }
}
