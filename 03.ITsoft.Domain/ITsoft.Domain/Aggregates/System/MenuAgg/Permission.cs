using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ITsoft.Entity;

namespace ITsoft.Domain.Aggregates
{
    [Table("Permission")]
    public class Permission : EntityBase
    {
        public override Guid Id { get; set; }
        public Guid ParentId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string ActionUrl { get; set; }

        public int SortOrder { get; set; }
        public string Icon { get; set; }
        public DateTime Created { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
