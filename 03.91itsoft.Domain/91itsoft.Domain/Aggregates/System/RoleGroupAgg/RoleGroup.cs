﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _91itsoft.Domain.Aggregates.RoleAgg;
using _91itsoft.Domain.Aggregates.UserAgg;
using _91itsoft.Entity;

namespace _91itsoft.Domain.Aggregates.RoleGroupAgg
{
    [Table("RoleGroup")]
    public class RoleGroup : EntityBase
    {
        public override Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
