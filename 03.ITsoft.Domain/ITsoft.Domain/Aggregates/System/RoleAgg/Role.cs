using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ITsoft.Entity;

namespace ITsoft.Domain.Aggregates
{
    [Table("Role")]
    public class Role : EntityBase
    {
        public override Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public int SortOrder { get; set; }

        public DateTime Created { get; set; }

        public virtual RoleGroup RoleGroup { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
