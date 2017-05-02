using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ITsoft.Entity;
using System.ComponentModel.DataAnnotations;

namespace ITsoft.Domain.Aggregates
{
    [Table("User")]
    public class User : EntityBase
    {
        public override Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string LoginName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LoginPwd { get; set; }
        [MaxLength(50)]
        [Required]
        public string PwdSalt { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string LastLoginToken { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
