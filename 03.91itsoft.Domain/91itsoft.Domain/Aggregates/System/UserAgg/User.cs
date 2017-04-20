﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _91itsoft.Domain.Aggregates.MenuAgg;
using _91itsoft.Domain.Aggregates.RoleAgg;
using _91itsoft.Domain.Aggregates.RoleGroupAgg;
using _91itsoft.Entity;

namespace _91itsoft.Domain.Aggregates.UserAgg
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
