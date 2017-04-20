using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ITsoft.Entity;

namespace ITsoft.Domain.Aggregates
{
    [Table("User")]
    public class User : EntityBase
    {
        public override Guid Id { get; set; }

        public string Name { get; set; }

        public string LoginName { get; set; }

        public string LoginPwd { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        public string LastLoginToken { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public virtual ICollection<RoleGroup> Groups { get; set; }

    }
}
