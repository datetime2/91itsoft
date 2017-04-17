using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91itsoft.Domain.Entities
{
    public class BaseEntity
    {
        public bool IsEnable { get; private set; }
        public int Sort { get; private set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; private set; }
    }
}
