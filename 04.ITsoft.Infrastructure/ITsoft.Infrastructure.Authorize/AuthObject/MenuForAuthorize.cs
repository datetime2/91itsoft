using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITsoft.Infrastructure.Authorize.AuthObject
{
    public class MenuForAuthorize
    {
        public Guid MenuId { get; set; }

        public Guid ParentId { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
        public string MenuUrl { get; set; }
        public string MenuIcon { get; set; }
        public int SortOrder { get; set; }
    }
}
