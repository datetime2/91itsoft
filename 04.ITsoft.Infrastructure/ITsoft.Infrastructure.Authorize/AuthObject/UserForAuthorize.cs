using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITsoft.Infrastructure.Authorize.AuthObject
{
    public class UserForAuthorize
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        //菜单
        public List<MenuForAuthorize> Menus { get; set; }
        //操作按钮
        public List<ButtonForAuthorize> Buttons { get; set; }
    }
}
