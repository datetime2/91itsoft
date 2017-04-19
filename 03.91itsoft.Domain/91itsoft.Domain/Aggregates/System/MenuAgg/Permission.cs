using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _91itsoft.Domain.Aggregates.RoleAgg;
using _91itsoft.Domain.Aggregates.UserAgg;
using _91itsoft.Entity;

namespace _91itsoft.Domain.Aggregates.MenuAgg
{
    [Table("auth.Permission")]
    public class Permission : EntityBase
    {
        public override Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string ActionUrl { get; set; }

        public int SortOrder { get; set; }

        public DateTime Created { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
